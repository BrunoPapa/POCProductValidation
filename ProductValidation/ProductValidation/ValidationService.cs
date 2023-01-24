using ProductValidation.IoC.Interface.Service;
using ProductValidation.IoC.Interface.Database;
using ProductValidation.IoC.Database;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ProductValidation.IoC.Commom;

namespace ProductValidation
{
    public class ValidationService : IValidationService
    {
        private readonly IValidationRepository _validations;
        private readonly IBaseValidationService _validationService;

        public ValidationService(IValidationRepository validations, IBaseValidationService validationService)
        {
            _validations = validations;
            _validationService = validationService;
        }

        public async Task<IEnumerable<ValidationMessage>> Validate(int ProductCoreId, int ConfigVersion, IEnumerable<Field> fields, bool multipleErrors, int Language)
        {
            var validations = await GetValidation(ProductCoreId, ConfigVersion);

            if (!Validate(fields.ToList(), validations))
                return new List<ValidationMessage>()
                {
                    new ValidationMessage()
                    {
                        Message = "Validation error"
                    }
                };

            List <Task> tasksMessage = new List<Task>();
            List<ValidationMessage> validationMessages = new List<ValidationMessage>();
            var cts = new CancellationTokenSource();

            validations.ToList().ForEach(
                p =>
                    tasksMessage.Add(Task.Run(
                        async () =>
                        {
                            List<ValidationMessageRule> messagerules = _validationService.Validate(fields, p, cts, multipleErrors).Result.ToList();
                            if (messagerules.Count > 0)
                                validationMessages.Add(new ValidationMessage()
                                {
                                    Message = p.ValidationMessage.Where(m => m.LanguageId == Language).FirstOrDefault().Message,
                                    MessageRules = messagerules
                                });

                            return Task.CompletedTask;
                        }
                    ))
            );

            while (tasksMessage.Count > 0)
            {
                var finishedTask = Task.WhenAny(tasksMessage);
                if (finishedTask.IsCompleted || finishedTask.IsCanceled || finishedTask.IsFaulted)
                    tasksMessage.Remove(finishedTask.Result);

                if (finishedTask.Status == TaskStatus.Faulted && multipleErrors == false)
                    cts.Cancel();
            }

            return validationMessages;
        }

        private bool Validate(List<Field> fields, List<ValidationEntity> validations)
        {
            bool valid = true;

            fields.ForEach(p => { if (p.metadata == null) valid = false; else if (int.Parse(p.metadata.id) == 0) valid = false;  });

            validations.ForEach(v => v.ValidationRule.ToList().ForEach(r => {
                if (fields.Where(f => int.Parse(f.metadata.id) == r.LeftFieldId).Count() == 0)
                    valid = false;

                if (r.RightFieldId > 0)
                    if (fields.Where(f => int.Parse(f.metadata.id) == r.RightFieldId).Count() == 0)
                        valid = false;
            }));

            return valid;
        }

        private async Task<List<ValidationEntity>> GetValidation(int ProductCoreId, int ConfigVersion)
        { 
            List<ValidationEntity> validationEntities = new List<ValidationEntity>();
            if (ProductCoreId > 0 && ConfigVersion == 0)
                validationEntities.AddRange(await _validations.GetByProduct(ProductCoreId));
            else if (ProductCoreId == 0 && ConfigVersion > 0)
                validationEntities.AddRange(await _validations.GetByConfigVersion(ConfigVersion));
            else if (ProductCoreId > 0 && ConfigVersion > 0)
                validationEntities.AddRange(await _validations.GetAll(ProductCoreId, ConfigVersion));

            return validationEntities;
        }
    }
}
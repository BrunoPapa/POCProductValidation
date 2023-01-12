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
        private readonly IBaseValidationRepository _validations;
        private readonly IBaseValidationService _validationService;

        public ValidationService(IBaseValidationRepository validations, IBaseValidationService validationService)
        {
            _validations = validations;
            _validationService = validationService;
        }

        public async Task<IEnumerable<ValidationMessage>> Validate(ContractEntity contract, bool multipleErrors, int Language)
        {
            var validations = await _validations.GetByProduct(contract.Product.Id);

            List<Task> tasksMessage = new List<Task>();
            List<ValidationMessage> validationMessages = new List<ValidationMessage>();
            var cts = new CancellationTokenSource();

            validations.ToList().ForEach(
                p =>
                    tasksMessage.Add(Task.Run(
                        async () => 
                        {
                            List<ValidationMessageRule> messagerules = _validationService.Validate(contract, p, cts, multipleErrors).Result.ToList();
                            if (messagerules.Count > 0)
                                validationMessages.Add(new ValidationMessage()
                                {
                                    Message = p.ConfigValidationMessages.Where(m => m.LanguageId == Language).FirstOrDefault().Message,
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
    }
}
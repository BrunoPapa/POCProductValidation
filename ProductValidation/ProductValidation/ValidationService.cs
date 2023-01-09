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
        private readonly IProductRepository _products;
        private readonly IBaseValidationRepository _validations;
        private readonly IBaseValidationService _validationService;

        public ValidationService(IBaseValidationRepository validations, IProductRepository products, IBaseValidationService validationService)
        {
            _products = products;
            _validations = validations;
            _validationService = validationService;
        }

        public async Task<IEnumerable<ValidationMessage>> Validate(ContractEntity contract, bool multipleErrors)
        {
            var product = await _products.GetById(contract.Product.Id);
            var validations = await _validations.GetByProduct(contract.Product.Id);

            List<Task> tasks = new List<Task>();
            List<ValidationMessage> validationMessages = new List<ValidationMessage>();
            var cts = new CancellationTokenSource();

            validations.ToList().ForEach(
                p => tasks.Add(
                    Task.Run(
                        async () => validationMessages.AddRange(_validationService.Validate(contract, p, cts, multipleErrors).Result.ToList())
                    )
                )
            );

            while (tasks.Count > 0)
            {
                var finishedTask = await Task.WhenAny(tasks);                
                tasks.Remove(finishedTask);

                if (finishedTask.Status == TaskStatus.Faulted && multipleErrors == false)
                    cts.Cancel();                
            }

            return validationMessages;
        }        

        
    }
}
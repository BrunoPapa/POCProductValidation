using ProductValidation.IoC.Commom;
using ProductValidation.IoC.Database;
using ProductValidation.IoC.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace ProductValidation.WebApi.Controllers
{
    [Route("api/Service")]
    public class ServiceController : ApiController
    {
        private readonly IValidationService _validationService;

        public ServiceController(IValidationService validationService)
        {
            _validationService = validationService;
        }

        [HttpPost]
        public async Task<ServiceResponse> Validate(ContractRequest contract)
        {
            ContractEntity _contract = new ContractEntity() {
                Id = contract.Id,
                Product = new ProductEntity() { Id = contract.Id },
                FieldsContracts = new List<FieldsContractEntity>()
            };

            contract.Fields.ToList().ForEach(p =>
                _contract.FieldsContracts.Add(new FieldsContractEntity()
                {
                    FieldsProduct = new FieldsProductEntity()
                    {
                        Field = new FieldEntity() { Code = p.Code }
                    },
                    Value = p.Value
                })
            );

            ServiceResponse serviceResponse = new ServiceResponse()
            {
                MultipleErrors = contract.MultipleErrors,
                ValidationMessage = new List<ValidationMessage>()
            };

            try
            {
                serviceResponse.ValidationMessage = _validationService.Validate(_contract, contract.MultipleErrors, contract.Language).Result.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.ValidationMessage.Add(new ValidationMessage()
                {
                    Message = ex.Message                    
                });
            }

            return serviceResponse;
        }
    }
}

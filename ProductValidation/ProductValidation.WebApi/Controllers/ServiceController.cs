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
            List<Field> fields = new List<Field>();
            try
            {
                if (contract == null)
                    throw new Exception("Contract invalid.");
                if (contract.data == null)
                    throw new Exception("Contract invalid.");
                if (contract.data.fields == null)
                    throw new Exception("Contract not contain fields.");

                fields.AddRange(contract.data.fields);

                if (contract.data.objects != null)
                    contract.data.objects.ForEach(p => { if (p.fields != null) fields.AddRange(p.fields); });
            }
            catch (Exception ex)
            {
                return new ServiceResponse() { MultipleErrors = false, ValidationMessage = new List<ValidationMessage> { 
                    new ValidationMessage() { Message = ex.Message }
                } };
            }   

            ServiceResponse serviceResponse = new ServiceResponse()
            {
                MultipleErrors = contract.MultipleErrors,
                ValidationMessage = new List<ValidationMessage>()
            };

            try
            {
                serviceResponse.ValidationMessage = _validationService.Validate(int.Parse(contract.data.coreProductId), fields, contract.MultipleErrors, contract.Language).Result.ToList();
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

using ProductValidation.IoC.Commom;
using ProductValidation.IoC.Database;
using ProductValidation.IoC.Interface.Service;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace ProductValidation.WebApi.Controllers
{
    [Route("Service")]
    public class ServiceController : ApiController
    {
        private readonly IValidationService _validationService;

        public ServiceController(IValidationService validationService)
        {
            _validationService = validationService;
        }

        [HttpPost]
        public async Task<IEnumerable<ValidationMessage>> Validate(ContractEntity contract)
        {
            return await _validationService.Validate(contract, true);
        }
    }
}

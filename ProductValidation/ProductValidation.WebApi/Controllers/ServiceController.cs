using ProductValidation.IoC.Commom;
using ProductValidation.IoC.Database;
using ProductValidation.IoC.Interface.Service;
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
        public async Task<IEnumerable<ValidationMessage>> Validate(ContractRequest contract)
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

            return await _validationService.Validate(_contract, true);
        }
    }
}

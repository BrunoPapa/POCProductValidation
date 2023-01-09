using ProductValidation.IoC.Commom;
using ProductValidation.IoC.Database;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductValidation.IoC.Interface.Service
{
    public interface IValidationService
    {
        Task<IEnumerable<ValidationMessage>> Validate(ContractEntity contract, bool multipleErrors = false);
    }
}

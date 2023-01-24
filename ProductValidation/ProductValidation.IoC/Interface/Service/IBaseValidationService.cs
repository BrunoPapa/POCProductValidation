using ProductValidation.IoC.Commom;
using ProductValidation.IoC.Database;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ProductValidation.IoC.Interface.Service
{
    public interface IBaseValidationService
    {
        Task<IEnumerable<ValidationMessageRule>> Validate(IEnumerable<Field> fields, ValidationEntity validation, CancellationTokenSource cts, bool multipleErrors);
    }
}

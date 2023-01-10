using ProductValidation.IoC.Commom;
using System.Collections.Generic;

namespace ProductValidation.WebApi.Controllers
{
    public class ServiceResponse
    {
        public bool MultipleErrors { get; set; }
        public List<ValidationMessage> ValidationMessage { get; set; }
    }
}
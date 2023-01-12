using ProductValidation.IoC.Commom;
using System.Collections.Generic;

namespace ProductValidation.WebApi.Controllers
{
    public class ContractRequest
    {
        public int Language { get; set; }
        public bool MultipleErrors { get; set; }
        public Data data { get; set; }
    }    
}
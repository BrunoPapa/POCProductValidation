using ProductValidation.IoC.Database;
using ProductValidation.IoC.Enumerators;
using System.Collections.Generic;

namespace ProductValidation.IoC.Commom
{
    public class ValidationMessage
    {        
        public string Message { get; set; }
        public List<ValidationMessageRule> MessageRules { get; set; }
    }

    public class ValidationMessageRule
    {
        public int RuleTypeId { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }        
        public SeverityType Severity { get; set; }
    }
}

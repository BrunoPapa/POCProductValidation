using ProductValidation.IoC.Database;
using ProductValidation.IoC.Enumerators;

namespace ProductValidation.IoC.Commom
{
    public class ValidationMessage
    {
        public SeverityType Severity { get; set; }
        public string Message { get; set; }
        public int RuleTypeId { get; set; }
        public bool MultipleErrors { get; set; }
    }
}

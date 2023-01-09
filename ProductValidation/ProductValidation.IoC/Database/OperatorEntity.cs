using ProductValidation.IoC.Interface.Database;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductValidation.IoC.Database
{
    public class OperatorEntity : IEntity
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Label { get; set; }
        public bool Is_Active { get; set; }
        public bool IsFieldLov { get; set; }
        public bool IsField_Integer { get; set; }
        public bool IsField_Decimal { get; set; }
        public bool IsField_Text { get; set; }
        public bool IsField_Date { get; set; }
        public bool IsRisk { get; set; }
        public bool IsFieldRiskLOV { get; set; }
        public bool IsFieldRisk { get; set; }
    }
}

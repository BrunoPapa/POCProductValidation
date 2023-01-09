using ProductValidation.IoC.Enumerators;
using ProductValidation.IoC.Interface.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductValidation.IoC.Database
{
    public class ConfigValidationRuleEntity : IEntity
    {
        public int Id { get; set; }
        [ForeignKey(nameof(ConfigValidation))]
        public int ConfigValidationId { get; set; }
        public ConfigValidationEntity ConfigValidation { get; set; }
        [ForeignKey(nameof(BaseValidation))]
        public int BaseValidatioId { get; set; }
        public BaseValidationEntity BaseValidation { get; set; }
        public string RuleDescription { get; set; }
        public bool IsFieldChoice { get; set; }
        public int RuleTypeId { get; set; }
        public int LeftFieldId { get; set; }
        public int LeftRiskField { get; set; }
        [ForeignKey(nameof(Operator))]
        public int OperatorId { get; set; }
        public OperatorEntity Operator { get; set; }
        public string ValueText { get; set; }
        public DateTime ValueDate { get; set; }
        public int ValueMin { get; set; }
        public float ValueMax { get; set; }
        public int ValueSelected { get; set; }
        public bool ValueNull { get; set; }
        public int BaseLOVEntryId { get; set; }
        public SeverityType Severity { get; set; } // Error / Warning / Info        
    }
}

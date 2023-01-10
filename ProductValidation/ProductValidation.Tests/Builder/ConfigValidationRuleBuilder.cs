using ProductValidation.IoC.Database;
using System;
using System.Collections.Generic;

namespace ProductValidation.Tests.Builder
{
    public class ConfigValidationRuleBuilder : GenericBuilder<ConfigValidationRuleEntity>
    {
        public ConfigValidationRuleBuilder()
        {
            _instance =  new ConfigValidationRuleEntity()
            {
                Id = new Random().Next(99999),
                BaseValidation = new BaseValidationEntity(),
                ConfigValidation = new ConfigValidationEntity(),
                ConfigValidationRuleLOVs = new List<ConfigValidationRuleLOVEntity>(),
                Operator = new OperatorEntity(),
                ValueDate = DateTime.Now,
                ValueMin = 0,
                ValueMax = 0,
                ValueSelect = "",
                ValueText = "",
                ValueNull = true                
            };            
        }

        public ConfigValidationRuleBuilder WithBaseValidation(BaseValidationEntity baseValidation)
        {
            _instance.BaseValidation = baseValidation;
            return this;
        }

        public ConfigValidationRuleBuilder WithConfigValidation(ConfigValidationEntity configValidation)
        {
            _instance.ConfigValidation = configValidation;
            return this;
        }

        public ConfigValidationRuleBuilder WithConfigValidationRuleLOVs(List<ConfigValidationRuleLOVEntity> configValidationRuleLOVs)
        {
            _instance.ConfigValidationRuleLOVs = configValidationRuleLOVs;
            return this;
        }
        public ConfigValidationRuleBuilder WithOperator(OperatorEntity Operator)
        {
            _instance.Operator = Operator;
            return this;
        }

        public ConfigValidationRuleBuilder WithRuleTypeId(int ruleTypeId)
        {
            _instance.RuleTypeId = ruleTypeId;
            return this;
        }
        public ConfigValidationRuleBuilder WithIsFieldChoice(bool isFieldChoice)
        {
            _instance.IsFieldChoice = isFieldChoice;
            return this;
        }

        public ConfigValidationRuleBuilder WithRuleDescription(string ruleDescription)
        {
            _instance.RuleDescription = ruleDescription;
            return this;
        }

        public ConfigValidationRuleBuilder WithSeverity(int severity)
        {
            _instance.Severity = severity;
            return this;
        }

        public ConfigValidationRuleBuilder WithValueDate(DateTime valueDate)
        {
            _instance.ValueDate = valueDate;
            return this;
        }

        public ConfigValidationRuleBuilder WithValueMin(int valueMin)
        {
            _instance.ValueMin = valueMin;
            return this;
        }

        public ConfigValidationRuleBuilder WithValueMax(int valueMax)
        {
            _instance.ValueMax = valueMax;
            return this;
        }

        public ConfigValidationRuleBuilder WithValueSelect(string valueSelect)
        {
            _instance.ValueSelect = valueSelect;
            return this;
        }

        public ConfigValidationRuleBuilder WithValueText(string valueText)
        {
            _instance.ValueText = valueText;
            return this;
        }

        public ConfigValidationRuleBuilder WithValueNull(bool valueNull)
        {
            _instance.ValueNull = valueNull;
            return this;
        }
    }
}

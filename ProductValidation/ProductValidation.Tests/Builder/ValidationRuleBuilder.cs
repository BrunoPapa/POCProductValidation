using ProductValidation.IoC.Database;
using System;
using System.Collections.Generic;

namespace ProductValidation.Tests.Builder
{
    public class ValidationRuleBuilder : GenericBuilder<ValidationRuleEntity>
    {
        public ValidationRuleBuilder()
        {
            _instance =  new ValidationRuleEntity()
            {
                Id = new Random().Next(99999),
                Validation = new ValidationEntity(),
                Operator = new OperatorEntity(),
                ValueDate = DateTime.Now,
                ValueMin = 0,
                ValueMax = 0,
                ValueSelect = "",
                ValueText = "",
                ValueNull = true                
            };            
        }

        public ValidationRuleBuilder WithValidation(ValidationEntity validation)
        {
            _instance.Validation = validation;
            return this;
        }

        public ValidationRuleBuilder WithOperator(OperatorEntity Operator)
        {
            _instance.Operator = Operator;
            return this;
        }

        public ValidationRuleBuilder WithRuleTypeId(int ruleTypeId)
        {
            _instance.RuleTypeId = ruleTypeId;
            return this;
        }
        public ValidationRuleBuilder WithIsFieldChoice(bool isFieldChoice)
        {
            _instance.IsFieldChoice = isFieldChoice;
            return this;
        }

        public ValidationRuleBuilder WithRuleDescription(string ruleDescription)
        {
            _instance.RuleDescription = ruleDescription;
            return this;
        }

        public ValidationRuleBuilder WithValueDate(DateTime valueDate)
        {
            _instance.ValueDate = valueDate;
            return this;
        }

        public ValidationRuleBuilder WithValueMin(int valueMin)
        {
            _instance.ValueMin = valueMin;
            return this;
        }

        public ValidationRuleBuilder WithValueMax(int valueMax)
        {
            _instance.ValueMax = valueMax;
            return this;
        }

        public ValidationRuleBuilder WithValueSelect(string valueSelect)
        {
            _instance.ValueSelect = valueSelect;
            return this;
        }

        public ValidationRuleBuilder WithValueText(string valueText)
        {
            _instance.ValueText = valueText;
            return this;
        }

        public ValidationRuleBuilder WithValueNull(bool valueNull)
        {
            _instance.ValueNull = valueNull;
            return this;
        }
    }
}

﻿using ProductValidation.IoC.Commom;
using ProductValidation.IoC.Database;
using ProductValidation.IoC.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ProductValidation
{
    public abstract class ValidationRuleService : IValidationRuleService
    {
        protected IEnumerable<FieldContractEntity> _fields;
        protected ConfigValidationRuleEntity _rule;
        protected CancellationTokenSource _cts;
        protected FieldContractEntity _selectedField;
        protected object _value;
        protected object _compareValue;

        public bool Validate(IEnumerable<FieldContractEntity> fields, ConfigValidationRuleEntity validationrule, CancellationTokenSource cts)
        {
            _fields = fields;
            _rule = validationrule;
            _cts = cts;

            if (isValid())
                return RuleValidation();
            else
                return false;
        }

        protected virtual bool isValid()
        {
            //verifica se existe o campo para a aplicação da regra
            if (_fields.Where(p => p.Field.Code == _rule.Operator.Code).Count() == 0) return false;
            else
            {
                _selectedField = _fields.Where(p => p.Field.Code == _rule.Operator.Code).FirstOrDefault();

                //get value
                if (_rule.Operator.IsField_Text)
                {
                    _value = _selectedField.Value;
                    _compareValue = _rule.ValueText;
                }
                else if (_rule.Operator.IsField_Date)
                {
                    _value = DateTime.Parse(_selectedField.Value);
                    _compareValue = _rule.ValueDate;
                }
                else if (_rule.Operator.IsField_Integer)
                {
                    _value = int.Parse(_selectedField.Value);
                    _compareValue = _rule.ValueMin;
                }

                else if (_rule.Operator.IsField_Decimal)
                {
                    _value = float.Parse(_selectedField.Value);
                    _compareValue = _rule.ValueMax;
                }

                return true;
            }
        }
        
        protected abstract bool RuleValidation();
    }
}

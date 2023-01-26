using ProductValidation.IoC.Commom;
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
        protected IEnumerable<Field> _fields;
        protected ValidationRuleEntity _rule;
        protected CancellationTokenSource _cts;
        protected Field _selectedField;
        protected object _value;
        protected object _compareValue;

        public bool Validate(IEnumerable<Field> fields, ValidationRuleEntity validationrule, CancellationTokenSource cts)
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
            try
            {
                //verifica se existe o campo para a aplicação da regra
                if (_fields.Where(p => p.key == _rule.Operator.Code).Count() == 0) return false;
                else
                {
                    _selectedField = _fields.Where(p => p.key == _rule.Operator.Code).FirstOrDefault();

                    //get value
                    if (_rule.Operator.IsField_Text)
                    {
                        _value = _selectedField.value;
                        _compareValue = _rule.ValueText;
                    }
                    else if (_rule.Operator.IsField_Date)
                    {
                        if (_selectedField.value == null) _value = null; else _value = DateTime.Parse(_selectedField.value);
                        _compareValue = _rule.ValueDate;
                    }
                    else if (_rule.Operator.IsField_Integer)
                    {
                        if (_selectedField.value == null) _value = null; else _value = int.Parse(_selectedField.value);
                        _compareValue = int.Parse(_rule.ValueText);
                    }
                    else if (_rule.Operator.IsField_Decimal)
                    {
                        if (_selectedField.value == null) _value = null; else _value = float.Parse(_selectedField.value);
                        _compareValue = float.Parse(_rule.ValueText);
                    }
                    else if (_rule.Operator.IsFieldLOV)
                    {
                        _value = _selectedField.value;
                        _compareValue = _rule.ValueSelect;
                    }

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        
        protected abstract bool RuleValidation();
    }
}
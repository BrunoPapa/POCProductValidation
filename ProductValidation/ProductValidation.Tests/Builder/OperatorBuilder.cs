using ProductValidation.IoC.Database;
using System;
using System.Collections.Generic;

namespace ProductValidation.Tests.Builder
{
    public class OperatorBuilder : GenericBuilder<OperatorEntity>
    {
        public OperatorBuilder()
        {
            _instance = new OperatorEntity()
            {
                Id = new Random().Next(99999),
                IsExternal = false,
                IsFieldLOV = false,
                IsFieldRisk = false,
                IsFieldRiskLOV = false,
                IsField_Date = false,
                IsField_Decimal = false,
                IsField_Integer = false,
                IsField_Text = false,
                IsRisk = false,
                Is_Active = true
            };
        }

        public OperatorBuilder WithCode(string code)
        {
            _instance.Code = code;
            return this;
        }

        public OperatorBuilder WithLabel(string label)
        {
            _instance.Label = label;
            return this;
        }

        public OperatorBuilder WithIs_Active(bool is_Active)
        {
            _instance.Is_Active = is_Active;
            return this;
        }
        public OperatorBuilder WithIsFieldLOV(bool isFieldLOV)
        {
            _instance.IsFieldLOV = isFieldLOV;
            return this;
        }

        public OperatorBuilder WithIsField_Integer(bool isField_Integer)
        {
            _instance.IsField_Integer = isField_Integer;
            return this;
        }

        public OperatorBuilder WithIsField_Decimal(bool isField_Decimal)
        {
            _instance.IsField_Decimal = isField_Decimal;
            return this;
        }

        public OperatorBuilder WithIsField_Text(bool isField_Text)
        {
            _instance.IsField_Text = isField_Text;
            return this;
        }

        public OperatorBuilder WithIsField_Date(bool isField_Date)
        {
            _instance.IsField_Date = isField_Date;
            return this;
        }

        public OperatorBuilder WithIsRisk(bool isRisk)
        {
            _instance.IsRisk = isRisk;
            return this;
        }

        public OperatorBuilder WithIsFieldRiskLOV(bool isFieldRiskLOV)
        {
            _instance.IsFieldRiskLOV = isFieldRiskLOV;
            return this;
        }

        public OperatorBuilder WithMessage(string message)
        {
            _instance.Message = message;
            return this;
        }

        public OperatorBuilder WithIsExternal(bool isExternal)
        {
            _instance.IsExternal = isExternal;
            return this;
        }
    }
}
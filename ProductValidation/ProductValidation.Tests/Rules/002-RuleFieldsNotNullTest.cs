using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductValidation.IoC.Database;
using ProductValidation.IoC.Interface.Service;
using ProductValidation.Rules;
using ProductValidation.Tests.Builder;
using System.Collections.Generic;
using System.Threading;

namespace ProductValidation.Tests.Rules
{
    [TestClass]
    public class RuleFieldsNotNullTest : AutoFacResolving
    {
        protected IValidationRuleService _ruleService;
        protected CancellationTokenSource _cts;

        [TestInitialize]
        public void Initialize()
        {
            _cts = new CancellationTokenSource();
            _ruleService = new ruleFieldIsNotNull();            
        }

        
        [TestMethod]
        public void FieldIsTextIsNull()
        {
            List<FieldsContractEntity> fields = new List<FieldsContractEntity>()
            {
                new FieldsContractBuilder().WithFieldProduct(
                    new FieldsProductBuilder()
                    .WithField(new FieldBuilder()
                        .WithName("Name")
                        .WithCode("CLIENT_NAME")
                        .WithType(IoC.Enumerators.FieldType.Text)
                        .Instance())
                    .Instance())
                .WithValue(null)
                .Instance()
            };

            ConfigValidationRuleEntity rule = new ConfigValidationRuleBuilder()
                .WithOperator(new OperatorBuilder()
                    .WithCode("CLIENT_NAME")
                    .WithIsField_Text(true)
                    .WithMessage("Client name is null")
                    .Instance())
                .Instance();


            Assert.IsFalse(_ruleService.Validate(fields, rule, _cts));
        }

        [TestMethod]
        public void FieldIsTextIsNullWithValue()
        {
            List<FieldsContractEntity> fields = new List<FieldsContractEntity>()
            {
                new FieldsContractBuilder().WithFieldProduct(
                    new FieldsProductBuilder()
                    .WithField(new FieldBuilder()
                        .WithName("Name")
                        .WithCode("CLIENT_NAME")
                        .WithType(IoC.Enumerators.FieldType.Text)
                        .Instance())
                    .Instance())
                .WithValue("CLIENT NAME")
                .Instance()
            };

            ConfigValidationRuleEntity rule = new ConfigValidationRuleBuilder()
                .WithOperator(new OperatorBuilder()
                    .WithCode("CLIENT_NAME")
                    .WithIsField_Text(true)
                    .WithMessage("Client name is null")
                    .Instance())
                .Instance();


            Assert.IsTrue(_ruleService.Validate(fields, rule, _cts));
        }

        [TestMethod]
        public void FieldDateIsNull()
        {
            List<FieldsContractEntity> fields = new List<FieldsContractEntity>()
            {
                new FieldsContractBuilder().WithFieldProduct(
                    new FieldsProductBuilder()
                    .WithField(new FieldBuilder()
                        .WithName("Name")
                        .WithCode("CLIENT_BIRTHDAY")
                        .WithType(IoC.Enumerators.FieldType.Date)
                        .Instance())
                    .Instance())
                .WithValue(null)
                .Instance()
            };

            ConfigValidationRuleEntity rule = new ConfigValidationRuleBuilder()
                .WithOperator(new OperatorBuilder()
                    .WithCode("CLIENT_BIRTHDAY")
                    .WithIsField_Date(true)
                    .WithMessage("Client birthday is null")
                    .Instance())
                .Instance();


            Assert.IsFalse(_ruleService.Validate(fields, rule, _cts));
        }

        [TestMethod]
        public void FieldDateIsNullWithValue()
        {
            List<FieldsContractEntity> fields = new List<FieldsContractEntity>()
            {
                new FieldsContractBuilder().WithFieldProduct(
                    new FieldsProductBuilder()
                    .WithField(new FieldBuilder()
                        .WithName("Name")
                        .WithCode("CLIENT_BIRTHDAY")
                        .WithType(IoC.Enumerators.FieldType.Date)
                        .Instance())
                    .Instance())
                .WithValue("01/01/2023")
                .Instance()
            };

            ConfigValidationRuleEntity rule = new ConfigValidationRuleBuilder()
                .WithOperator(new OperatorBuilder()
                    .WithCode("CLIENT_BIRTHDAY")
                    .WithIsField_Date(true)
                    .WithMessage("Client birthday is null")
                    .Instance())
                .Instance();


            Assert.IsTrue(_ruleService.Validate(fields, rule, _cts));
        }
    }
}

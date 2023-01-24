using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductValidation.IoC.Commom;
using ProductValidation.IoC.Database;
using ProductValidation.IoC.Interface.Service;
using ProductValidation.Rules;
using ProductValidation.Tests.Builder;
using System.Collections.Generic;
using System.Threading;

namespace ProductValidation.Tests.Rules
{
    [TestClass]
    public class RuleFieldsFormatTest : AutoFacResolving
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
        [DataRow("Client Name")]        
        public void FieldIsTextFormatIsNotNull(string name)
        {
            List<Field> fields = new List<Field>()
            {
                new FieldBuilder()
                        .WithKey("CLIENT_FORMAT")
                        .WithValue(name)
                .Instance()
            };

            ValidationRuleEntity rule = new ValidationRuleBuilder()
                .WithOperator(new OperatorBuilder()
                    .WithCode("CLIENT_FORMAT")
                    .WithIsField_Text(true)
                    .WithMessage("Client is null")
                    .Instance())
                .Instance();


            Assert.IsTrue(_ruleService.Validate(fields, rule, _cts));
        }

        [TestMethod]
        [DataRow("01/01/2023")]
        [DataRow("31/01/2023")]        
        public void FieldIsDateFormatIsNotNull(string date)
        {
            List<Field> fields = new List<Field>()
            {
                new FieldBuilder()
                        .WithKey("CLIENT_FORMAT")
                        .WithValue(date)
                .Instance()
            };

            ValidationRuleEntity rule = new ValidationRuleBuilder()
                .WithOperator(new OperatorBuilder()
                    .WithCode("CLIENT_FORMAT")
                    .WithIsField_Date(true)
                    .WithMessage("Client is null")
                    .Instance())
                .Instance();


            Assert.IsTrue(_ruleService.Validate(fields, rule, _cts));
        }

        [TestMethod]
        [DataRow("date invalid")]
        [DataRow("01111210")]
        public void FieldIsDateFormatNotValid(string date)
        {
            List<Field> fields = new List<Field>()
            {
                new FieldBuilder()
                        .WithKey("CLIENT_FORMAT")
                        .WithValue(date)
                .Instance()
            };

            ValidationRuleEntity rule = new ValidationRuleBuilder()
                .WithOperator(new OperatorBuilder()
                    .WithCode("CLIENT_FORMAT")
                    .WithIsField_Date(true)
                    .WithMessage("Client is null")
                    .Instance())
                .Instance();


            Assert.IsFalse(_ruleService.Validate(fields, rule, _cts));
        }

        [TestMethod]
        [DataRow("1")]
        [DataRow("100")]
        [DataRow("1000")]
        [DataRow("-100")]
        [DataRow("-1000")]
        public void FieldIsIntFormatIsNotNull(string date)
        {
            List<Field> fields = new List<Field>()
            {
                new FieldBuilder()
                        .WithKey("CLIENT_FORMAT")
                        .WithValue(date)
                .Instance()
            };

            ValidationRuleEntity rule = new ValidationRuleBuilder()
                .WithOperator(new OperatorBuilder()
                    .WithCode("CLIENT_FORMAT")
                    .WithIsField_Integer(true)
                    .WithMessage("Client is null")
                    .Instance())
                .Instance();


            Assert.IsTrue(_ruleService.Validate(fields, rule, _cts));
        }

        [TestMethod]
        [DataRow("test")]
        [DataRow("99999999999999")]
        [DataRow("-99999999999999")]
        [DataRow("1,5")]
        [DataRow("1.5")]
        public void FieldIsIntFormatNotValid(string date)
        {
            List<Field> fields = new List<Field>()
            {
                new FieldBuilder()
                        .WithKey("CLIENT_FORMAT")
                        .WithValue(date)
                .Instance()
            };

            ValidationRuleEntity rule = new ValidationRuleBuilder()
                .WithOperator(new OperatorBuilder()
                    .WithCode("CLIENT_FORMAT")
                    .WithIsField_Integer(true)
                    .WithMessage("Client is null")
                    .Instance())
                .Instance();


            Assert.IsFalse(_ruleService.Validate(fields, rule, _cts));
        }

        [TestMethod]
        [DataRow("1")]
        [DataRow("100")]
        [DataRow("1000")]
        [DataRow("-100")]
        [DataRow("-1000")]
        [DataRow("-1000,1")]
        [DataRow("1000,1")]
        [DataRow("-1000,999")]
        [DataRow("1000,999")]
        public void FieldIsDecimalFormatIsNotNull(string date)
        {
            List<Field> fields = new List<Field>()
            {
                new FieldBuilder()
                        .WithKey("CLIENT_FORMAT")
                        .WithValue(date)
                .Instance()
            };

            ValidationRuleEntity rule = new ValidationRuleBuilder()
                .WithOperator(new OperatorBuilder()
                    .WithCode("CLIENT_FORMAT")
                    .WithIsField_Decimal(true)
                    .WithMessage("Client is null")
                    .Instance())
                .Instance();


            Assert.IsTrue(_ruleService.Validate(fields, rule, _cts));
        }

        [TestMethod]
        [DataRow("test")]
        [DataRow("01/01/2023")]
        public void FieldIsDecimalFormatNotValid(string date)
        {
            List<Field> fields = new List<Field>()
            {
                new FieldBuilder()
                        .WithKey("CLIENT_FORMAT")
                        .WithValue(date)
                .Instance()
            };

            ValidationRuleEntity rule = new ValidationRuleBuilder()
                .WithOperator(new OperatorBuilder()
                    .WithCode("CLIENT_FORMAT")
                    .WithIsField_Decimal(true)
                    .WithMessage("Client is null")
                    .Instance())
                .Instance();


            Assert.IsFalse(_ruleService.Validate(fields, rule, _cts));
        }
    }
}

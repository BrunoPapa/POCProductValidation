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
    public class RuleFieldsNullTest : AutoFacResolving
    {
        protected IValidationRuleService _ruleService;
        protected CancellationTokenSource _cts;

        [TestInitialize]
        public void Initialize()
        {
            _cts = new CancellationTokenSource();
            _ruleService = new ruleFieldIsNull();
            
        }

        
        [TestMethod]
        public void FieldIsTextIsNull()
        {
            List<Field> fields = new List<Field>()
            {
                new FieldBuilder()
                        .WithKey("CLIENT_NAME")
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


            Assert.IsTrue(_ruleService.Validate(fields, rule, _cts));
        }

        [TestMethod]
        public void FieldIsTextIsNullWithValue()
        {
            List<Field> fields = new List<Field>()
            {
                new FieldBuilder()
                        .WithKey("CLIENT_NAME")
                        .WithValue("Client name")
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
        public void FieldDateIsNull()
        {
            List<Field> fields = new List<Field>()
            {
                new FieldBuilder()
                        .WithKey("CLIENT_BIRTHDAY")
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


            Assert.IsTrue(_ruleService.Validate(fields, rule, _cts));
        }

        [TestMethod]
        public void FieldDateIsNullWithValue()
        {
            List<Field> fields = new List<Field>()
            {
                new FieldBuilder()
                        .WithKey("CLIENT_BIRTHDAY")
                        .WithValue("01/01/1990")
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
    }
}

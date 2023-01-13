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
    public class RuleNumberEqValueTest : AutoFacResolving
    {
        protected IValidationRuleService _ruleService;
        protected CancellationTokenSource _cts;

        [TestInitialize]
        public void Initialize()
        {
            _cts = new CancellationTokenSource();
            _ruleService = new ruleNumberEqValue();            
        }

        
        [TestMethod]
        public void FieldIsNumberEqValue()
        {
            List<Field> fields = new List<Field>()
            {
                new FieldBuilder()
                        .WithKey("CLIENT_AGE")
                        .WithValue("38")
                .Instance()
            };

            ConfigValidationRuleEntity rule = new ConfigValidationRuleBuilder()
                .WithOperator(new OperatorBuilder()
                    .WithCode("CLIENT_AGE")
                    .WithIsField_Integer(true)                    
                    .WithMessage("Client equal")
                    .Instance())
                .WithValueMin(38)
                .Instance();

            Assert.IsTrue(_ruleService.Validate(fields, rule, _cts));
        }

        [TestMethod]
        public void FieldIsNumberNotEqValue()
        {
            List<Field> fields = new List<Field>()
            {
                new FieldBuilder()
                        .WithKey("CLIENT_AGE")
                        .WithValue("38")
                .Instance()
            };

            ConfigValidationRuleEntity rule = new ConfigValidationRuleBuilder()
                .WithOperator(new OperatorBuilder()
                    .WithCode("CLIENT_AGE")
                    .WithIsField_Integer(true)
                    .WithMessage("Client equal")
                    .Instance())
                .WithValueMin(37)
                .Instance();

            Assert.IsFalse(_ruleService.Validate(fields, rule, _cts));
        }        
    }
}

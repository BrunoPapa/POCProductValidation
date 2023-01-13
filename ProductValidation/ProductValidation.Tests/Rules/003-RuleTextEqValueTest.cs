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
    public class RuleTextEqValueTest : AutoFacResolving
    {
        protected IValidationRuleService _ruleService;
        protected CancellationTokenSource _cts;

        [TestInitialize]
        public void Initialize()
        {
            _cts = new CancellationTokenSource();
            _ruleService = new ruleTextEqValue();            
        }

        
        [TestMethod]
        public void FieldIsTextEqValue()
        {
            List<Field> fields = new List<Field>()
            {
                new FieldBuilder()
                        .WithKey("CLIENT_NAME")
                        .WithValue("TEST")
                .Instance()
            };

            ConfigValidationRuleEntity rule = new ConfigValidationRuleBuilder()
                .WithOperator(new OperatorBuilder()
                    .WithCode("CLIENT_NAME")
                    .WithIsField_Text(true)                    
                    .WithMessage("Client equal")
                    .Instance())
                .WithValueText("TEST")
                .Instance();

            Assert.IsTrue(_ruleService.Validate(fields, rule, _cts));
        }

        [TestMethod]
        public void FieldIsTextNotEqValue()
        {
            List<Field> fields = new List<Field>()
            {
                new FieldBuilder()
                        .WithKey("CLIENT_NAME")
                        .WithValue("TEST")
                .Instance()
            };

            ConfigValidationRuleEntity rule = new ConfigValidationRuleBuilder()
                .WithOperator(new OperatorBuilder()
                    .WithCode("CLIENT_NAME")
                    .WithIsField_Text(true)
                    .WithMessage("Client equal")
                    .Instance())
                .WithValueText("TEST NOT EQ")
                .Instance();

            Assert.IsFalse(_ruleService.Validate(fields, rule, _cts));
        }        
    }
}

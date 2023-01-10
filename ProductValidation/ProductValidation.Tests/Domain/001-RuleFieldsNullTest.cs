using ProductValidation.IoC.Database;
using ProductValidation.IoC.Interface.Service;
using ProductValidation.Rules;
using ProductValidation.Tests.Builder;
using System.Collections.Generic;
using System.Threading;
using Xunit;

namespace ProductValidation.Tests.Domain
{
    public class RuleFieldsNullTest : AutoFacResolving
    {
        public IValidationRuleService _rule;

        public RuleFieldsNullTest() : base()
        {
            _rule = new ruleFieldIsNull();
        }

        [Fact]
        public void FieldIsNull()
        {
            List<FieldsContractEntity> fields = new List<FieldsContractEntity>()
            {
                new FieldsContractBuilder().WithFieldProduct(
                    new FieldsProductBuilder()
                    .WithField(new FieldBuilder()
                        .WithName("Name")
                        .WithCode("CLIENT_NAME")
                        .WithType(IoC.Enumerators.FieldType.Text)
                        .Instance()
                    ).Instance()
                ).Instance()
            };

            ConfigValidationRuleEntity rule = new ConfigValidationRuleBuilder()
                .WithBaseValidation(
                    new BaseValidationBuilder()
                    .WithConfigValidationMessages(new List<ConfigValidationMessageEntity> {
                        new ConfigValidationMessageBuilder()
                        .WithMessage("Erro de validação do cliente")
                        .WithLanguageId(1)
                        .Instance()
                    }).Instance()
                ).Instance();
                

            var cts = new CancellationTokenSource();

            _rule.Validate(fields, rule, cts);
        }
    }
}

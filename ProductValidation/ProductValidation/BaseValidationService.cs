using ProductValidation.IoC.Commom;
using ProductValidation.IoC.Database;
using ProductValidation.IoC.Interface.Service;
using ProductValidation.Rules;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProductValidation
{
    public class BaseValidationService : IBaseValidationService
    {
        public async Task<IEnumerable<ValidationMessageRule>> Validate(IEnumerable<Field> fields, ValidationEntity validation, CancellationTokenSource cts, bool multipleErrors)
        {
            List<Task> tasks = new List<Task>();
            List<ValidationMessageRule> validationMessageRules = new List<ValidationMessageRule>();

            validation.ValidationRule.ToList().ForEach(
                p =>
                    tasks.Add(Task.Run(async () => {
                        if (!factoryRule(p.RuleTypeId).Validate(fields, p, cts))
                        {
                            validationMessageRules.Add(new ValidationMessageRule()
                            {
                                RuleTypeId = p.RuleTypeId,
                                Code = p.Operator.Code,
                                Message = p.Operator.Message,
                                Severity = validation.SeverityId
                            });

                            if (!multipleErrors)
                                cts.Cancel();
                        }

                        return Task.CompletedTask;
                    }
                    ))
            );

            while (tasks.Count > 0)
            {
                var finishedTask = await Task.WhenAny(tasks);
                tasks.Remove(finishedTask);

                if (finishedTask.Status == TaskStatus.Faulted && multipleErrors == false)
                    cts.Cancel();
            }

            return validationMessageRules;
        }

        private IValidationRuleService factoryRule(int idRule)
        { 
            switch (idRule)
            {
                case 1: return new ruleFieldIsNull();
                case 2: return new ruleFieldIsNotNull();
                case 3: return new ruleTextEqValue();
                case 4: return new ruleTextNotEqValue();
                case 5: return new ruleNumberEqValue();
                case 6: return new ruleNumberNotEqValue();
                case 7: return new ruleDateNotEqValue();
                case 8: return new ruleDateNotEqValue();
                case 9: return new ruleLOVEqValue();
                case 10: return new ruleLOVNotEqValue();
                case 11: return new ruleLOVInValue();
                case 12: return new ruleLOVNotInValue();
                case 13: return new ruleNumberGreaterValue();
                case 14: return new ruleNumberGreaterOrEqualValue();
                case 15: return new ruleNumberLesserValue();
                case 16: return new ruleNumberLesserOrEqualValue();
                case 17: return new ruleNumberBetweenMaxandMin();
                case 18: return new ruleNumberNotBetweenMaxandMin();
                case 19: return new ruleNumberHasDecimalPart();
                case 20: return new ruleDateGreaterValue();
                case 21: return new ruleDateGreaterOrEqualValue();
                case 22: return new ruleDateLesserValue();
                case 23: return new ruleDateLesserOrEqualValue();
                default: return null;
            }
        }
    }
}

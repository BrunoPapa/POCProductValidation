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
        public async Task<IEnumerable<ValidationMessage>> Validate(ContractEntity contract, BaseValidationEntity validation, CancellationTokenSource cts, bool multipleErrors)
        {
            List<Task> tasks = new List<Task>();
            List<ValidationMessage> validationMessages = new List<ValidationMessage>();

            validation.ConfigValidationRules.ToList().ForEach(
                p => 
                    tasks.Add(Task.Run(async () => {
                        if (!factoryRule(p.Id).Validate(contract.Fields, p, cts))
                        { 
                            validationMessages.Add(new ValidationMessage()
                            {
                                ConfigValidationRule = p,
                                Message = validation.ConfigValidationMessages.FirstOrDefault().Message,
                                MultipleErrors = multipleErrors,
                                Severity = p.Severity
                            });

                            if (!multipleErrors)
                                cts.Cancel();
                        }
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

            return validationMessages;
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
                default: return null;
            }
        }
    }
}

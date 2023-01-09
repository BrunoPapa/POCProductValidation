﻿using ProductValidation.IoC.Commom;
using ProductValidation.IoC.Database;
using System.Collections.Generic;
using System.Threading;

namespace ProductValidation.IoC.Interface.Service
{
    public interface IValidationRuleService
    {
        bool Validate(IEnumerable<FieldsContractEntity> fields, ConfigValidationRuleEntity validationrule, CancellationTokenSource cts);
    }
}

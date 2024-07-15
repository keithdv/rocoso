﻿using Rocoso.Rules;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rocoso.UnitTest.Example.SimpleValidate
{
    public interface IShortNameRule : IRule<ISimpleValidateObject> { }

    internal class ShortNameRule : RuleBase<ISimpleValidateObject>, IShortNameRule
    {
        public ShortNameRule() : base()
        {
            TriggerProperties.Add(nameof(ISimpleValidateObject.FirstName));
            TriggerProperties.Add(nameof(ISimpleValidateObject.LastName));
        }

        public override IRuleResult Execute(ISimpleValidateObject target)
        {

            var result = RuleResult.Empty();

            if (string.IsNullOrWhiteSpace(target.FirstName))
            {
                result.AddPropertyError(nameof(ISimpleValidateObject.FirstName), $"{nameof(ISimpleValidateObject.FirstName)} is required.");
            }

            if (string.IsNullOrWhiteSpace(target.LastName))
            {
                result.AddPropertyError(nameof(ISimpleValidateObject.LastName), $"{nameof(ISimpleValidateObject.LastName)} is required.");
            }

            if (!result.IsError)
            {
                target.ShortName = $"{target.FirstName} {target.LastName}";
            }
            else
            {
                target.ShortName = string.Empty;
            }

            return result;
        }

    }
}

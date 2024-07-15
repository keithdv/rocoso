using Rocoso.AuthorizationRules;
using Rocoso.Core;
using Rocoso.Portal;
using Rocoso.Rules;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rocoso
{
    /// <summary>
    /// Wrap the RocosoBase services into an interface so that 
    /// the inheriting classes don't need to list all services
    /// and services can be added
    /// </summary>
    public interface IValidateBaseServices<T> : IBaseServices<T>
        where T : ValidateBase<T>
    {
        IValidatePropertyValueManager<T> ValidatePropertyValueManager { get; }

        IRuleManager<T> RuleManager { get; }

    }


    public class ValidateBaseServices<T> : BaseServices<T>, IValidateBaseServices<T>
        where T : ValidateBase<T>
    {

        public ValidateBaseServices(IValidatePropertyValueManager<T> registeredPropertyValueManager, IRegisteredPropertyManager<T> registeredPropertyManager, IRuleManager<T> ruleManager)
            : base(registeredPropertyValueManager, registeredPropertyManager)
        {
            this.ValidatePropertyValueManager = registeredPropertyValueManager;
            RuleManager = ruleManager;

        }

        public IValidatePropertyValueManager<T> ValidatePropertyValueManager { get; }
        public IRuleManager<T> RuleManager { get; }

        IPropertyValueManager<T> IBaseServices<T>.PropertyValueManager
        {
            get { return ValidatePropertyValueManager; }
        }

    }
}

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
    public interface IValidateListBaseServices<T, I> : IListBaseServices<T, I>
        where T : ValidateListBase<T, I>
        where I : IValidateBase
    {
        IValidatePropertyValueManager<T> ValidatePropertyValueManager { get; }
        IRuleManager<T> RuleManager { get; }

    }



    public class ValidateListBaseServices<T, I> : ListBaseServices<T, I>, IValidateListBaseServices<T, I>
        where T : ValidateListBase<T, I>
        where I : IValidateBase
    {

        public ValidateListBaseServices(IValidatePropertyValueManager<T> registeredPropertyManager,
            IReceivePortalChild<I> portal,
            IRuleManager<T> ruleManager) : base(registeredPropertyManager, portal)
        {
            this.ValidatePropertyValueManager = registeredPropertyManager;
            RuleManager = ruleManager;
        }

        public IValidatePropertyValueManager<T> ValidatePropertyValueManager { get; }
        public IRuleManager<T> RuleManager { get; }

        IPropertyValueManager<T> IListBaseServices<T, I>.PropertyValueManager
        {
            get { return ValidatePropertyValueManager; }
        }


    }
}

﻿using Rocoso.AuthorizationRules;
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
    /// REGISTERED IN DI CONTAINER
    /// </summary>
    public interface IEditBaseServices<T> : IValidateBaseServices<T>
        where T : EditBase<T>
    {

        IEditPropertyValueManager<T> EditPropertyValueManager { get; }
        ISendReceivePortal<T> SendReceivePortal { get; }
    }

    public class EditBaseServices<T> : ValidateBaseServices<T>, IEditBaseServices<T>
        where T : EditBase<T>
    {

        public IEditPropertyValueManager<T> EditPropertyValueManager { get; }
        public ISendReceivePortal<T> SendReceivePortal { get; }

        public EditBaseServices(IEditPropertyValueManager<T> registeredPropertyValueManager, IRegisteredPropertyManager<T> registeredPropertyManager, IRuleManager<T> ruleManager, ISendReceivePortal<T> sendReceivePortal)
            : base(registeredPropertyValueManager, registeredPropertyManager, ruleManager)
        {
            EditPropertyValueManager = registeredPropertyValueManager;
            SendReceivePortal = sendReceivePortal;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace Rocoso.Portal
{

    public interface IPortalOperationManager
    {
        void RegisterOperation(PortalOperation operation, string methodName);
        void RegisterOperation(PortalOperation operation, MethodInfo method);
        Task<bool> TryCallOperation(IPortalTarget target, PortalOperation operation);
        Task<bool> TryCallOperation(IPortalTarget target, PortalOperation operation, object[] criteria, Type[] criteriaTypes);
    }
    public interface IPortalOperationManager<T> : IPortalOperationManager
    {


    }
}
﻿using System;
using System.Collections.Generic;

namespace Rocoso
{

    /// <summary>
    /// DO NOT REGISTER IN DI CONTAINER
    /// </summary>
    /// <typeparam name="T">Generic to ensure that types can only access their properties</typeparam>
    public interface IRegisteredPropertyManager
    {
        IRegisteredProperty<P> GetRegisteredProperty<P>(string name);
        IRegisteredProperty GetRegisteredProperty(string name);
        IEnumerable<IRegisteredProperty> GetRegisteredProperties();
    }

    /// <summary>
    /// REGISTERED IN THE DI CONTAINER
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRegisteredPropertyManager<T> : IRegisteredPropertyManager
    {

    }
}

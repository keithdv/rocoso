using System;
using System.Reflection;

namespace Rocoso
{
    public interface IRegisteredProperty
    {
        PropertyInfo PropertyInfo { get; }
        string Name { get; }
        Type Type { get; }
        string Key { get; }
        uint Index { get; }
    }

    public interface IRegisteredProperty<T> : IRegisteredProperty
    {

    }
}
using System;

namespace AzureFunction.DI
{
    public interface IContainer
    {
        T Resolve<T>() where T : class;
        object Resolve(Type type);
    }
}
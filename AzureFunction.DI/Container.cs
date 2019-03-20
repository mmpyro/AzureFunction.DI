using System;

/// <summary>
/// 
/// </summary>
namespace AzureFunction.DI
{
    public class Container : IContainer
    {
        private readonly IServiceProvider _serviceProvider;

        public Container(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public T Resolve<T>() where T:class
        {
            var instance = _serviceProvider.GetService(typeof(T)) as T;
            ThrowWhenUnableToResolve(instance, typeof(T));
            return instance;
        }

        public object Resolve(Type type)
        {
            var instance = _serviceProvider.GetService(type);
            ThrowWhenUnableToResolve(instance, type);
            return instance;
        }

        private void ThrowWhenUnableToResolve(object instance, Type type)
        {
            if(instance == null)
            {
                throw new ArgumentException($"Unable to resolve {type.Name}.");
            }
        }
    }
}
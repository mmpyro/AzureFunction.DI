using Microsoft.Extensions.DependencyInjection;

namespace AzureFunction.DI
{
    public class ContainerBuilder : IContainerBuilder
    {
        private readonly IServiceCollection _services;

        public ContainerBuilder()
        {
            _services = new ServiceCollection();
        }

        public IContainerBuilder AddModule(IModule module)
        {
            module.Load(_services);
            return this;
        }

        public IContainer Build()
        {
            var provider = _services.BuildServiceProvider();
            return new Container(provider);
        }

        public IContainerBuilder AddTranscient<T, U>() where T : class where U : class, T
        {
            _services.AddTransient<T, U>();
            return this;
        }

        public IContainerBuilder AddSingleton<T, U>() where T : class where U : class, T
        {
            _services.AddSingleton<T, U>();
            return this;
        }

        public IContainerBuilder AddScoped<T, U>() where T : class where U : class, T
        {
            _services.AddScoped<T, U>();
            return this;
        }

        public IContainerBuilder AddInstance<T>(T instance) where T : class
        {
            _services.AddSingleton(instance);
            return this;
        }

    }
}
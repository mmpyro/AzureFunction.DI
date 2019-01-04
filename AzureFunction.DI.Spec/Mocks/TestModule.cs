using Microsoft.Extensions.DependencyInjection;

namespace AzureFunction.DI.Spec.Mocks
{
    public class TestModule : IModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddTransient<ILogger, ConsoleLogger>();
        }
    }
}
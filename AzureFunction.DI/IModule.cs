using Microsoft.Extensions.DependencyInjection;

namespace AzureFunction.DI
{
    public interface IModule
    {
        void Load(IServiceCollection services);
    }
}
using Microsoft.Extensions.DependencyInjection;

namespace AzureFunction.DI
{
    /// <summary>
    /// 
    /// </summary>
    public interface IModule
    {
        void Load(IServiceCollection services);
    }
}
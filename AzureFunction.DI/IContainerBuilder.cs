namespace AzureFunction.DI
{
    public interface IContainerBuilder
    {
        IContainerBuilder AddTranscient<T, U>() where T : class where U : class, T;
        IContainerBuilder AddSingleton<T, U>() where T : class where U : class, T;
        IContainerBuilder AddScoped<T, U>() where T : class where U : class, T;
        IContainerBuilder AddInstance<T>(T instance) where T : class;
        IContainerBuilder AddModule(IModule module);
        IContainer Build();
    }
}
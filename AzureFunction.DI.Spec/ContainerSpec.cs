using System;
using System.Threading.Tasks;
using AzureFunction.DI.Spec.Mocks;
using Xunit;

namespace AzureFunction.DI.Spec
{
    public class ContainerSpec
    {
        /// <summary>
        /// vjl;kv;lk;lv;lkfd;lvkkfdv;lk
        /// </summary>
        [Fact]
        public void ShouldResolveRegisteredInstanceWhenGenericResolveCalled()
        {
            //Given
            ILogger logger = new ConsoleLogger();
            var container = new ContainerBuilder()
                                .AddInstance(logger).
                                Build();

            //When
            var resolvedLogger = container.Resolve<ILogger>();

            //Then
            Assert.Equal(typeof(ConsoleLogger), resolvedLogger.GetType());
        }

        [Fact]
        public void ShouldResolveRegisteredInstanceWhenResolveCalled()
        {
            //Given
            ILogger logger = new ConsoleLogger();
            var container = new ContainerBuilder()
                                .AddInstance(logger).
                                Build();

            //When
            var resolvedLogger = container.Resolve(typeof(ILogger)) as ConsoleLogger;

            //Then
            Assert.NotNull(resolvedLogger);
            Assert.Equal(typeof(ConsoleLogger), resolvedLogger.GetType());
        }

        [Fact]
        public void ShouldResolveRegisteredSingletonObject()
        {
            //Given
            var container = new ContainerBuilder()
                                .AddSingleton<ILogger, ConsoleLogger>()
                                .Build();

            //When
            var firstInstance = container.Resolve<ILogger>();
            var secondInstance = container.Resolve<ILogger>();

            //Then
            Assert.Equal(firstInstance, secondInstance);
        }

        [Fact]
        public void ShouldResolveRegisteredTranscientObject()
        {
            //Given
            var container = new ContainerBuilder()
                                .AddTranscient<ILogger, ConsoleLogger>()
                                .Build();

            //When
            var firstInstance = container.Resolve<ILogger>();
            var secondInstance = container.Resolve<ILogger>();

            //Then
            Assert.NotEqual(firstInstance, secondInstance);
        }

        [Fact]
        public void ShouldResolveRegisteredScopedObject()
        {
            //Given
            var container = new ContainerBuilder()
                                .AddScoped<ILogger, ConsoleLogger>()
                                .Build();

            //When
            var firstInstance = container.Resolve<ILogger>();
            var secondInstance = container.Resolve<ILogger>();

            //Then
            Assert.Equal(firstInstance, secondInstance);
        }

        [Fact]
        public void ShouldResolveRegisteredObjectInModule()
        {
            //Given
            var container = new ContainerBuilder()
                                .AddModule(new TestModule())
                                .Build();

            //When
            var resolvedLogger = container.Resolve<ILogger>();

            //Then
            Assert.Equal(typeof(ConsoleLogger), resolvedLogger.GetType());
        }

        [Fact]
        public void ShouldThrowExceptionWhenResolveUnregisteredObject()
        {
            //Given
            var container = new ContainerBuilder().Build();

            //When
            var ex = Assert.Throws<ArgumentException>( () => container.Resolve<ILogger>());

            //Then
            Assert.Equal(ex.Message, $"Unable to resolve {nameof(ILogger)}.");
        }
    }
}
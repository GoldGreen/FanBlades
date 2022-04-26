using Microsoft.Extensions.Configuration;
using Prism.Ioc;
using Prism.Modularity;
using Serilog;

namespace FanBlades.Shared
{
    public class SharedModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<ILogger>(LoggerFactory);
        }

        private ILogger LoggerFactory(IContainerProvider containerProvider)
        {
            return new LoggerConfiguration()
                    .ReadFrom.Configuration(containerProvider.Resolve<IConfiguration>())
                    .CreateLogger();
        }
    }
}

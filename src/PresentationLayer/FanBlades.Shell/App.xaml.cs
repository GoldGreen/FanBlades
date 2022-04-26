using FanBlades.Detection;
using FanBlades.Shared;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using System.Windows;

namespace FanBlades.Shell
{
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<BusinessLayerModule>()
                         .AddModule<SharedModule>()
                         .AddModule<DetectionModule>();

            base.ConfigureModuleCatalog(moduleCatalog);
        }
    }
}

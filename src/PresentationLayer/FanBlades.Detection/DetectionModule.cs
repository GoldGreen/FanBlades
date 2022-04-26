using FanBlades.Detection.Models.Abstraction;
using FanBlades.Detection.Models.Implementation;
using FanBlades.Detection.ViewModels;
using FanBlades.Detection.Views;
using FanBlades.Shared.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;

namespace FanBlades.Detection
{
    public class DetectionModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            containerProvider.Resolve<IRegionManager>()
                             .RegisterViewWithRegion<DetectionControl>(GlobalRegions.DetectionRegion);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IDetectionModel, DetectionModel>();

            ViewModelLocationProvider.Register<DetectionControl, DetectionViewModel>();
        }
    }
}

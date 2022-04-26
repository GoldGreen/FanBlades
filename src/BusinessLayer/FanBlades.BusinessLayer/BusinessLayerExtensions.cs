using Alturos.Yolo;
using FanBlades.BusinessLayer.Abstraction;
using FanBlades.BusinessLayer.Configuration;
using FanBlades.BusinessLayer.Extensions;
using FanBlades.BusinessLayer.Implementation;
using Prism.Ioc;

namespace FanBlades.BusinessLayer
{
    public static class BusinessLayerExtensions
    {
        public static IContainerRegistry AddBusinessLayer(this IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterConfiguration();
            containerRegistry.RegisterOption<DetectorOption>(nameof(DetectorOption.Detector));

            containerRegistry.RegisterSingleton<YoloWrapper>(NetFactory);
            containerRegistry.RegisterSingleton<IDetector, Detector>();

            return containerRegistry;
        }

        public static YoloWrapper NetFactory(IContainerProvider containerProvider)
        {
            var detectorOption = containerProvider.Resolve<DetectorOption>();
            return new(detectorOption.ConfigPath, detectorOption.WeightPath, detectorOption.ClassesPath);
        }
    }
}

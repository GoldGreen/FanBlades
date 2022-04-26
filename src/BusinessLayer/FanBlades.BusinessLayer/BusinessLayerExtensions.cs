using Prism.Ioc;

namespace FanBlades.BusinessLayer
{
    public static class BusinessLayerExtensions
    {
        public static IContainerRegistry AddBusinessLayer(this IContainerRegistry containerRegistry)
        {
            return containerRegistry;
        }
    }
}

using FanBlades.BusinessLayer;
using Prism.Ioc;
using Prism.Modularity;

namespace FanBlades.Shared
{
    public class BusinessLayerModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.AddBusinessLayer();
        }
    }
}

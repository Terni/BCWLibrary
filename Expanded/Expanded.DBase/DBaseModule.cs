using Prism.Modularity;
using Prism.Regions;
using System;

namespace Expanded.DBase
{
    public class DBaseModule : IModule
    {
        IRegionManager _regionManager;

        public DBaseModule(RegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }
    }
}
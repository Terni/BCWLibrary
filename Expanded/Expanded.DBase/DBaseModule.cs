using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prism.Modularity;
using Microsoft.Practices.Unity;
using Prism.Unity;
using Xamarin.Forms;

namespace Expanded.DBase
{
    public class DBaseModule : IModule
    {

        readonly IUnityContainer _container;

        public DBaseModule(IUnityContainer con)
        {
            _container = con;
        }


        public void Initialize()
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prism.Modularity;
using Microsoft.Practices.Unity;
using Prism.Unity;
using Xamarin.Forms;

namespace BitcoinWallet.Layers
{
    public class Layers : IModule
	{

        readonly IUnityContainer _container;

	    public Layers(IUnityContainer con)
	    {
            _container = con;
	    }

        public void Initialize()
        {
            throw new NotImplementedException();
        }
    }
}

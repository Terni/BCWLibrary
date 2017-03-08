using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Xml.Linq;
using Java.IO;


namespace BitcoinWallet.Core
{
    public class DataSyntFromXml
    {
        private List<Wallet> _rawWallets = null;
        private List<Module> _rawModules = null;
        private XDocument _doc;

        public DataSyntFromXml(XDocument doc)
        {
            _doc = doc;
        }

        private async void LoadXMLData()
        {

            await Task.Factory.StartNew(delegate {
                IEnumerable<Wallet> wallets = from x in _doc.Descendants("wallet")
                    select new Wallet
                    {
                        Number = Convert.ToInt32(x.Attribute("number").Value)
                    };
                _rawWallets = wallets.ToList();

                IEnumerable<Module> modules = from s in _doc.Descendants("module")
                    select new Module
                    {
                        Name = s.Attribute("name").Value,
                        Value = s.Attribute("value").Value,
                        Visible = Convert.ToBoolean(s.Attribute("visible").Value),
                        Enable = Convert.ToBoolean(s.Attribute("enable").Value),
                        Secure = Convert.ToBoolean(s.Attribute("secure").Value)
                    };
                _rawModules = modules.ToList();
            });
        }


        public List<Wallet> RawWallets
        {
            get { return _rawWallets; }
            set { _rawWallets = value; }
        }

        public List<Module> RawModules
        {
            get { return _rawModules; }
            set { _rawModules = value; }
        }
    }
}

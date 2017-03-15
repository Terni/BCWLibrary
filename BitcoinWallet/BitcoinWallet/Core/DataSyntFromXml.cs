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
        private List<Modules> _rawModules = null;
        private XDocument _doc;

        public DataSyntFromXml(XDocument doc)
        {
            _doc = doc;
            _rawModules = new List<Modules>();
            LoadXMLData();
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

                //IEnumerable<Modules> smallModules = from s in _doc.Descendants("module")
                //    select new Modules
                //    {
                //        Name = s.Attribute("name").Value,
                //        Value = s.Attribute("value").Value,
                //        Visible = Convert.ToBoolean(s.Attribute("visible").Value),
                //        Enable = Convert.ToBoolean(s.Attribute("enable").Value),
                //        Secure = Convert.ToBoolean(s.Attribute("secure").Value)
                //    };
                //_rawModules = smallModules.ToList();

                foreach (var x in _doc.Descendants("module"))
                {
                    Modules item = new Modules();
                    item.Name = x.Attribute("name").Value;
                    item.Value = GetAttributeString(x, "value");
                    item.Visible = GetAttributeBool(x, "visible");
                    item.Enable = GetAttributeBool(x, "enable");
                    item.Secure = GetAttributeBool(x, "secure");
                    _rawModules.Add(item);
                }
            });
        }

        private string GetAttributeString(XElement x, string name)
        {
            XAttribute item;
            if ((item = x.Attribute(name)) != null)
            {
                return item.Value;
            }
            return string.Empty;
        }

        private bool GetAttributeBool(XElement x, string name)
        {
            XAttribute item;
            if ((item = x.Attribute(name)) != null)
            {
                if(item.Value != string.Empty)
                    return Convert.ToBoolean(item.Value);
            }
            return false;
        }


        public List<Wallet> RawWallets
        {
            get { return _rawWallets; }
            set { _rawWallets = value; }
        }

        public List<Modules> RawModules
        {
            get { return _rawModules; }
            set { _rawModules = value; }
        }
    }
}

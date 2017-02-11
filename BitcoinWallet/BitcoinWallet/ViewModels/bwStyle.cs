using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xamarin.Forms;

namespace BitcoinWallet.ViewModels
{

    //Ctrl-M, Ctrl-O will collapse all of the code to its definitions.
    //Ctrl-M, Ctrl-L will expand all of the code (actually, this one toggles it).
    //Ctrl-M, Ctrl-M will expand or collapse a single region

    public class BwStyle
    {
        #region  Constructor
        /// <summary>
        /// Constructor bwStyle
        /// </summary>
        public BwStyle()
        {
            var LabelStyle = new Style(typeof(Label))
            {
                Setters = {
                    new Setter {Property = Label.TextColorProperty, Value = Color.Red},
                    new Setter {Property = Label.FontSizeProperty, Value = 30}
                }
            };


            //Label.StyleProperty = Device.Styles.TitleStyle;
        }
        #endregion

    }
}

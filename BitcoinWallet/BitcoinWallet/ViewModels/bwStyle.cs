using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xamarin.Forms;

namespace BitcoinWallet.ViewModels
{
    public class bwStyle
    {
        #region Constructor
        /// <summary>
        /// Constructor bwStyle
        /// </summary>
        public bwStyle()
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

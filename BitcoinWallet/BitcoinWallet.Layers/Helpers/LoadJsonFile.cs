using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinWallet.Layers.Helpers
{
    public class LoadJsonFile
    {
        private Stream streams;

        /// <summary>
        /// Method loading file form Embedded resources
        /// </summary>
        public LoadJsonFile()
        {
            //Attention: Embedded files will by must in Project file in syntax:
            //< ItemGroup >
            // < EmbeddedResource Include = "MapPins.json" />
            //</ ItemGroup >

            #region Load file.json from embedded resource
            Assembly assembly = typeof(LoadJsonFile).GetTypeInfo().Assembly;
            Streams = assembly.GetManifestResourceStream("BitcoinWallet.Layers.Resources.MapPins.json");

            //TEST: Load all Embedded resources
            //foreach (var test in assembly.GetManifestResourceNames()){}
            #endregion

        }

        public Stream Streams
        {
            get
            {
                return streams;
            }

            set
            {
                streams = value;
            }
        }
    }

}

using System;
using Xamarin.Forms;
using System.Reflection;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using Xamarin.Forms.Xaml;

namespace BitcoinWallet
{
    public class LoadXmlFile
    {
        private Stream streams;


        public LoadXmlFile()
        {
            //Attention: Embedded files will by must in Project file in syntax:
            //< ItemGroup >
            // < EmbeddedResource Include = "LoginConfig.xml" />
            // < EmbeddedResource Include = "README.txt" />
            //</ ItemGroup >

            #region How to load an XML file embedded resource
            Assembly assembly = typeof(LoadXmlFile).GetTypeInfo().Assembly;
            Streams = assembly.GetManifestResourceStream("BitcoinWallet.LoginConfig.xml");

            //TEST: Load all Embedded resources
            foreach (var test in assembly.GetManifestResourceNames())
            {

            }
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
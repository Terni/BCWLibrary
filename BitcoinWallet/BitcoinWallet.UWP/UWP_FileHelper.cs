using System.IO;
using Xamarin.Forms;
using BitcoinWallet.UWP;
using Windows.Storage;
using BitcoinWallet.Interface;

[assembly: Dependency(typeof(UWP_FileHelper))]
namespace BitcoinWallet.UWP
{
    public class UWP_FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
        }
    }
}

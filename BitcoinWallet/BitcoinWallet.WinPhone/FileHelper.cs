using System.IO;
using Xamarin.Forms;
using BitcoinWallet.UWP;
using Windows.Storage;
using BitcoinWallet.Interface;

[assembly: Dependency(typeof(FileHelper))]
namespace BitcoinWallet.UWP
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
        }
    }
}

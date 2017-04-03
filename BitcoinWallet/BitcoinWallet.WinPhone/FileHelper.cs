using System.IO;
using Xamarin.Forms;
using BitcoinWallet.WinPhone;
using Windows.Storage;
using BitcoinWallet.Interface;

[assembly: Dependency(typeof(FileHelper))]
namespace BitcoinWallet.WinPhone
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
        }
    }
}

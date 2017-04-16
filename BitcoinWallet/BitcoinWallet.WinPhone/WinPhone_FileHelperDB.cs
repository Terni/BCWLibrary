using System.IO;
using Xamarin.Forms;
using BitcoinWallet.WinPhone;
using Windows.Storage;
using BitcoinWallet.Interface;

[assembly: Dependency(typeof(WinPhone_FileHelperDB))]
namespace BitcoinWallet.WinPhone
{
    public class WinPhone_FileHelperDB : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
        }
    }
}

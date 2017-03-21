using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinWallet.Helpers
{
    public enum NameModule
    {
        Alias = 0,
        LoginID = 1,
        PasswordFirst = 2,
        PasswordSecond = 3,
        api_code = 4,
        autologon = 5,
        Theme = 6
    }



    public static class NameModuleEnum
    {
        public static Dictionary<string, NameModule> Name = new Dictionary<string, NameModule>
        {
            {"Alias",NameModule.Alias},
            {"LoginID",NameModule.LoginID},
            {"PasswordFirst",NameModule.PasswordFirst},
            {"PasswordSecond",NameModule.PasswordSecond},
            {"api_code", NameModule.api_code},
            {"autologon",NameModule.autologon},
            {"Theme",NameModule.Theme }
        };
    }
}

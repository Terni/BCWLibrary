using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinWallet.Helpers
{
    enum NameModule
    {
        Alias,
        LoginID,
        PasswordFirst,
        PasswordSecound,
        api_code,
        autologon,
        Theme
    }
    
    

    public static class NameModuleEnum
    {
        public static Dictionary<string, int> Name = new Dictionary<string, int>
        {
            {"Alias",0},
            {"LoginID",1},
            {"PasswordFirst",2},
            {"PasswordSecound",3},
            {"api_code",4},
            {"autologon",5},
            {"Theme",6 }
        };


        //public static Dictionary<int, string> Name = new Dictionary<int, string>
        //{
        //    {0,"Alias"},
        //    {1,"LoginID"},
        //    {2,"PasswordFirst"},
        //    {3,"PasswordSecound"},
        //    {4,"api_code"},
        //    {5,"autologon"},
        //    {6,"Theme" }
        //};
    }
}

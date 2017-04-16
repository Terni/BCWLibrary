using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

//<module name = "Alias" value="bitcoinwallet" visible="false"/>
//<module name = "LoginID" value="1393dcec-2f1d-45f3-8055-a304636dce13" visible="true" secure="false" enable="true"/>
//<module name = "PasswordFirst" value="roUKOMO100887" visible="true" secure="true" enable="true"/>
//<module name = "PasswordSecound" value="ro1008UKOMO1987" visible="false" secure="true" />
//<module name = "api_code" value="12345" visible="false"/>
//<module name = "autologon" enable="false"/>
//<module name = "Theme" value="Light" />


namespace Expanded.DBase.Models
{
    public class SettingItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Value { get; set; }
        public bool Visible { get; set; }
        public bool Secure { get; set; }
        public bool Enable { get; set; }
    }
}

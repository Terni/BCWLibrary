using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Expanded.DBase.Models
{
    public class ContactItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(30)]
        public string FirstName { get; set; }
        [MaxLength(30)]
        public string LastName { get; set; }
        [MaxLength(30)]
        public string Alias { get; set; }
        [MaxLength(50)]
        public string IdWallet { get; set; }
        public DateTime Time { get; set; }
    }
}

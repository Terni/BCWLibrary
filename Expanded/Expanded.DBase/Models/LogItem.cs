﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Expanded.DBase.Models
{
    public class LogItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        [MaxLength(30)]
        public string Platform { get; set; }
        [MaxLength(50)]
        public string Class { get; set; }
        [MaxLength(30)]
        public string Method { get; set; }
        public int Line { get; set; }
    }
}

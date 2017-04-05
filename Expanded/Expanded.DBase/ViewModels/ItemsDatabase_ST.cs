using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Expanded.DBase.Models;
using SQLite;

namespace Expanded.DBase.ViewModels
{
    public static class ItemsDatabase_ST
    {
        /// <summary>
        /// Variables
        /// </summary>
        static SQLiteAsyncConnection _database;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbPath">Specific path into file database</param>
        static ItemsDatabase_ST()
        {
            _database = null;
        }


        public static SQLiteAsyncConnection DatabaseString
        {
            get
            {
                return _database;
            }
            set
            {
                _database = value;
            }
        }



    }
}

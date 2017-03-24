using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Expanded.DBase.Models;
using SQLite;

namespace Expanded.DBase.ViewModels
{
    public static class ItemsDatabase
    {
        /// <summary>
        /// Variables
        /// </summary>
        readonly static SQLiteAsyncConnection _database;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbPath">Specific path into file database</param>
        static ItemsDatabase()
        {
            string dbPath = " "; // TODO doplnit !!
            _database = new SQLiteAsyncConnection(dbPath);
            InitializationDB();
        }

        /// <summary>
        /// Method for init Database
        /// </summary>
        private static void InitializationDB()
        {
            _database.CreateTableAsync<ContactItem>().Wait();
            _database.CreateTableAsync<LogItem>().Wait();
            _database.CreateTableAsync<SettingItem>().Wait();
        }

        public static SQLiteAsyncConnection DatabaseString
        {
            get
            {
                return _database;
            }
            //set
            //{
            //    _database = value;
            //}
        }



    }
}

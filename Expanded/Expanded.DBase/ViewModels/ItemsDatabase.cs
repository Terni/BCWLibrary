using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Expanded.DBase.Models;
using SQLite;

namespace Expanded.DBase.ViewModels
{
    public class ItemsDatabase
    {
        /// <summary>
        /// Variables
        /// </summary>
        readonly SQLiteAsyncConnection _database;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbPath">Specific path into file database</param>
        public ItemsDatabase(string dbPath)
        {
            //string dbPath = " "; // TODO doplnit !!
            _database = new SQLiteAsyncConnection(dbPath);
            ItemsDatabase_ST.DatabaseString = _database; // set static class
            InitializationDB();
        }

        /// <summary>
        /// Method for init Database
        /// </summary>
        private void InitializationDB()
        {
            _database.CreateTableAsync<ContactItem>();
            _database.CreateTableAsync<LogItem>();
            _database.CreateTableAsync<SettingItem>();
        }

        public SQLiteAsyncConnection DatabaseString
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

        public ToolsDB<LogItem> PropertyLog
        {
            get
            {
                return new ToolsDB<LogItem>(new LogItem());
            }
        }

        public ToolsDB<SettingItem> PropertySetting
        {
            get
            {
                return new ToolsDB<SettingItem>(new SettingItem());
            }
        }

        public ToolsDB<ContactItem> PropertyContact
        {
            get
            {
                return new ToolsDB<ContactItem>(new ContactItem());
            }
        }


    }
}

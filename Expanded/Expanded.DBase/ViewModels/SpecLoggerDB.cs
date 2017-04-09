using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Expanded.DBase.Models;

namespace Expanded.DBase.ViewModels
{
    public class SpecLoggerDB
    {
        private SQLiteConnection _database;

        public SpecLoggerDB()
        {
            _database = ItemsDatabase_ST.DatabaseString;
        }

        /// <summary>
        /// Method for Get all items from LogItem
        /// </summary>
        /// <returns>List all item from LogItem Table</returns>
        public List<LogItem> GetItems()
        {
            return _database.Table<LogItem>().ToList();
        }

        /// <summary>
        /// Method for one item
        /// </summary>
        /// <param name="id"></param>
        /// <returns>One LogItem</returns>
        public LogItem GetItem(int id)
        {
            return _database.Table<LogItem>().Where(i => i.Id == id).FirstOrDefault();
        }

        public int SaveItem(LogItem item)
        {
            if (item.Id != 0)
            {
                return _database.Update(item);
            }

            return _database.Insert(item);
        }
    }
}
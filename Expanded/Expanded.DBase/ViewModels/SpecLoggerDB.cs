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
        private SQLiteAsyncConnection _database;

        SpecLoggerDB()
        {
            _database = ItemsDatabase_ST.DatabaseString;
        }

        /// <summary>
        /// Method for Get all items from LogItem
        /// </summary>
        /// <returns>List all item from LogItem Table</returns>
        public Task<List<LogItem>> GetItemsAsync()
        {
            return _database.Table<LogItem>().ToListAsync();
        }

        /// <summary>
        /// Method for one item
        /// </summary>
        /// <param name="id"></param>
        /// <returns>One LogItem</returns>
        public Task<LogItem> GetItemAsync(int id)
        {
            return _database.Table<LogItem>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Expanded.DBase.Models;
using SQLite;

namespace Expanded.DBase.ViewModels
{
    public class SpecContactsDB
    {
        private SQLiteAsyncConnection _database;

        SpecContactsDB()
        {
            _database = ItemsDatabase.DatabaseString;
        }

        /// <summary>
        /// Method for Get all items from ContactItem
        /// </summary>
        /// <returns>List all item from ContactItem Table</returns>
        public Task<List<ContactItem>> GetItemsAsync()
        {
            return _database.Table<ContactItem>().ToListAsync();
        }

        /// <summary>
        /// Method for one item
        /// </summary>
        /// <param name="id"></param>
        /// <returns>One ContactItem</returns>
        public Task<ContactItem> GetItemAsync(int id)
        {
            return _database.Table<ContactItem>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }
    }
}

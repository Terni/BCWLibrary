using Expanded.DBase.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expanded.DBase.ViewModels
{
    public class SpecSettingsDB
    {
        private SQLiteAsyncConnection _database;

        SpecSettingsDB()
        {
            _database = ItemsDatabase_ST.DatabaseString;
        }

        /// <summary>
        /// Method for Get all items from SettingItem
        /// </summary>
        /// <returns>List all item from SettingItem Table</returns>
        public Task<List<SettingItem>> GetItemsAsync()
        {
            return _database.Table<SettingItem>().ToListAsync();
        }

        /// <summary>
        /// Method for one item
        /// </summary>
        /// <param name="id"></param>
        /// <returns>One SettingItem</returns>
        public Task<SettingItem> GetItemAsync(int id)
        {
            return _database.Table<SettingItem>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }
    }
}

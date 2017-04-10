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
        private SQLiteConnection _database;
        static object locker = new object();

        SpecSettingsDB()
        {
            _database = ItemsDatabase_ST.DatabaseString;
        }

        /// <summary>
        /// Method for Get all items from SettingItem
        /// </summary>
        /// <returns>List all item from SettingItem Table</returns>
        public List<SettingItem> GetItems()
        {
            return _database.Table<SettingItem>().ToList();
        }

        /// <summary>
        /// Method for one item
        /// </summary>
        /// <param name="id"></param>
        /// <returns>One SettingItem</returns>
        public SettingItem GetItem(int id)
        {
            return _database.Table<SettingItem>().Where(i => i.Id == id).FirstOrDefault();
        }


        public int GenerLastIndex()
        {
            return _database.CreateIndex("SettingItem", "Id", true);
        }

        public int SaveItem(SettingItem item)
        {
            if (item.Id != 0)
            {
                return _database.Update(item);
            }

            return _database.Insert(item);
        }

        public int DropAllItem()
        {
            return _database.DeleteAll<SettingItem>();
        }
    }
}

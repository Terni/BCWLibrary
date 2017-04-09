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
        private SQLiteConnection _database;

        SpecContactsDB()
        {
            _database = ItemsDatabase_ST.DatabaseString;
        }

        /// <summary>
        /// Method for Get all items from ContactItem
        /// </summary>
        /// <returns>List all item from ContactItem Table</returns>
        public List<ContactItem> GetItems()
        {
            return _database.Table<ContactItem>().ToList();
        }

        /// <summary>
        /// Method for one item
        /// </summary>
        /// <param name="id"></param>
        /// <returns>One ContactItem</returns>
        public ContactItem GetItem(int id)
        {
            return _database.Table<ContactItem>().Where(i => i.Id == id).FirstOrDefault();
        }
    }
}

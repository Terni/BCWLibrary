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
        static object locker = new object();

        public SpecContactsDB()
        {
            _database = ItemsDatabase_ST.DatabaseString;
        }

        /// <summary>
        /// Method for Get all items from ContactItem
        /// </summary>
        /// <returns>List all item from ContactItem Table</returns>
        public List<ContactItem> GetItemsAll()
        {
            return _database.Table<ContactItem>().ToList();
        }

        /// <summary>
        /// Method for one item
        /// </summary>
        /// <param name="id"></param>
        /// <returns>One ContactItem</returns>
        public ContactItem GetItemAsID(int id)
        {
            return _database.Table<ContactItem>().Where(i => i.Id == id).FirstOrDefault();
        }

        public ContactItem GetItemAsFirstName(string name)
        {
            return _database.Table<ContactItem>().Where(i => i.FirstName == name).FirstOrDefault();
        }

        public ContactItem GetItemAsLastName(string surname)
        {
            return _database.Table<ContactItem>().Where(i => i.LastName == surname).FirstOrDefault();
        }

        public ContactItem GetItemAsAlias(string alias)
        {
            return _database.Table<ContactItem>().Where(i => i.Alias == alias).FirstOrDefault();
        }

        public ContactItem GetItemAsAddress(string address)
        {
            return _database.Table<ContactItem>().Where(i => i.Address == address).FirstOrDefault();
        }

        public List<ContactItem> GetItemsWithDate(string date)
        {
            lock (locker)
            {
                return _database.Query<ContactItem>(string.Format("SELECT Top 10 * FROM [{0}] WHERE [{1}] <= {2}",
                    "ContactItem", "Date", date));
            }
        }

        public IEnumerable<ContactItem> GetItemsFirstName(string name)
        {
            lock (locker)
            {
                return _database.Query<ContactItem>(string.Format("SELECT * FROM [{0}] WHERE [{1}] = {2}",
                    "ContactItem", "FirstName", name));
            }
        }


        public IEnumerable<ContactItem> GetItemsLastName(string surname)
        {
            lock (locker)
            {
                return _database.Query<ContactItem>(string.Format("SELECT * FROM [{0}] WHERE [{1}] = {2}",
                    "ContactItem", "LastName", surname));
            }
        }

        public IEnumerable<ContactItem> GetItemsAlias(string alias)
        {
            lock (locker)
            {
                return _database.Query<ContactItem>(string.Format("SELECT * FROM [{0}] WHERE [{1}] = {2}",
                    "ContactItem", "Alias", alias));
            }
        }

        public int GenerLastIndex()
        {
            return _database.CreateIndex("ContactItem", "Id", true);
        }


        public int SaveItem(ContactItem item)
        {
            //if (item.Id != 0) // TODO dont working good
            //{
            //    return _database.Update(item);
            //}

            return _database.Insert(item);
        }

        public int DeleteAsItem(ContactItem item)
        {
            return _database.Delete(item);
        }

        public int DeleteAsID(int id)
        {
            return _database.Delete(GetItemAsID(id));
        }

        public int DeleteAsAddress(string address)
        {
            return _database.Delete(GetItemAsAddress(address));
        }

        public int DropAllItem()
        {
            return _database.DeleteAll<ContactItem>();
        }
    }
}

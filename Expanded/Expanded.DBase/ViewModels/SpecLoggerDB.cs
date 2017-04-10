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
        static object locker = new object();

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

        //public IEnumerable<LogItem> GetItems()
        //{
        //    lock (locker)
        //    {
        //        return (from i in _database.Table<LogItem>() select i).ToList();
        //    }
        //}

        public IEnumerable<LogItem> GetItemsTraceLevel(string typeTraceLevel) // typeTraceLevel = ERROR, WARRING, ...
        {
            lock (locker)
            {
                return _database.Query<LogItem>(string.Format("SELECT * FROM [{0}] WHERE [{1}] = {2}",
                    "LogItem", "TraceLevel", typeTraceLevel));
            }
        }

        public List<LogItem> GetItemsWithDate(string date)
        {
            lock (locker)
            {
                return _database.Query<LogItem>(string.Format("SELECT Top 10 * FROM [{0}] WHERE [{1}] <= {2}",
                    "LogItem", "Date", date));
            }
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

        public int GenerLastIndex()
        {
            return _database.CreateIndex("LogItem","Id", true);
        }

        public int SaveItem(LogItem item)
        {
            if (item.Id != 0)
            {
                return _database.Update(item);
            }

            return _database.Insert(item);
        }

        public int DropAllItem()
        {
            return _database.DeleteAll<LogItem>();
        }
    }
}
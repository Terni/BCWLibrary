using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Expanded.DBase.Models;
using Expanded.DBase.Interface;

namespace Expanded.DBase.ViewModels
{

    public class ToolsDB<T> where T : new()
    {
        private SQLiteConnection _database;
        private T _type;
        static object locker = new object();

        public int Id { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        public ToolsDB(T obj)
        {
            _database = ItemsDatabase_ST.DatabaseString;
            _type = obj;
        }

        public List<T> GetItemsList()
        {
            lock (locker)
            {
                return _database.Table<T>().ToList();
            }
        }

        public List<T> GetItemsWithDate(string date)
        {
            lock (locker)
            {
                return _database.Query<T>(string.Format("SELECT Top 10 * FROM [{0}] WHERE [{1}] <= {2}",
                    _type.GetType(), "Date", date));
            }
        }

        //public T GetItem(int id)
        //{
        //    lock (locker)
        //    {
        //        return _database.Table<T>().Where(i => GetById((ITwithId) i) == id).FirstOrDefault();
        //    }
        //}

        /// <summary>
        /// Method with Interface for ID
        /// </summary>
        /// <param name="item">Generic T but with interface</param>
        /// <returns>Result is specific Id</returns>
        private int GetById(ITwithId item)
        {
            return item.Id;
        }

        public int SaveItem(T item)
        {
            lock (locker)
            {
                //if (GetById((ITwithId)item) != 0)
                //{
                //    return _database.Update(item);
                //}
                //else
                //{
                return _database.Insert(item);
                //}
            }
        }

        public int DeleteItem(T item)
        {
            lock (locker)
            {
                return _database.Delete(item);
            }
        }


    }
}

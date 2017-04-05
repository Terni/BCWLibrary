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
        private SQLiteAsyncConnection _database;
        private T _type;

        public int Id { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        public ToolsDB(T obj)
        {
            _database = ItemsDatabase_ST.DatabaseString;
            _type = obj;
        }

        public Task<List<T>> GetItemsAsync()
        {
            return _database.Table<T>().ToListAsync();
        }

        public Task<List<T>> GetItemsAsyncWithDate(DateTime date)
        {
            return _database.QueryAsync<T>(string.Format("SELECT Top 10 * FROM [{0}] WHERE [{1}] <= {2}",_type.GetType(), "Date",date));
        }

        public Task<T> GetItemAsync(int id)
        {
            return _database.Table<T>().Where(i => GetById((ITwithId)i) == id).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Method with Interface for ID
        /// </summary>
        /// <param name="item">Generic T but with interface</param>
        /// <returns>Result is specific Id</returns>
        private int GetById(ITwithId item)
        {
            return item.Id;
        }

        public Task<int> SaveItemAsync(T item)
        {
            //if (GetById((ITwithId)item) != 0)
            //{
            //    return _database.UpdateAsync(item);
            //}
            //else
            //{
                return _database.InsertAsync(item);
            //}
        }

        public Task<int> DeleteItemAsync(T item)
        {
            return _database.DeleteAsync(item);
        }


    }
}

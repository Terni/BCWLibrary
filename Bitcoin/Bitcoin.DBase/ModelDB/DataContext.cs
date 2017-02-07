using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitcoin.DBase.ModelDB
{
    public class ToDoDataContext : DataContext
    {
        // Specify the connection string as a static, used in main page and app.xaml.
        public static string DBConnectionString = "Data Source=isostore:/database.sdf";


        public ToDoDataContext(string connectionString) : base(connectionString){}


        // Specify a table for the to-do items.
        public Table<ToDoItem> ToDoItems;

        // Specify a table for the to-do login.
        public Table<ToDoLogin> ToDoLogins;

        // Specify a table for the categories.
        //public Table<ToDoCategory> Categories;
    }

}

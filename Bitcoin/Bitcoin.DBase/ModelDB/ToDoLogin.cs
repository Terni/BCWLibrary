using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitcoin.DBase.ModelDB
{
    [Table]
    public class ToDoLogin : INotifyPropertyChanged, INotifyPropertyChanging
    {

        //
        // TODO: Add columns and associations, as applicable, here.
        //
        #region Columns

        // Define ID: private field, public property, and database column.
        private int _toDoLoginId;
        /// <summary>
        /// Slouce ToDoLoginId
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity",
            CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int ToDoLoginId
        {
            get { return _toDoLoginId; }
            set
            {
                if (_toDoLoginId != value)
                {
                    NotifyPropertyChanging("ToDoLoginId");
                    _toDoLoginId = value;
                    NotifyPropertyChanged("ToDoLoginId");
                }
            }
        }

        // Define item name: private field, public property, and database column.
        private string _itemLogin;
        /// <summary>
        /// Sloupec ItemLogin
        /// </summary>
        [Column]
        public string ItemLogin
        {
            get { return _itemLogin; }
            set
            {
                if (_itemLogin != value)
                {
                    NotifyPropertyChanging("ItemLogin");
                    _itemLogin = value;
                    NotifyPropertyChanged("ItemLogin");
                }
            }
        }

        // Define completion value: private field, public property, and database column.
        private bool _isComplete;
        /// <summary>
        /// Sloupcec IsComplete
        /// </summary>
        [Column]
        public bool IsComplete
        {
            get { return _isComplete; }
            set
            {
                if (_isComplete != value)
                {
                    NotifyPropertyChanging("IsComplete");
                    _isComplete = value;
                    NotifyPropertyChanged("IsComplete");
                }
            }
        }
        #endregion
        //
        // TODO konec sloupce
        //


        // Version column aids update performance.
        [Column(IsVersion = true)]
        private Binary _version;

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        // Used to notify that a property changed
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region INotifyPropertyChanging Members

        public event PropertyChangingEventHandler PropertyChanging;

        // Used to notify that a property is about to change
        private void NotifyPropertyChanging(string propertyName)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
            }
        }

        #endregion
    }
}

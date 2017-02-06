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
    public class ToDoItem : INotifyPropertyChanged, INotifyPropertyChanging
    {

        //
        // TODO: Add columns and associations, as applicable, here.
        //
        #region Columns

        // Define ID: private field, public property, and database column.
        private int _toDoItemId;
        /// <summary>
        /// Slouce ToDoItemId
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity",
            CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int ToDoItemId
        {
            get { return _toDoItemId; }
            set
            {
                if (_toDoItemId != value)
                {
                    NotifyPropertyChanging("ToDoItemId");
                    _toDoItemId = value;
                    NotifyPropertyChanged("ToDoItemId");
                }
            }
        }

        // Define item name: private field, public property, and database column.
        private string _itemName;
        /// <summary>
        /// Sloupec ItemName
        /// </summary>
        [Column]
        public string ItemName
        {
            get { return _itemName; }
            set
            {
                if (_itemName != value)
                {
                    NotifyPropertyChanging("ItemName");
                    _itemName = value;
                    NotifyPropertyChanged("ItemName");
                }
            }
        }

        // Define item name: private field, public property, and database column.
        private string _itemAddress;
        /// <summary>
        /// Sloupec ItemAddress
        /// </summary>
        [Column]
        public string ItemAddress
        {
            get { return _itemAddress; }
            set
            {
                if (_itemAddress != value)
                {
                    NotifyPropertyChanging("ItemAddress");
                    _itemAddress = value;
                    NotifyPropertyChanged("ItemAddress");
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

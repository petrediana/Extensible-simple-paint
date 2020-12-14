using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace SimplePaint.ObjectModel
{
    public class ObservableCollectionBase<T> : ObservableCollection<T>
        where T : INotifyPropertyChanged
    {
        public ObservableCollectionBase()
        {
            CollectionChanged += CurrentObservableCollectionChanged;
        }

        void CurrentObservableCollectionChanged (object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (T item in e.NewItems)
                {
                    item.PropertyChanged += ItemPropertyChanged;
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (T item in e.OldItems)
                {
                    item.PropertyChanged -= ItemPropertyChanged;
                }
            }
        }

        void ItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            NotifyCollectionChangedEventArgs evarg = 
                new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, sender, sender);

            OnCollectionChanged(evarg);
        }
    }
}

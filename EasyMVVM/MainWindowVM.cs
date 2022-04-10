using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;
using System.Collections.ObjectModel;

namespace EasyMVVM
{
    public class MainWindowVM : DependencyObject, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<string> _BackingProperty;

        public MainWindowVM()
        {
            Model m = new Model();
            BoundProperty = m.GetData();
        }

        public ObservableCollection<string> BoundProperty
        {
            get { return _BackingProperty; }
            set
            {
                _BackingProperty = value;
                PropChanged("BoundProperty");
            }
        }

        public void PropChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

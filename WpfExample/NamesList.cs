using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace WpfExample
{
    public class NamesList : INotifyPropertyChanged
    {
        string _firstName = string.Empty;
        string _lastName = string.Empty;
        string _selectedName;

        private AddCommand _addNameCommand = new AddCommand();
        private RemoveCommand _removeNameCommand = new RemoveCommand();
        public AddCommand AddNameCommand
        {
            get { return _addNameCommand; }
        }

        public RemoveCommand RemoveNameCommand
        {
            get { return _removeNameCommand; }
        }

        public NamesList()
        {
            Names = new ObservableCollection<string>();
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (value != _firstName)
                {
                    _firstName = value;
                    OnPropertyChanged("FirstName");
                }
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (value != _lastName)
                {
                    _lastName = value;
                    OnPropertyChanged("LastName");
                }
            }
        }

        public string SelectedName
        {
            get { return _selectedName; }
            set
            {
                if (_selectedName != value)
                {
                    _selectedName = value;
                    OnPropertyChanged("SelectedName");
                }
            }
        }

        public ObservableCollection<string> Names { get; private set; }

        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

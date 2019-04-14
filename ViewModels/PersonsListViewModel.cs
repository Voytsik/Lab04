using Lab02.Models;
using Lab02.Tools;
using Lab02.Manager;
using Lab02.Navigation;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections.Generic;

namespace Lab02.ViewModels
{
    internal class PersonsListViewModel : Tools.BaseViewModel
    {
        private RelayCommand<object> _addCommand;
        private ObservableCollection<Person> _persons;
        private bool _refresh;
        private RelayCommand<object> _removeCommand;
        private RelayCommand<object> _editCommand;
        private RelayCommand<object> _exitCommand;
        private String _name;

        internal PersonsListViewModel()
        {
            _persons = new ObservableCollection<Person>(StationManager.DataStorage.PersonsList);
        }

        public ObservableCollection<Person> Persons
        {
            get
            {
                return _persons;
            }
            private set
            {
                _persons = value;
                OnPropertyChanged();
            }
        }

        public bool Refresh
        {
            get
            {
                return _refresh;
            }
            set
            {
                _refresh = value;
                Persons = new ObservableCollection<Person>(StationManager.DataStorage.PersonsList);
                OnPropertyChanged();
            }
        }

        public String Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                if (!value.Equals(""))
                {
                    var selectedPersons = StationManager.DataStorage.PersonsList.Where(x => x.Name.StartsWith(value)).ToList();
                    Persons = new ObservableCollection<Person>(selectedPersons);
                }
                else
                {
                    Persons = new ObservableCollection<Person>(StationManager.DataStorage.PersonsList);
                }
                OnPropertyChanged();
            }
        }


        public RelayCommand<object> AddCommand
        {
            get
            {
                return _addCommand = new RelayCommand<object>(param =>
                {
                    NavigationManager.Instance.Navigate(ViewType.Input, "Create");
                });
            }
        }

        public RelayCommand<object> ExitCommand
        {
            get
            {
                return _exitCommand = new RelayCommand<object>(param =>
                {
                    StationManager.CloseApp();
                });
            }
        }

        public RelayCommand<object> EditCommand
        {
            get
            {
                return _editCommand = new RelayCommand<object>(param =>
                {
                    NavigationManager.Instance.Navigate(ViewType.Remove, "Edit");
                });
            }
        }

        public RelayCommand<object> RemoveCommand
        {
            get
            {
                return _removeCommand = new RelayCommand<object>(param =>
                {
                    NavigationManager.Instance.Navigate(ViewType.Remove, "Remove");
                });
            }
        }
    }
}
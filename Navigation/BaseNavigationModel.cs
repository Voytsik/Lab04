using Lab02.Models;
using Lab02.ViewModels;
using Lab02.Windows;
using Lab02.ViewModels;
using System;
using System.Collections.Generic;

namespace Lab02.Navigation
{
    internal abstract class BaseNavigationModel : INavigationModel
    {
        private readonly IContentOwner _contentOwner;
        private readonly Dictionary<ViewType, INavigatable> _viewsDictionary;

        protected BaseNavigationModel(IContentOwner contentOwner)
        {
            _contentOwner = contentOwner;
            _viewsDictionary = new Dictionary<ViewType, INavigatable>();
        }

        protected IContentOwner ContentOwner
        {
            get { return _contentOwner; }
        }

        protected Dictionary<ViewType, INavigatable> ViewsDictionary
        {
            get { return _viewsDictionary; }
        }

        public void Navigate(ViewType viewType)
        {
            if (!ViewsDictionary.ContainsKey(viewType))
                InitializeView(viewType);
            ContentOwner.ContentControl.Content = ViewsDictionary[viewType];
        }


        public void Navigate(ViewType viewType, bool refresh)
        {
            if (!ViewsDictionary.ContainsKey(viewType))
                InitializeView(viewType);
            ContentOwner.ContentControl.Content = ViewsDictionary[viewType];
            PersonsListView tempView = (PersonsListView)ViewsDictionary[viewType];
            PersonsListViewModel tempModel = (PersonsListViewModel)tempView.DataContext;
            tempModel.Refresh = refresh;
        }

        public void Navigate(ViewType viewType, String buttonName)
        {
            if (!ViewsDictionary.ContainsKey(viewType))
                InitializeView(viewType);
            ContentOwner.ContentControl.Content = ViewsDictionary[viewType];

            if (viewType == ViewType.Input)
            {
                InputWindow tempView = (InputWindow)ViewsDictionary[viewType];
                InputViewModel tempModel = (InputViewModel)tempView.DataContext;
                tempModel.ButtonName = buttonName;
            }
            else if (viewType == ViewType.Remove)
            {
                RemoveUser tempView = (RemoveUser)ViewsDictionary[viewType];
                RemovePersonViewModel tempModel = (RemovePersonViewModel)tempView.DataContext;
                tempModel.ButtonName = buttonName;
            }
        }

        public void Navigate(ViewType viewType, Person person)
        {
            if (!ViewsDictionary.ContainsKey(viewType))
                InitializeView(viewType);
            ContentOwner.ContentControl.Content = ViewsDictionary[viewType];

            InputWindow tempView = (InputWindow)ViewsDictionary[viewType];
            InputViewModel tempModel = (InputViewModel)tempView.DataContext;
            tempModel.ButtonName = "Edit";
            tempModel.MainPerson = new Person(person.Name, person.Surname, person.Email, person.DateOfBirth);
        }

        protected abstract void InitializeView(ViewType viewType);

    }
}
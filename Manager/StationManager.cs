using Lab02.DataStorage;
using Lab02.Models;
using System;
using System.Windows;

namespace Lab02.Manager
{
    internal static class StationManager
    {

        private static IDataStorage _dataStorage;

        internal static IDataStorage DataStorage
        {
            get { return _dataStorage; }
        }

        internal static void Initialize(IDataStorage dataStorage)
        {
            _dataStorage = dataStorage;
        }

        internal static void CloseApp()
        {
            MessageBox.Show("ShutDown");
            Environment.Exit(1);
        }
    }
}
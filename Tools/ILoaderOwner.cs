using System.ComponentModel;

namespace Lab02.Tools
{
    internal interface ILoaderOwner : INotifyPropertyChanged
    {
        bool IsControlEnabled { get; set; }
    }
}
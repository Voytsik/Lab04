using Lab02.Properties;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Lab02.Tools
{
    [Serializable]
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
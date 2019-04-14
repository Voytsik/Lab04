using Lab02.Tools;
using Lab02.Manager;

namespace Lab02.ViewModels
{
    internal class MainWindowViewModel : BaseViewModel, ILoaderOwner
    {
        private bool _isControlEnabled = true;

        public bool IsControlEnabled
        {
            get { return _isControlEnabled; }
            set
            {
                _isControlEnabled = value;
                OnPropertyChanged();
            }
        }

        internal MainWindowViewModel()
        {
            LoaderManeger.Instance.Initialize(this);
        }
    }
}
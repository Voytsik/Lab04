using Lab02.DataStorage;
using Lab02.Manager;
using Lab02.Navigation;
using Lab02.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Lab02
{
    public partial class MainWindow : Window, IContentOwner
    {
        public MainWindow()
        {
            InitializeComponent();
            if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
                return;
            DataContext = new MainWindowViewModel();
            InitializeApplication();
        }

        public ContentControl ContentControl => _contentControl;

        private void InitializeApplication()
        {
            StationManager.Initialize(new SerializedDataStorage());
            NavigationManager.Instance.Initialize(new InitializationNavigationModel(this));
            NavigationManager.Instance.Navigate(ViewType.Main);
        }
    }
}
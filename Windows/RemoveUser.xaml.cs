using Lab02.Navigation;
using Lab02.ViewModels;
using System.Windows.Controls;

namespace Lab02.Windows
{
    public partial class RemoveUser : UserControl, INavigatable
    {
        public RemoveUser()
        {
            InitializeComponent();
            DataContext = new RemovePersonViewModel();
        }
    }
}
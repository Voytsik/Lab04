using Lab02.Navigation;
using Lab02.ViewModels;
using System.Windows.Controls;

namespace Lab02.Windows
{
    public partial class PersonsListView : UserControl, INavigatable
    {
        public PersonsListView()
        {
            InitializeComponent();
            DataContext = new PersonsListViewModel();
            this.myGrid.IsReadOnly = true;
        }

    }
}
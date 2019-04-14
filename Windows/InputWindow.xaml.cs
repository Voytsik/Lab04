using Lab02.Navigation;
using Lab02.ViewModels;
using System.Windows.Controls;

namespace Lab02.Windows
{
    public partial class InputWindow : UserControl, INavigatable
    {
        public InputWindow()
        {
            InitializeComponent();
            DataContext = new InputViewModel();
        }
    }
}
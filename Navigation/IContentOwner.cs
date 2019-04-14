using System.Windows.Controls;

namespace Lab02.Navigation
{
    internal interface IContentOwner
    {
        ContentControl ContentControl { get; }
    }
}
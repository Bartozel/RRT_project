using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PathFindingSimulator.Wpf
{
    public interface ISidePanelViewModel
    {
        ICommand OnButtonClicked { get; }
        ObservableCollection<MenuButton> ButtonsCollection { get; }
    }
}
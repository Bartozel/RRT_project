using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PathFindingSimulator.Wpf
{
    public class MainSidePanelViewModel : ISidePanelViewModel
    {
        public ICommand OnButtonClicked { get; }

        public ObservableCollection<MenuButton> ButtonsCollection {  get; }

        public MainSidePanelViewModel()
        {
            OnButtonClicked = new RelayCommand<MenuButton>(OnMenuButtonClicked, CanExecuteMenuButtonClick);
            ButtonsCollection = LoadButtons();
        }

        private ObservableCollection<MenuButton> LoadButtons()
        {
            throw new NotImplementedException();
        }

        private void OnMenuButtonClicked(MenuButton button)
        {
            throw new NotImplementedException();
        }

        private bool CanExecuteMenuButtonClick(MenuButton button)
        {
            return true;
        }
    }
}

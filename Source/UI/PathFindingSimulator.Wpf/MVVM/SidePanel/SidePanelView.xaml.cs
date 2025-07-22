using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace PathFindingSimulator.Wpf
{
    /// <summary>
    /// Interaction logic for SidePanelView.xaml
    /// </summary>
    public partial class SidePanelView : UserControl
    {
        ISidePanelViewModel _sidePanelViewModel;

        public SidePanelView(ISidePanelViewModel sidePanelViewModel)
        {
            InitializeComponent();

            _sidePanelViewModel = sidePanelViewModel;
            this.DataContext = _sidePanelViewModel;
            CreateGridRowDefinitions();
        }

        private void CreateGridRowDefinitions()
        {
            foreach (var i in Enumerable.Range(0, _sidePanelViewModel.ButtonsCollection.Count - 1))
            {
                this.MainGrid.RowDefinitions.Add(
                    new RowDefinition()
                    {
                        Height = new GridLength(0.2, GridUnitType.Star)
                    }
                );
            }

            this.MainGrid.RowDefinitions.Add(
                new RowDefinition()
                {
                    Height = new GridLength(1, GridUnitType.Star)
                }
            );
        }
    }
}

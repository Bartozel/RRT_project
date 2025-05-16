using Data.Map;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PathFindingSimulator.wpf.MVVM
{
    class MapViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<IObstacle> _obstacles;
        private ObservableCollection<IAgent> _agents;

        public ObservableCollection<IObstacle> Obstacles
        {
            get => _obstacles;
            set
            {
                _obstacles = value;
                OnPropertyChanged(nameof(Obstacles));
            }
        }

        public ObservableCollection<IAgent> Agents
        {
            get => _agents;
            set
            {
                _agents = value;
                OnPropertyChanged(nameof(Agents));
            }
        }
    }
}

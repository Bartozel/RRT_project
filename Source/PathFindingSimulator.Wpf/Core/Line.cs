using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PathFindingSimulator.Core
{
    internal class Line : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

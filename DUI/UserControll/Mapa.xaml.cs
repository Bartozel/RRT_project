using Data.Data;
using DUI.Program;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DUI
{
    /// <summary>
    /// Interaction logic for Mapa.xaml
    /// </summary>
    public partial class Mapa : UserControl
    {
        public Mapa()
        {
            InitializeComponent();
        }

        internal IObservable<Node> StartSearch()
        {
            var obs = Observer.Create<Node>(x =>
            {
                var line = new Line();
                line.X1 = x.XCoordinate;
                line.X2 = x.YCoordinate;
                line.Y1 = x.Parent.XCoordinate;
                line.Y2 = x.Parent.YCoordinate;
                this.canvasMap.Children.Add(line);
            });

           var disp =  AppLogic.Start(obs);

            return disp;
        }
    }
}

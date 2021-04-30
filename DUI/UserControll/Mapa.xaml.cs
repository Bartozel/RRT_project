using Data;
using Data.Data;
using DUI.Program;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Concurrency;
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
        private AppLogic appLogic;

        public Mapa()
        {
            InitializeComponent();
            appLogic = new AppLogic();
        }

        internal void StopSearch()
        {
            appLogic.Stop();
        }

        internal IObservable<Node> StartSearch()
        {
            var obs = Observer.Create<Node>(
                    x => AddLine(x),
                    OnCompleted
                );

            var disp = appLogic.Start();
            disp.ObserveOnDispatcher()
                .Synchronize()
                .Subscribe(obs);

            return disp;
        }

        private void AddLine(Node node)
        {
            var line = new Line();
            line.X1 = node.XCoordinate;
            line.Y1 = node.YCoordinate;
            line.X2 = node.Parent.XCoordinate;
            line.Y2 = node.Parent.YCoordinate;
            line.Stroke = new SolidColorBrush(Colors.Black);

            this.canvasMap.Children.Add(line);
        }

        private void OnCompleted()
        {

        }

        private void Button_Click_Start(object sender, RoutedEventArgs e)
        {
            ButtonsEnable(false);
            this.canvasMap.MouseLeftButtonDown += Canvas_Click_Start;
        }

        private void Canvas_Click_Start(object sender, RoutedEventArgs e)
        {
            this.canvasMap.MouseLeftButtonDown -= Canvas_Click_Start;
            var mp = Mouse.GetPosition(this.canvasMap);
            appLogic.StartPosition = new Position((int)mp.X, (int)mp.Y);
            AddChild(appLogic.StartPosition);

            ButtonsEnable(true);
        }

        private void Button_Click_Goal(object sender, RoutedEventArgs e)
        {
            ButtonsEnable(false);

        }

        private void Button_Click_Obs(object sender, RoutedEventArgs e)
        {
            ButtonsEnable(false);
        }

        private void Button_Click_Del(object sender, RoutedEventArgs e)
        {
            ButtonsEnable(false);
        }

        private void Canvas_Click_Goal(object sender, RoutedEventArgs e)
        {
            ButtonsEnable(false);
        }

        private void Canvas_Click_Obs(object sender, RoutedEventArgs e)
        {


            ButtonsEnable(false);
        }

        private void AddChild(Position p)
        {
            int halfWidth = 5;
            int halfHeight = 5;

            Rectangle rec = new Rectangle()
            {
                Width = halfWidth * 2,
                Height = halfHeight * 2,
                Fill = Brushes.Green,
                Stroke = Brushes.Black,
                StrokeThickness = 2,
            };

            Canvas.SetLeft(rec, p.XCoordinate - halfWidth);
            Canvas.SetTop(rec, p.YCoordinate - halfWidth);

            this.canvasMap.Children.Add(rec);
        }

        private void ButtonsEnable(bool enable)
        {
            this.btnStart.IsEnabled = enable;
            this.btnGoal.IsEnabled = enable;
            this.btnObs.IsEnabled = enable;
        }

        private void IsStartEnabled()
        {

        }
    }
}

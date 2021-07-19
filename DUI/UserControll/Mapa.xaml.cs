using Data.Data;
using DUI.Program;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DUI
{
    /// <summary>
    /// Interaction logic for Mapa.xaml
    /// </summary>
    public partial class Mapa : UserControl
    {
        private Rectangle recStart;
        private Rectangle recGoal;
        private List<Rectangle> obstaclesRec;
        private int halfWidth = 5;
        private int halfHeight = 5;

        public event EventHandler<Position> StartChanged;
        public event EventHandler<Position> GoalChanged;
        public event EventHandler<List<Rectangle>> ObstaclesChanged;

        public Mapa()
        {
            InitializeComponent();
            obstaclesRec = new List<Rectangle>();
        }

        private void StartLoad()
        {
            this.recGoal = GetRectangle(Brushes.Red);
            AddChild(this.recGoal);
            this.recStart = GetRectangle(Brushes.Green);
            AddChild(this.recStart);
        }

        private void Button_Click_Start_Position(object sender, RoutedEventArgs e)
        {
            ButtonsEnable(false);
            this.canvasMap.MouseLeftButtonDown += Canvas_Click_Start_Position;
        }

        internal void SetStartPosition(Position startPosition)
        {
            SetRecOffset(startPosition, this.recStart);
        }

        internal void SetGoalPosition(Position goalPosition)
        {
            SetRecOffset(goalPosition, this.recGoal);
        }

        private void Canvas_Click_Start_Position(object sender, RoutedEventArgs e)
        {
            this.canvasMap.MouseLeftButtonDown -= Canvas_Click_Start_Position;
            var mp = Mouse.GetPosition(this.canvasMap);
            var pos = new Position((int)mp.X, (int)mp.Y);

            StartChanged?.Invoke(this, pos);
            ButtonsEnable(true);
        }

        private void Button_Click_Goal_Position(object sender, RoutedEventArgs e)
        {
            ButtonsEnable(false);
            this.canvasMap.MouseLeftButtonDown += Canvas_Click_Goal_Position;
        }
        private void Canvas_Click_Goal_Position(object sender, RoutedEventArgs e)
        {
            this.canvasMap.MouseLeftButtonDown -= Canvas_Click_Goal_Position;
            var mp = Mouse.GetPosition(this.canvasMap);
            var pos = new Position((int)mp.X, (int)mp.Y);

            GoalChanged?.Invoke(this, pos);
            ButtonsEnable(true);
        }

        public void SetRecOffset(Position pos, Rectangle rec)
        {
            Canvas.SetLeft(rec, pos.XCoordinate - this.halfWidth);
            Canvas.SetTop(rec, pos.YCoordinate - this.halfHeight);
        }

        private Rectangle GetRectangle(SolidColorBrush fillColor)
        {
            Rectangle rec = new Rectangle()
            {
                Width = halfWidth * 2,
                Height = halfHeight * 2,
                Fill = fillColor,
                Stroke = Brushes.Black,
                StrokeThickness = 2,
            };
            return rec;
        }

        private void Button_Click_Obs_Position(object sender, RoutedEventArgs e)
        {
            ButtonsEnable(false);
        }

        private void Button_Click_Del_Position(object sender, RoutedEventArgs e)
        {
            ButtonsEnable(false);
        }

        private void Canvas_Click_Obs_Position(object sender, RoutedEventArgs e)
        {
            ButtonsEnable(false);
        }

        private void ButtonsEnable(bool enable)
        {
            this.btnStart.IsEnabled = enable;
            this.btnGoal.IsEnabled = enable;
            this.btnObs.IsEnabled = enable;
        }

        private void Canvas_Loaded(object sender, RoutedEventArgs e)
        {
            StartLoad();
        }

        internal void AddChild(Rectangle rec)
        {
            this.canvasMap.Children.Add(rec);
        }

        internal void AddLine(Node node)
        {
            var line = new Line();
            line.X1 = node.XCoordinate;
            line.Y1 = node.YCoordinate;
            line.X2 = node.Parent.XCoordinate;
            line.Y2 = node.Parent.YCoordinate;
            line.Stroke = new SolidColorBrush(Colors.Black);

            this.canvasMap.Children.Add(line);
        }
    }
}

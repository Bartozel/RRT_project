using Data;
using System;
using System.Collections.Generic;
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

        public event EventHandler<IPosition> StartChanged;
        public event EventHandler<IPosition> GoalChanged;
        public event EventHandler<List<Rectangle>> ObstaclesChanged;

        public Mapa()
        {
            InitializeComponent();
            obstaclesRec = new List<Rectangle>();
        }

        private void StartLoad()
        {
            _recGoal = GetRectangle(Brushes.Red);
            AddChild(_recGoal);
            _recStart = GetRectangle(Brushes.Green);
            AddChild(_recStart);
        }

        private void Button_Click_Start_Position(object sender, RoutedEventArgs e)
        {
            ButtonsEnable(false);
            _canvasMap.MouseLeftButtonDown += Canvas_Click_Start_Position;
        }

        internal void SetStartPosition(IPosition startPosition)
        {
            SetRecOffset(startPosition, _recStart);
        }

        internal void SetGoalPosition(IPosition goalPosition)
        {
            SetRecOffset(goalPosition, _recGoal);
        }

        private void Canvas_Click_Start_Position(object sender, RoutedEventArgs e)
        {
            _canvasMap.MouseLeftButtonDown -= Canvas_Click_Start_Position;
            var mp = Mouse.GetPosition(_canvasMap);
            var pos = new Position((int)mp.X, (int)mp.Y);

            StartChanged?.Invoke(this, pos);
            ButtonsEnable(true);
        }

        private void Button_Click_Goal_Position(object sender, RoutedEventArgs e)
        {
            ButtonsEnable(false);
            _canvasMap.MouseLeftButtonDown += Canvas_Click_Goal_Position;
        }
        private void Canvas_Click_Goal_Position(object sender, RoutedEventArgs e)
        {
            _canvasMap.MouseLeftButtonDown -= Canvas_Click_Goal_Position;
            var mp = Mouse.GetPosition(_canvasMap);
            var pos = new Position((int)mp.X, (int)mp.Y);

            GoalChanged?.Invoke(this, pos);
            ButtonsEnable(true);
        }

        public void SetRecOffset(IPosition pos, Rectangle rec)
        {
            Canvas.SetLeft(rec, pos.XCoordinate - _halfWidth);
            Canvas.SetTop(rec, pos.YCoordinate - _halfHeight);
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
            _btnStart.IsEnabled = enable;
            _btnGoal.IsEnabled = enable;
            _btnObs.IsEnabled = enable;
        }

        private void Canvas_Loaded(object sender, RoutedEventArgs e)
        {
            StartLoad();
        }

        internal void AddChild(Rectangle rec)
        {
            _canvasMap.Children.Add(rec);
        }

        internal void AddLine(ITreeNode node)
        {
            var line = new Line();
            line.X1 = node.XCoordinate;
            line.Y1 = node.YCoordinate;
            line.X2 = node.Parent.XCoordinate;
            line.Y2 = node.Parent.YCoordinate;
            line.Stroke = new SolidColorBrush(Colors.Black);

            _canvasMap.Children.Add(line);
        }
    }
}

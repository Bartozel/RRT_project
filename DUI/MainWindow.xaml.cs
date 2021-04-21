﻿using System;
using System.Reactive;
using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;
using Data.Data;
using DUI.Program;

namespace DUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void bStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bStart.IsEnabled = false;
                await canvasMap.StartSearch()
                                .ToTask();
                bStart.IsEnabled = true;
            }
            catch (Exception ex)
            {
                //TODO
            }
        }

        private void bStop_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bPause_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bRestart_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bSetting_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

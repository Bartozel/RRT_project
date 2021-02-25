using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Program program;

        public MainWindow()
        {
            InitializeComponent();
            program = new Program();
        }

        private async Task bStart_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                var task = program.StartAsync();
                await task;
            }
            catch (Exception ex)
            {

            }
        }

        private void bStop_Click(object sender, RoutedEventArgs e)
        {
            program.Stop();
        }

        private void bPause_Click(object sender, RoutedEventArgs e)
        {
            program.Pause();
        }

        private void bRestart_Click(object sender, RoutedEventArgs e)
        {
            program.Restart();
        }

        private void bSetting_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

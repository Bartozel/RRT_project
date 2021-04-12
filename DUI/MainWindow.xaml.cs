using System;
using System.Threading.Tasks;
using System.Windows;
using DUI.Program;

namespace DUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AppLogic appLogic;

        public MainWindow()
        {
            InitializeComponent();
            appLogic = new AppLogic();
        }

        private async Task bStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
        }

        private void bStop_Click(object sender, RoutedEventArgs e)
        {
            appLogic.Stop();
        }

        private void bPause_Click(object sender, RoutedEventArgs e)
        {
            appLogic.Pause();
        }

        private void bRestart_Click(object sender, RoutedEventArgs e)
        {
            appLogic.Restart();
        }

        private void bSetting_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

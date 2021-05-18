using System;
using System.Reactive;
using System.Reactive.Linq;
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
            ProcessStartedEnableBtns(false);
            try
            {
                await canvasMap.StartSearch();
            }
            catch(OperationCanceledException ee)
            {
                MessageBox.Show("Process stopped");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show(ex.Message);
            }
            ProcessStartedEnableBtns(true);
        }

        private void ProcessStartedEnableBtns(bool enable)
        {
            bStart.IsEnabled = enable;
            bSetting.IsEnabled = enable;
        }

        private void bStop_Click(object sender, RoutedEventArgs e)
        {
            canvasMap.StopSearch();
        }

        private void bPause_Click(object sender, RoutedEventArgs e)
        {
            canvasMap.PauseSearch();
        }

        private void bRestart_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bSetting_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

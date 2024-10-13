using DUI.Form;
using DUI.Program;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Text;
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
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : UserControl
    {
        AppLogic appLogic;
        public Menu()
        {
            InitializeComponent();

        }

        public void LoadAppLogic(AppLogic appLogic)
        {
            _appLogic = appLogic;
        }

        private async void bStart_Click(object sender, RoutedEventArgs e)
        {
            ProcessStartedEnableBtns(false);
            try
            {
                await appLogic.Start();
            }
            catch (OperationCanceledException ee)
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
            appLogic.Stop();
        }

        private void bPause_Click(object sender, RoutedEventArgs e)
        {
            appLogic.Pause();
        }

        private void bRestart_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void bSetting_Click(object sender, RoutedEventArgs e)
        {
            var settingWindow = new Setting();
            settingWindow.Show();
        }
    }
}

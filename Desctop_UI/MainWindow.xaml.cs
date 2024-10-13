using System.Windows;
using DUI.Program;

namespace DUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AppLogic appLogic;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void grdMain_Loaded(object sender, RoutedEventArgs e)
        {
            appLogic = new AppLogic(_canvasMap);
            _menu.LoadAppLogic(appLogic);
        }
    }
}

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
        AppLogic appLogic;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void grdMain_Loaded(object sender, RoutedEventArgs e)
        {
            appLogic = new AppLogic(this.canvasMap);
            this.menu.LoadAppLogic(appLogic);
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using System.Windows;

using Logging;
using Communication;

namespace PathFindingSimulator.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ServiceProvider ServiceProvider { get; private set; }

        private SimulationManager _simulationManager;

        public App()
        {
            // Initialize the application
            InitializeComponent();
        }

        protected override void OnStartup(StartupEventArgs e)
        {   
            base.OnStartup(e);

            var services = new ServiceCollection();
            services.AddCustomLogging()
                    .AddMediatorHandlers()
                    .AddMediatorHandlers<App>();

            services.AddSingleton<SimulationManager>();
            services.AddSingleton<ISimulationSettingService, SimulationSettingService>();

            AddUI(services);

            ServiceProvider = services.BuildServiceProvider();

            _simulationManager = ServiceProvider.GetRequiredService<SimulationManager>();
        }  
        
        private void AddUI(ServiceCollection services)
        {
            services
                .AddTransient<MainWindow>()
                .AddTransient<MainViewModel>();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _simulationManager.Dispose();
            base.OnExit(e);
        }
    }

}

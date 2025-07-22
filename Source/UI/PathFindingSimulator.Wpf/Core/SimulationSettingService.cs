using Communication;
using Data;

namespace PathFindingSimulator.Wpf
{
    internal class SimulationSettingService : ISimulationSettingService
    {
        private SimulationSetting _setting;
        public SimulationSettingService() { }

        public void UpdateSettings(SimulationSetting setting)
        {
            _setting = setting;
        }

        public SimulationSetting GetSimulationSetting()
        {
           return _setting;
        }
    }
}

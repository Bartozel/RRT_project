using Data;

namespace Communication
{
    public interface ISimulationSettingService
    {
        SimulationSetting GetSimulationSetting();
        void UpdateSettings(SimulationSetting settings);
    }
}

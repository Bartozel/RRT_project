using Communication;
using Data;
using Data.Communication;
using Logging;
using System;

namespace PathFindingSimulator
{
    public class PathFindingSimulator : BaseLogger
    {
        private ESimulationState _simulationState;
        private readonly SimulationSetting _setting;
        private readonly ICommunicationProvider _communicationProvider;
        private readonly SynchroClock _synchronizationClock;

        public ESimulationState SimulationState => _simulationState;

        public PathFindingSimulator(in SimulationSetting simulationSetting, ILogger logger, ICommunicationProvider communicationProvider) : base(logger)
        {
            _simulationState = ESimulationState.Stop;
            _setting = simulationSetting;
            _communicationProvider = communicationProvider;
            _synchronizationClock = new SynchroClock(simulationSetting.TickFrequency, _communicationProvider, logger);
            _synchronizationClock.OnTimerElapsed += TimerElapsedHandler;

            LoadDefaultScenario(_setting.SelectedScenario);

            _communicationProvider.Subscribe<SimulationStateUpdate>(OnSimulationStateChange);
            _communicationProvider.Subscribe<SimulationSpeedUpdate>(OnSimulationSpeedChange);
        }

        private void TimerElapsedHandler(in TimeSpan delta)
        {
            throw new NotImplementedException();
        }

        private void LoadDefaultScenario(in ScenarioInfo selectedScenario)
        {
            throw new NotImplementedException();
        }

        private void OnSimulationStateChange(SimulationStateUpdate simulationUpdate)
        {
            _simulationState = simulationUpdate.SimulationState;
            switch (_simulationState)
            {
                case ESimulationState.Start:
                    _synchronizationClock.Start();
                    break;
                case ESimulationState.Pause:
                    _synchronizationClock.Stop();
                    break;
                case ESimulationState.Stop:
                    _synchronizationClock.Stop();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(simulationState), simulationState, null);
            }
        }

        private void OnSimulationSpeedChange(SimulationSpeedUpdate simulationUpdate)
        {

        }
    }
}

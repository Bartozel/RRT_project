using Data;
using Logging;
using MediatR;
using System;

namespace PathFindingSimulatorAgregator
{
    public class PathFindingSimulator : BaseLogger
    {
        private ESimulationState _simulationState;
        private readonly SimulationSetting _setting;
        private readonly IMediator _communicationProvider;
        private readonly SynchroClock _synchronizationClock;

        public ESimulationState SimulationState => _simulationState;

        public PathFindingSimulator(in SimulationSetting simulationSetting, ILogger logger, IMediator communicationProvider) : base(logger)
        {
            _simulationState = ESimulationState.Stop;
            _setting = simulationSetting;
            _communicationProvider = communicationProvider;
            _synchronizationClock = new SynchroClock(simulationSetting.TickFrequency, _communicationProvider, logger);
            _synchronizationClock.OnTimerElapsed += TimerElapsedHandler;

            LoadDefaultScenario(_setting.SelectedScenario);
        }

        private void TimerElapsedHandler(in TimeSpan delta)
        {
            throw new NotImplementedException();
        }

        private void LoadDefaultScenario(in ScenarioInfo selectedScenario)
        {
            throw new NotImplementedException();
        }
    }
}

using System;

namespace Data
{
    public readonly record struct SimulationSetting
    {
        public ScenarioInfo SelectedScenario { get; init; }

        public TimeSpan TickFrequency { get; init; }
    }
}

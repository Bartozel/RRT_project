using System;

namespace Data
{
    public record SimulationSetting
    {
        public ScenarioInfo SelectedScenario { get; init; }

        public TimeSpan TickFrequency { get; init; }
    }
}

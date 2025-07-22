using Data;
using MediatR;

namespace Communication.Notifications
{
    public record class ApplicationStateChangedNotification : ISimulationNotification
    {
        public ESystemState SystemState { get; internal set; }
    }
}

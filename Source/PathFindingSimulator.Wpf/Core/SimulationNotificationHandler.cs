using MediatR;
using Communication.Notifications;
using System.Threading.Tasks;
using System.Threading;

namespace PathFindingSimulator.Wpf
{
    public class SimulationNotificationHandler<T> : INotificationHandler<T>
        where T : ISimulationNotification
    {
        private readonly SimulationManager _simulationManager;

        public SimulationNotificationHandler(SimulationManager simulationManager)
        {
            _simulationManager = simulationManager;
        }

        public Task Handle(T notification, CancellationToken cancellationToken)
        {
            return _simulationManager.HandleNotificationAsync(notification, cancellationToken);
        }
    }
}

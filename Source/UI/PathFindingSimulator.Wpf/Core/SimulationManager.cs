using Communication.Notifications;
using Communication.Requests;
using Data;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PathFindingSimulator.Wpf
{
    public class SimulationManager
    {
        private readonly IMediator _mediator;
        private SimulationSetting _currentSettings;

        public SimulationManager(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        internal Task HandleNotificationAsync<T>(T notification, CancellationToken cancellationToken) where T : ISimulationNotification
        {
            return notification switch
            {
                ApplicationStateChangedNotification stateChanged => HandleApplicationStateChanged(stateChanged, cancellationToken),
                _ => Task.CompletedTask
            };
        }

        public async Task HandleApplicationStateChanged(ApplicationStateChangedNotification notification, CancellationToken cancellationToken)
        {
            switch (notification.SystemState)
            {
                case ESystemState.Running:
                    // Handle running state

                    _currentSettings = await _mediator.Send(new GetSimulationSetting(), cancellationToken);
                    break;
                case ESystemState.Paused:
                    // Handle paused state
                    break;
                case ESystemState.Stopped:
                    // Handle stopped state
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}

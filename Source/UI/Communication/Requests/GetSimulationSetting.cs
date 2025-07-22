using Data;
using MediatR;

namespace Communication.Requests
{
    public class GetSimulationSetting : IRequest<SimulationSetting>
    {
    }
}
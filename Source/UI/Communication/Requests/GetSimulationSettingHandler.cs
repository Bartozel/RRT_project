using Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Communication.Requests
{
    public class GetSimulationSettingHandler : IRequestHandler<GetSimulationSetting, SimulationSetting>
    {
        private readonly ISimulationSettingService _settingService;

        public GetSimulationSettingHandler(ISimulationSettingService settingService)
        {
            _settingService = settingService;
        }

        public Task<SimulationSetting> Handle(GetSimulationSetting request, CancellationToken cancellationToken)
        {
            var setting = _settingService.GetSimulationSetting();
            return Task.FromResult(setting);
        }
    }
}

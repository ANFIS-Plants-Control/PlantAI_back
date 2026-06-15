using Application.Interfaces.Services;
using Microsoft.AspNetCore.SignalR;

namespace TelemetryService.Hubs
{
    public class SensorsDataHub : Hub
    {

        private ISensorDataService _sensorDataService;
        private IDataGroupService _dateGroupService;
        private IMqttClientsService _mqttClientService;
        private IBrokerParametersService _brokerParametersService;
        private ITopicService _topiService;
        public SensorsDataHub(ISensorDataService sensorDataService, 
                              IDataGroupService dateGroupService, 
                              IMqttClientsService mqttClientService, 
                              IBrokerParametersService brokerParametersService, 
                              ITopicService topiService)
        {
            _sensorDataService = sensorDataService;
            _dateGroupService = dateGroupService;
            _mqttClientService = mqttClientService;
            _brokerParametersService = brokerParametersService;
            _topiService = topiService;
        }

        public async Task GetData()
        {
            try
            {
                var data = await _sensorDataService.GetAllAsync();
                await Clients.All.SendAsync("Receive", data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

using System.Text.Json;
using Application.DTOs;
using Application.Extensions;
using Application.Interfaces.SensorData;

namespace Application.Services
{
    public class SensorDataService : ISensorDataService
    {
        private readonly ISensorDataProvider _sensorDataProvider;
        public SensorDataService(ISensorDataProvider sensorDataProvider)
        {
            _sensorDataProvider = sensorDataProvider;
        }

        public async Task<ClimatStatusDto?> GetClimatStatus()
        {
            var content = await _sensorDataProvider.GetSensorDataAsync();
            var data = JsonSerializer.Deserialize<List<SensorDataDto>>(content);
            var climateStatus = data?.DataGroupToClimatStatus();
            return climateStatus;
        }
    }
}

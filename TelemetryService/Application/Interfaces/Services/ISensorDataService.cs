using Application.DTOs.SensorData;
using TelemetryService.Application.DTOs.SensorData;

namespace Application.Interfaces.Services
{
    public interface ISensorDataService
    {
        public Task<IEnumerable<SensorDataResponseDto>> GetAllAsync();
        public Task SaveAsync(IEnumerable<CreateSensorDataDto> dto, int groupId);
        public Task<GroupedDataResponseDto> GetLastDataAsync();
    }
}
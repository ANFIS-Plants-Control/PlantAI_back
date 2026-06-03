using Core.Models;
using TelemetryService.Application.DTOs.SensorData;

namespace Application.Interfaces.Services
{
    public interface ISensorDataService
    {
        public Task<IEnumerable<SensorDataResponseDto>> ReadAllAsync();
        public Task SaveAsync(IEnumerable<CreateSensorDataDto> dto, int groupId);
    }
}
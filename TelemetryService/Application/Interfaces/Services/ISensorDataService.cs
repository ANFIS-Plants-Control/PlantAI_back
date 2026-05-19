using Core.Models;
using TelemetryService.Application.DTOs.SensorData;

namespace Application.Interfaces.Services
{
    public interface ISensorDataService
    {
        public Task<IEnumerable<SensorDataResponseDto>> ReadAllAsync();
        public Task WriteAsync(CreateSensorDataDto dto);
    }
}
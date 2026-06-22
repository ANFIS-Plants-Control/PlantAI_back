using TelemetryService.Application.DTOs.SensorData;

namespace Application.DTOs.SensorData
{
    public record GroupedDataResponseDto(int Id, DateTime Date, IEnumerable<SensorDataResponseDto> sensorData);
}

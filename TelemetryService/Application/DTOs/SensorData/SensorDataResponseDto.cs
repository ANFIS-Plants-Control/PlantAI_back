namespace TelemetryService.Application.DTOs.SensorData;

public record SensorDataResponseDto(int Id, double Value, int SensorTypeId, int DataGroupId);
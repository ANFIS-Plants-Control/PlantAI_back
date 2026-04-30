namespace TelemetryService.Application.DTOs.SensorData;

public record SensorDataResponseDto(int Id, double Value, DateTime Date, int SensorTypeId);
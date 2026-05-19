namespace TelemetryService.Application.DTOs.SensorData;

public record CreateSensorDataDto(double Value, DateTime Date, int SensorTypeId, int GroupId);
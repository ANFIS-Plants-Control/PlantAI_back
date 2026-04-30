namespace TelemetryService.Core.Models;

public class SensorData
{
    public int Id { get; init; }
    public double Value { get; init; }
    public DateTime Date { get; init; }
    public int SensorTypeId { get; init; }
    public SensorType? SensorType { get; init; }
}
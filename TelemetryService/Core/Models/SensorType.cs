namespace Core.Models;

public class SensorType
{
    public int Id { get; init; }
    public string TypeName { get; init; } = String.Empty;
    public IEnumerable<SensorData> SensorsData { get; init; }
}
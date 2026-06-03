namespace Core.Models;

public class SensorType
{
    public int Id { get; set; }
    public string TypeName { get; set; } = String.Empty;
    public IEnumerable<SensorData> SensorsData { get; set; }
}
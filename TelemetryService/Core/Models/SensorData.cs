namespace Core.Models;

public class SensorData
{
    public int Id { get; set; }
    public double Value { get; set; }
    public int SensorTypeId { get; set; }
    public int GroupId { get; set; }
    public SensorType SensorType { get; set; }
    public DataGroup DataGroup { get; set; }
}
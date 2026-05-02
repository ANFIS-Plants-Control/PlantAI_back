namespace Core.Models;

public class SensorData
{
    public int Id { get; init; }
    public double Value { get; init; }
    public DateTime Date { get; init; }
    public int SensorTypeId { get; init; }
    public int GroupId { get; init; }
    public SensorType? SensorType { get; init; }
    public DataGroup DataGroup { get; init; }
}
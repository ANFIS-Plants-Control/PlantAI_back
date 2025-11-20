using PlantAI.Interfaces;

namespace PlantAI.Models;

public class SensorsData : IEntity
{
    public int Id { get; set; }

    public decimal Data { get; set; }

    public DateTime Date { get; set; }

    public int SensorTypeId { get; set; }

    public virtual SensorType Type { get; set; } = null!;
}

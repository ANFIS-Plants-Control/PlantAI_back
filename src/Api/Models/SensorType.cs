using PlantAI.Interfaces;

namespace PlantAI.Models;

public partial class SensorType : IEntity
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public virtual ICollection<SensorsData> SensorsData { get; set; } = new List<SensorsData>();
}

using PlantAI.Interfaces;

namespace PlantAI.Models;

public partial class Answer : IEntity
{
    public int Id { get; set; }

    public int SensorId { get; set; }

    public DateTime Date { get; set; }

    public int? StatisticId { get; set; }

    public string Recommend { get; set; } = null!;

    public virtual SensorsData Sensor { get; set; } = null!;

    public virtual Statistic? Statistic { get; set; }
}

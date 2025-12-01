using PlantAI.Interfaces;

namespace PlantAI.Models;

public partial class Report : IEntity
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public int UserId { get; set; }

    public virtual ICollection<Statistic> Statistics { get; set; } = new List<Statistic>();

    public virtual User User { get; set; } = null!;
}

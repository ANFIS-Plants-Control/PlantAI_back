using PlantAI.Interfaces;

namespace PlantAI.Models;

public partial class Statistic : IEntity
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public int? ReportId { get; set; }

    public string ChangeHour { get; set; } = null!;

    public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();

    public virtual Report? Report { get; set; }
}

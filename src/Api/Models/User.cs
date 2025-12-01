using PlantAI.Interfaces;

namespace PlantAI.Models;

public partial class User : IEntity
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int RoleId { get; set; }

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();

    public virtual UserRole Role { get; set; } = null!;
}

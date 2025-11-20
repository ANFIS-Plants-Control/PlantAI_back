using PlantAI.Interfaces;

namespace PlantAI.Models;

public partial class UserRole : IEntity
{
    public int Id { get; set; }

    public bool Admin { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}

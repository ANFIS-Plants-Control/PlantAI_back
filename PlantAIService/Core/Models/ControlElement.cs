namespace Core.Models
{
    public class ControlElement
    {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Fnn? Fnn { get; set; }
    }
}

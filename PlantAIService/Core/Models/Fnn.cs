namespace Core.Models
{
    public class Fnn
    {

        public int Id { get; set; }
        public string ParamsAddr { get; set; } = string.Empty;
        public int ControlId { get; set; }
        public ControlElement? ControlElement { get; set; }
        public List<FnnAnswer> FnnAnswers { get; set; } = new List<FnnAnswer>();

    }
}

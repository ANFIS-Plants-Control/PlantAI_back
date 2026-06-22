namespace Core.Models
{
    public class Fnn
    {

        public int Id { get; set; }
        public string ParamsAddr { get; set; }
        public int ControlId { get; set; }
        public ControlElement ControlElement { get; set; }
        public List<FnnAnswer> FnnAnswers { get; set; }

    }
}

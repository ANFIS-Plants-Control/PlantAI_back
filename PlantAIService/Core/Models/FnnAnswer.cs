namespace Core.Models
{
    public class FnnAnswer
    {

        public int Id { get; set; }
        public int FnnId { get; set; }
        public int DataGroupId { get; set; }
        public int UserId { get; set; }
        public int Answer { get; set; }
        public DateTime DateTime { get; set; }
        public Fnn Fnn { get; set; }

    }
}

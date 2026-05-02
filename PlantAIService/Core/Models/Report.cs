namespace Core.Models
{
    public class Report
    {

        public int Id { get; init; }
        public DateTime Date { get; init; }
        
        public int UserId { get; set; }
        public int NetAnserId { get; set; }

        public NetAnswerStatistics NetAnswerStatistics { get; set; }
    }
}

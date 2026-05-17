namespace Core.Models
{
    public class DataGroup
    {

        public int Id { get; init; }
        public DateTime GroupDate { get; init; }
        public IEnumerable<SensorData> SensorsData { get; init; }
    }
}

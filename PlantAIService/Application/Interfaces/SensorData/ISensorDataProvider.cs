namespace Application.Interfaces.SensorData
{
    public interface ISensorDataProvider
    {

        Task<string> GetSensorDataAsync();

    }
}

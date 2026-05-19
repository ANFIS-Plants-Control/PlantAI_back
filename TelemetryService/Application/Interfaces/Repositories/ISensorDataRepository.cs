using Core.Models;

namespace Application.Interfaces.Repositories
{
    public interface ISensorDataRepository
    {
        Task WrightAsync(SensorData data);
        Task<List<SensorData>> ReadAllAsync();
    }
}

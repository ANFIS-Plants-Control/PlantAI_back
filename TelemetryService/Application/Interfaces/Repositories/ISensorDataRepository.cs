using Core.Models;

namespace Application.Interfaces.Repositories
{
    public interface ISensorDataRepository
    {
        Task SaveAsync(SensorData data);
        Task SaveAsync(IEnumerable<SensorData> data);
        Task<List<SensorData>> ReadAllAsync();
    }
}

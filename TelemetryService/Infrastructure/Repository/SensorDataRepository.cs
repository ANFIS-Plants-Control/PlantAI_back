using Application.Interfaces.Repositories;
using Core.Models;

namespace Infrastructure.Repository
{
    public class SensorDataRepository : ISensorDataRepository
    {
        public Task<IEnumerable<SensorData>> ReadAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task WrightAsync(SensorData data)
        {
            throw new NotImplementedException();
        }
    }
}

using Core.Models.mqtt;

namespace Application.Interfaces.Repositories
{
    public interface IBrokersParametersRepository
    {
        public Task<IEnumerable<BrokerParpameters>> GetAllAsync();
        public Task<IEnumerable<BrokerParpameters>> GetBrokersWithClientsAsync();
        public Task CreateAsync(BrokerParpameters entity);
        public Task<BrokerParpameters> GetByAddressAsync(string host, int port);
    }
}

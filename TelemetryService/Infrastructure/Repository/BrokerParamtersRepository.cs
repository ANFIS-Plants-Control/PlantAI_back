using Application.Interfaces.Repositories;
using Core.Models.mqtt;
using Microsoft.EntityFrameworkCore;
using TelemetryService.Infrastructure.Persistant;

namespace Infrastructure.Repository
{
    public class BrokerParamtersRepository : IBrokersParametersRepository
    {
        private readonly TelemetryDbContext _dbContext;
        public BrokerParamtersRepository(TelemetryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(BrokerParpameters entity)
        {
            await _dbContext.BrokerParameters
                .AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<BrokerParpameters>> GetAllAsync()
        {
            return await _dbContext.BrokerParameters
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<BrokerParpameters>> GetBrokersWithClientsAsync()
        {
            return await _dbContext.BrokerParameters
                .AsNoTracking()
                .Include(x => x.Clients)
                .ToListAsync();
        }

        public async Task<BrokerParpameters> GetByAddressAsync(string host, int port)
        {
            return await _dbContext.BrokerParameters
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Host == host && x.Port == port);
        }
    }
}

using Application.Interfaces.Repositories;
using Core.Models.mqtt;
using Microsoft.EntityFrameworkCore;
using TelemetryService.Infrastructure.Persistant;

namespace Infrastructure.Repository
{
    public class MqttClientsRepository : IMqttClientsRepository
    {

        private readonly TelemetryDbContext context;
        public MqttClientsRepository(TelemetryDbContext context)
        {
            this.context = context;
        }

        public async Task CreateSubscriptionAsync(MqttClient subscription)
        {
            await context.MqttClients.AddAsync(subscription);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MqttClient>> GetAsync()
        {
            return await context.MqttClients
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<MqttClient> GetByClientIdAsync(string clientId)
        {
            return await context.MqttClients
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ClientId == clientId);
        }

        public async Task<IEnumerable<BrokerParpameters>> GetDashboardAsync()
        {
            return await context.BrokerParameters
                .AsNoTracking()
                .Include(x => x.Clients)
                    .ThenInclude(x => x.Topic)
                .ToListAsync();
        }
    }
}

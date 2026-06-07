using Application.Interfaces.Repositories;
using Core.Models.mqtt;
using Microsoft.EntityFrameworkCore;
using TelemetryService.Infrastructure.Persistant;

namespace Infrastructure.Repository
{
    public class MqttClientsRepository : IMqttClientsRepository
    {

        private readonly TelemetryDbContext _context;
        public MqttClientsRepository(TelemetryDbContext context)
        {
            _context = context;
        }

        public async Task CreateClientAsync(MqttClient subscription)
        {
            await _context.MqttClients.AddAsync(subscription);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MqttClient>> GetAsync()
        {
            return await _context.MqttClients
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<MqttClient> GetByClientIdAsync(string clientId)
        {
            return await _context.MqttClients
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ClientId == clientId);
        }

        public async Task<MqttClient> GetByClientIdWithTopicsAsync(string clientId)
        {
            return await _context.MqttClients
                .Include(x => x.Topics)
                .FirstOrDefaultAsync(x => x.ClientId == clientId);
        }

        public async Task<MqttClient> GetByIdAsync(int id)
        {
            return await _context.MqttClients
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<MqttClient>> GetClientsWithTopicsAsync()
        {
            return await _context.MqttClients
                .AsNoTracking()
                .Include(x => x.Topics)
                .ToListAsync();
        }
    }
}

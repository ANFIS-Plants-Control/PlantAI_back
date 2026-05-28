using Application.Interfaces.Repositories;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using TelemetryService.Infrastructure.Persistant;

namespace Infrastructure.Repository
{
    public class MqttClientOptionsRepository : IMqttClientOptionsRepository
    {

        private readonly TelemetryDbContext context;
        public MqttClientOptionsRepository(TelemetryDbContext context)
        {
            this.context = context;
        }

        public async Task CreateClientAsync(MqttClientOptions options)
        {
            await context.MqttClientOptions.AddAsync(options);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MqttClientOptions>> GetAsync()
        {
            return await context.MqttClientOptions
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<MqttClientOptions> GetByClientIdAsync(string ClientId)
        {
            return await context.MqttClientOptions
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ClientId == ClientId);
        }

        public async Task<MqttClientOptions> GetByIdAsync(int Id)
        {
            return await context.MqttClientOptions
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == Id);
        }
    }
}

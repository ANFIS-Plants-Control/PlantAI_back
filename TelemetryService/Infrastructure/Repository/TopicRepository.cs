using Application.Interfaces.Repositories;
using Core.Models.mqtt;
using Microsoft.EntityFrameworkCore;
using TelemetryService.Infrastructure.Persistant;

namespace Infrastructure.Repository
{
    public class TopicRepository : ITopicRepository
    {
        private readonly TelemetryDbContext _dbContext;
        public TopicRepository(TelemetryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(TopicDefinition entity)
        {
            await _dbContext.TopicDefinitions.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TopicDefinition>> GetAllAsync()
        {
            return await _dbContext.TopicDefinitions
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<TopicDefinition> GetByIdAsync(int id)
        {
            return await _dbContext.TopicDefinitions
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TopicDefinition> GetByTopicStringAsync(string topic)
        {
            return await _dbContext.TopicDefinitions
               .AsNoTracking()
               .FirstOrDefaultAsync(x => x.Topic == topic);
        }
    }
}

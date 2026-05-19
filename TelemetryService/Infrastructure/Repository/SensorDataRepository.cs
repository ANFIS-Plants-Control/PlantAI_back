using Application.Interfaces.Repositories;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using TelemetryService.Infrastructure.Persistant;

namespace Infrastructure.Repository
{
    public class SensorDataRepository : ISensorDataRepository
    {
        private readonly TelemetryDbContext _context;
        public SensorDataRepository(TelemetryDbContext context)
        {
            _context = context;
        }

        public async Task<List<SensorData>> ReadAllAsync() =>
            await _context.SensorsData
            .AsNoTracking()
            .ToListAsync();


        public async Task WrightAsync(SensorData data)
        {
            await _context.AddAsync(data);
        }
    }
}

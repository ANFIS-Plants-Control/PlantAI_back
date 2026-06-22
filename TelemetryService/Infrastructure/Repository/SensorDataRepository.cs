using Application.Interfaces.Repositories;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using TelemetryService.Infrastructure.Persistant;

namespace Infrastructure.Repository
{
    public class SensorDataRepository : ISensorDataRepository
    {
        private readonly TelemetryDbContext _context;
        private IQueryable<SensorData> _sensors;
        public SensorDataRepository(TelemetryDbContext context)
        {
            _context = context;
            _sensors = _context.SensorsData.AsNoTracking();
        }

        public async Task<List<SensorData>> GetAllAsync() =>
            await _sensors.ToListAsync();        

        public async Task SaveAsync(SensorData data)
        {
            await _context.SensorsData.AddAsync(data);
            await _context.SaveChangesAsync();
        }

        public async Task SaveAsync(IEnumerable<SensorData> data)
        {
            await _context.SensorsData.AddRangeAsync(data);
            await _context.SaveChangesAsync();
        }
    }
}

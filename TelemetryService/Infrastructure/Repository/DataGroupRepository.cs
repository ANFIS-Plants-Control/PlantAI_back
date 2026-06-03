using Application.Interfaces.Repositories;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using TelemetryService.Infrastructure.Persistant;

namespace Infrastructure.Repository
{
    public class DataGroupRepository : IDataGroupRepository
    {
        private readonly TelemetryDbContext _context;
        public DataGroupRepository(TelemetryDbContext context)
        {
            _context = context;
        }

        public async Task<DataGroup> GetLastGroupAsync()
        {
            return await _context.DataGroups
                .AsNoTracking()
                .OrderByDescending(g => g.Id)
                .FirstOrDefaultAsync();
        }

        public async Task SaveAsync(DataGroup data)
        {
            await _context.DataGroups.AddAsync(data);
            await _context.SaveChangesAsync();
        }
    }
}

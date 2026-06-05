using Application.Interfaces.Repositories;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using TelemetryService.Infrastructure.Persistant;

namespace Infrastructure.Repository
{
    public class DataGroupRepository : IDataGroupRepository
    {
        private readonly TelemetryDbContext _context;
        private IQueryable<DataGroup> _dataGroups;
        public DataGroupRepository(TelemetryDbContext context)
        {
            _context = context;
            _dataGroups =  _context.DataGroups
                .AsNoTracking();
        }
        
        public async Task<IEnumerable<DataGroup>> GetAllGroupsAsync()
        {
            var a = _context.DataGroups.AsNoTracking();
            return await _dataGroups
                .ToListAsync();
        }

        public async Task<DataGroup> GetLastGroupAsync()
        {
            return await _dataGroups
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

using Application.Interfaces.Repositories;
using TelemetryService.Infrastructure.Persistant;

namespace Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TelemetryDbContext _context;
        public UnitOfWork(TelemetryDbContext context)
        {
            _context = context;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

using PlantAI.Interfaces;
using PlantAI.Models;

namespace PlantAI.Repositories
{
    public class ReportRepository : IRepository<Report>
    {

        ApplicationDbContext _context;
        public ReportRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(Report entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Report entity)
        {
            throw new NotImplementedException();
        }

        public List<Report> Read()
        {
            throw new NotImplementedException();
        }

        public Report ReadById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Report entity)
        {
            throw new NotImplementedException();
        }
    }
}

using PlantAI.Interfaces;
using PlantAI.Models;

namespace PlantAI.Repositories
{
    public class StatisticRepository : IRepository<Statistic>
    {

        ApplicationDbContext _context;
        public StatisticRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(Statistic entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Statistic entity)
        {
            throw new NotImplementedException();
        }

        public List<Statistic> Read()
        {
            throw new NotImplementedException();
        }

        public Statistic ReadById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Statistic entity)
        {
            throw new NotImplementedException();
        }
    }
}

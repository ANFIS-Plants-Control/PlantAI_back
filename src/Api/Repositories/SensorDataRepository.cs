using PlantAI.Interfaces;
using PlantAI.Models;

namespace PlantAI.Repositories
{
    public class SensorDataRepository : IRepository<SensorsData>
    {

        ApplicationDbContext _context;
        public SensorDataRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(SensorsData entity)
        {
            throw new NotImplementedException();
        }
        public void Delete(SensorsData entity)
        {
            throw new NotImplementedException();
        }

        public List<SensorsData> Read()
        {
            throw new NotImplementedException();
        }

        public SensorsData ReadById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(SensorsData entity)
        {
            throw new NotImplementedException();
        }
    }
}

using PlantAI.Interfaces;
using PlantAI.Models;

namespace PlantAI.Repositories
{
    public class AnswerRepository : IRepository<Answer>
    {

        ApplicationDbContext _context;

        public AnswerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(Answer entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Answer entity)
        {
            throw new NotImplementedException();
        }

        public List<Answer> Read()
        {
            throw new NotImplementedException();
        }

        public Answer ReadById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Answer entity)
        {
            throw new NotImplementedException();
        }
    }
}

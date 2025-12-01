using Microsoft.EntityFrameworkCore;
using PlantAI.Interfaces;
using PlantAI.Models;

namespace PlantAI.Repositories
{
    public class UserRepository : IRepository<User>
    {

        ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(User entity)
        {
            _context.Users.Add(entity);
        }

        public void Delete(User entity)
        {
            _context.Users.Remove(entity);
        }

        public List<User> Read()
        {
            return _context.Users.ToList();
        }

        public User ReadById(int id)
        {
            return _context.Users.Where(u => u.Id == id).FirstOrDefault() ?? new User();
        }

        public void Update(User entity)
        {
            _context.Users.Update(entity);
        }
    }
}

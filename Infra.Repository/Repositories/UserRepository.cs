using Domain;
using Infra.Data.Context;
using Infra.Data.Interfaces;

namespace Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        readonly ApiRestRedis_Context _context;

        public UserRepository(ApiRestRedis_Context context)
        {
            _context = context;
        }

        public async Task<int> Add(User user)
        {
            _context.User.Add(user);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Remove(User user)
        {
            _context.User.Remove(user);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(User user)
        {
            _context.User.Update(user);
            return await _context.SaveChangesAsync();
        }

        public async Task<ICollection<User>> Get()
        {
            return _context.User.ToList();
        }

        public async Task<User> GetById(int id)
        {
            return _context.User.SingleOrDefault(u => u.Id == id);
        }
    }
}
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<int> Add(User user);
        Task<int> Remove(User user);
        Task<int> Update(User user);
        Task<ICollection<User>> Get();
        Task<User> GetById(int id);
    }
}

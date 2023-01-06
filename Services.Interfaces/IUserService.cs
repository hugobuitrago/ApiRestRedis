using Domain;
using Domain.DTO;

namespace Services.Interfaces
{
    public interface IUserService
    {
        Task<User> Get(int Id);
        Task Post(UserDTO user);
    }
}
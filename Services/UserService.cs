using Domain;
using Domain.DTO;
using Infra.Data.Interfaces;
using Infra.Data.Interfaces.Caching;
using Newtonsoft.Json;
using Services.Interfaces;
using System.Text.Json.Serialization;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICachingService _cachingService;

        public UserService(IUserRepository userRepository, ICachingService cachingService)
        {
            _userRepository = userRepository;
            _cachingService = cachingService;
        }

        public async Task<User> Get(int Id)
        {
            var userCache = await _cachingService.GetAsync(Id.ToString());
            User? user;

            if (!string.IsNullOrWhiteSpace(userCache))
            {
                user = JsonConvert.DeserializeObject<User>(userCache);
                return user;
            }                
            else
            {
                user = await _userRepository.GetById(Id);
                await _cachingService.SetAsync(Id.ToString(), JsonConvert.SerializeObject(user));
            }
            return user;
        }

        public async Task Post(UserDTO userDTO)
        {
            //I could to do using AutoMapper or create a layer to Mapper the entitys, but its not the goal of this demonstration
            User user = new User()
            {
                Email = userDTO.Email,
                Password = userDTO.Password,
                Name = userDTO.Name
            };

            int result = await _userRepository.Add(user);
        }
    }
}
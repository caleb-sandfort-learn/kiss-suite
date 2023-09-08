using EhsUserWebApi.Data;
using EhsUserWebApi.Models;
using EhsUserWebApi.Repository;
using KissRepository;

namespace EhsUserWebApi.Service
{
    public class UserService
    {
        private readonly IGenericRepository<User> _userRepository;

        public UserService(IGenericRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Add(User user)
        {
            bool isAdded = false;
            try
            {
                isAdded = await _userRepository.Add(user);
            }
            catch (Exception ex)
            {
            }
            return isAdded;
        }

        public async Task<List<User>> GetAll()
        {
            List<User> users = new List<User>();
            try
            {
                users = (await _userRepository.GetAll()).ToList();
            }
            catch (Exception ex)
            {
            }

            return users;
        }

        public async Task<User> Get(int Id)
        {
            User user = new User();
            try
            {
                user = await _userRepository.GetById(Id);
            }
            catch (Exception ex)
            {
            }

            return user;
        }

        public async Task<bool> Update(User user)
        {
            bool isUpdated = false;
            try
            {
                isUpdated = await _userRepository.Update(user);
            }
            catch (Exception ex)
            {
            }

            return isUpdated;
        }

        public async Task<bool> Delete(User user)
        {
            bool isDeleted = false;
            try
            {
                isDeleted = await _userRepository.Delete(user);
            }
            catch (Exception ex)
            {
            }
            return isDeleted;
        }
    }
}

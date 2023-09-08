using EhsUserWebApi.Models;
using KissRepository;

namespace EhsUserWebApi.Repository
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(string connectionstring) : base(connectionstring)
        {
        }
    }
}

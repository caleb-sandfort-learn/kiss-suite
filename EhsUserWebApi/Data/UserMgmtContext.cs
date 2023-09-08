using EhsUserWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EhsUserWebApi.Data
{
    public class UserMgmtContext : DbContext
    {
        public UserMgmtContext(DbContextOptions<UserMgmtContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}

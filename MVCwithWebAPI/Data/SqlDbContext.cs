using MVCwithWebAPI.Models;
using System.Data.Entity;

namespace MVCwithWebAPI.Data

{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext() : base("name=SqlConn")
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }  
        public DbSet<Role> Roles { get; set; }
    }
}
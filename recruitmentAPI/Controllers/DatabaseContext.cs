using Microsoft.EntityFrameworkCore;

namespace recruitmentAPI.Controllers
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {
            
        }
        public DbSet<ToDoTable> ToDoTable { get; set; }
    }
}

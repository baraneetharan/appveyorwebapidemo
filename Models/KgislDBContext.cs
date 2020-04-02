using Microsoft.EntityFrameworkCore;

namespace appveyorwebapidemo.Models
{
    public class KgislDBContext : DbContext
    {
        public KgislDBContext(DbContextOptions<KgislDBContext> options) : base(options)
        {


        }


        public DbSet<Employee> Employees { get; set; }
        public DbSet<Playlist> PlaylistItems { get; set; }
        public DbSet<Emplist> Emplists { get; set; }

    }
}
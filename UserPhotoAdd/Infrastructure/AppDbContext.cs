using Microsoft.EntityFrameworkCore;
using UserPhotoAdd.Model;

namespace UserPhotoAdd.Infrastructure
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {        }

        public DbSet<User> Users { get; set; }
        public DbSet<Photo> Photos { get; set; }
   
        
    }
}

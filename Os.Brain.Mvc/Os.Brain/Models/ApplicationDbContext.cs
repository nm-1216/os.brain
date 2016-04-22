using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Os.Brain.Models;
using Os.Brain.Models.WMS;

namespace Os.Brain.Models
{

    public class ApplicationDbContext : AppDbContext<User>
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //    //optionsBuilder.UseSqlServer(@"Server=.;Database=Os.Brain;Trusted_Connection=True;MultipleActiveResultSets=true;");

        //    base.OnConfiguring(optionsBuilder);
        //}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }


        public DbSet<Application> Application { get; set; }

        public DbSet<Path> Path { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<Role> Role { get; set; }

        public DbSet<Group> Group { get; set; }
        


    }

}

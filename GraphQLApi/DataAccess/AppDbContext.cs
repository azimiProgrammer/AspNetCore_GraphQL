using GraphQLApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQLApi.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
              : base(options)
        { }


        public DbSet<Course> Course { get; set; }
        public DbSet<Section> Section { get; set; }
        public DbSet<Rating> Rating { get; set; }
        public DbSet<Lecture> Lecture { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lecture>()
                .HasDiscriminator<string>("Discriminator")
                .HasValue<Subject>("Subject")
                .HasValue<Assignment>("Assignment");
        }
    }
}

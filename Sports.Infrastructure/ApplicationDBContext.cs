using Microsoft.Build.Execution;
using Microsoft.EntityFrameworkCore;
using Sports.Models;

namespace Sports.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
   : base(options)
        {

        }
        public DbSet<Sport> Sports { get; set; }

        public DbSet<Meta> Metas { get; set; }
        public DbSet<NavigationInfo> NavigationInfos { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<RelatedSportsEvent> RelatedSportsEvents { get; set; }
        public DbSet<States> States { get; set; }

        public DbSet<Value> Values { get; set; }

        public DbSet<WeatherConditions> WeatherConditions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure DateAndTimeInfo as keyless entity
            modelBuilder.Entity<DateAndTimeInfo>()
                .HasNoKey();
            modelBuilder.Entity<Meta>()
                        .HasNoKey();

            modelBuilder.Entity<Property>()
                     .HasNoKey();

            modelBuilder.Entity<RelatedSportsEvent>()
                   .HasNoKey();
            modelBuilder.Entity<Sport>()
               .HasNoKey();
            modelBuilder.Entity<States>()
             .HasNoKey();
            modelBuilder.Entity<Value>()
       .HasNoKey();
            modelBuilder.Entity<WeatherConditions>()
       .HasNoKey();


            base.OnModelCreating(modelBuilder);
        }
    }
}

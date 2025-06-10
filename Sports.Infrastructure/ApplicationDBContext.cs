using Microsoft.Build.Execution;
using Microsoft.EntityFrameworkCore;
using Sports.Models;

namespace Sports.Infrastructure
{
    public class ApplicationDBContext : DbContext
    {

        public DbSet<Sport> Sports { get; set; }

        public DbSet<Meta> Metas { get; set; }
        public DbSet<NavigationInfo> NavigationInfos { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<RelatedSportsEvent> RelatedSportsEvents { get; set; }
        public DbSet<States> Properties { get; set; }

        public DbSet<Value> Values { get; set; }

        public DbSet<WeatherConditions> WeatherConditions { get; set; }



    }
}

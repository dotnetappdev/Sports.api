﻿using Microsoft.Build.Execution;
using Microsoft.EntityFrameworkCore;

using Sports.Models;
using System.Drawing;
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
        public DbSet<State> States { get; set; }

        public DbSet<Value> Values { get; set; }

        public DbSet<WeatherConditions> WeatherConditions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sport>()
       .HasOne(s => s.weather_conditions)
       .WithOne(w => w.Sport)
       .HasForeignKey<WeatherConditions>(w => w.SportsId); // Sp
            base.OnModelCreating(modelBuilder);
        }
    }
}

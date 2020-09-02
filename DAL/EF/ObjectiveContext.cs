using KASSSATestTask.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace KASSSATestTask.Models.EF
{
    public class ObjectiveContext : DbContext
    {
        public DbSet<Objective> Objectives { get; set; }

        public ObjectiveContext(DbContextOptions<ObjectiveContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Objective>().Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();
        }
    }
}

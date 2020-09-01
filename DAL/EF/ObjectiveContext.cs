using KASSSATestTask.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace KASSSATestTask.Models.EF
{
    public class ObjectiveContext : DbContext
    {
        public DbSet<Objective> Objective { get; set; }

        public ObjectiveContext(DbContextOptions<ObjectiveContext> options)
            : base(options)
        {
        }
    }
}

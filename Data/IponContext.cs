using Microsoft.EntityFrameworkCore;
using Niwanna.Models;

namespace Niwanna.Data
{
    public class IponContext : DbContext
    {
        public IponContext(DbContextOptions<IponContext> options) : base(options) { }

        public DbSet<Ipon> Ipons { get; set; }
        public DbSet<IponEntry> Entries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IponEntry>()
                .Property(i => i.Date)
                .HasColumnType("timestamp with time zone"); // EF -> timestamptz

            base.OnModelCreating(modelBuilder);
        }
    }
}

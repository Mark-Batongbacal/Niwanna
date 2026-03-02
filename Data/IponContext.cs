using Microsoft.EntityFrameworkCore;
using Niwanna.Models;

namespace Niwanna.Data
{
    public class IponContext : DbContext
    {
        public IponContext(DbContextOptions<IponContext> options) : base(options) { }

        public DbSet<Ipon> Ipons { get; set; }
        public DbSet<IponEntry> Entries { get; set; }
    }
}

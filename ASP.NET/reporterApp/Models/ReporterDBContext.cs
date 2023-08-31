using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Report.Models
{
    public class ReporterDBContext : DbContext
    {
        public ReporterDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Reporter> Reporter { get; set; }
    }
}

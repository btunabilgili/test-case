using Microsoft.EntityFrameworkCore;
using RiskAnalysis.Domain;

namespace RiskAnalysis.Persistance.Contexts
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Agreement> Agreements { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<JobSubject> JobSubjects { get; set; }
    }
}

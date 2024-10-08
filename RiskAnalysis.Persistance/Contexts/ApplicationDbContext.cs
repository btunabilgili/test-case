using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RiskAnalysis.Common.Enums;
using RiskAnalysis.Domain;

namespace RiskAnalysis.Persistance.Contexts
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Agreement> Agreements { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<JobSubject> JobSubjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agreement>()
                .Property(a => a.Status)
                .HasConversion(new EnumToStringConverter<AgreementStatus>());

            base.OnModelCreating(modelBuilder);
        }
    }
}

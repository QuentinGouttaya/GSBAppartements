using Microsoft.EntityFrameworkCore;
using GSBAppartement.Domain.Appartement;

namespace GSBAppartement.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Appartement> Appartements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure your entity mappings and relationships here
            // For example, you might have:
            // modelBuilder.Entity<Appartement>().ToTable("Appartements");
        }
    }
}
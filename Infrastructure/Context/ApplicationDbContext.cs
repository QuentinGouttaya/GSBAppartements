using Microsoft.EntityFrameworkCore;
using GSBAppartement.Domain.Appartement;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
        public DbSet<Appartement> Appartements { get; set; }
    }

using Microsoft.EntityFrameworkCore;

namespace LizardPirates.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options){}

        public DbSet<LizardPirate> LizardCrew { get; set; }
    }
}
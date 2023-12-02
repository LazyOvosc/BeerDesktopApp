using WPFSipBiteUnite.DataBaseClasses;
using Microsoft.EntityFrameworkCore;

namespace WPFSipBiteUnite.DbContext
{
    public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(): base()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Server=localhost;Port=5432;User Id=postgres;Password=1111;Database=DbSipBiteUnite;");
            }
        }

    }
}

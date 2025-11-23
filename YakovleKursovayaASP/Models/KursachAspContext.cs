using Microsoft.EntityFrameworkCore;

namespace YakovleKursovayaASP.Models
{
    public class KursachAspContext : DbContext
    {
        public KursachAspContext(DbContextOptions<KursachAspContext> options)
           : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductType> ProductTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("DataSource=D:\\ASP.NET\\YakovleKursovayaASP\\kursach.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}

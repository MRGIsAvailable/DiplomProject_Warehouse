using Microsoft.EntityFrameworkCore;
using Warehouse_ConstructionWarehouseAPI.Models;

namespace Warehouse_ConstructionWarehouseAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 1,
                    ProductName = "Гвозди x100",
                    Details = "",
                    CategoryID = 1,
                    ImageUrl = ""
                },
                new Product()
                {
                    Id = 2,
                    ProductName = "Болты x100",
                    Details = "",
                    CategoryID = 1,
                    ImageUrl = ""

                }
                );
        }
    }
}

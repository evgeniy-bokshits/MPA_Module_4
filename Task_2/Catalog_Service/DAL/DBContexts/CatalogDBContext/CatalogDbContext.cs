using Core.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DAL.DBContexts.CatalogDBContext;

public class CatalogDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    public DbSet<Category> Categories { get; set; }

    public DbSet<Product> Products { get; set; }

    public CatalogDbContext(DbContextOptions<CatalogDbContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
}

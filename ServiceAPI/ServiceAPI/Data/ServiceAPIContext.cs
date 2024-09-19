using Microsoft.EntityFrameworkCore;
using ServiceAPI.Models.DAO;

namespace ServiceAPI.Data;

public class ServiceAPIContext: DbContext
{
    public ServiceAPIContext(DbContextOptions<ServiceAPIContext> options) : base(options)
    {
        
    }
    
    public DbSet<Client> Clients { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>().HasAlternateKey(o => o.Code);
        
        modelBuilder.Entity<Client>().HasAlternateKey(o => o.Code);
    }

}
using Microsoft.EntityFrameworkCore;
using PUMP.helpers;
using PUMP.models;

namespace PUMP.data.SQLServer;

public class InitDb : DbContext
{
    
    public virtual DbSet<Users> Users { get; set; }
    public virtual DbSet<Accesses> Accesses { get; set; }
    
    public virtual DbSet<Category> Category { get; set; }
    
    public virtual DbSet<DetailMemberships> DetailMemberships { get; set; }
    public virtual DbSet<Employees> Employees { get; set; }
    
    public virtual DbSet<Members> Members { get; set; }
    
    public virtual DbSet<Memberships> Memberships { get; set; }
    
    public virtual DbSet<ProductsPayments> ProductsPayments { get; set; }
    
    public virtual DbSet<Products> Products { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(Settings.ConnectionString,
                builder => { builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null); });
        }
    }
}
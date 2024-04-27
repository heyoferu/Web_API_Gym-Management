using Microsoft.EntityFrameworkCore;
using PUMP.helpers;
using PUMP.models;

namespace PUMP.data.SQLServer;

public class InitDb : DbContext
{
    public virtual DbSet<Employees> Employees { get; set; }
    
    public virtual DbSet<Members> Members { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(Settings.ConnectionString,
                builder => { builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null); });
        }
    }
}
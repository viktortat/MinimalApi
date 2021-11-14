using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

public class OrdersContext : DbContext
{
    private readonly bool _log;

    public OrdersContext()
    {
    }

    public OrdersContext(bool log)
    {
        _log = log;
    }
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Order> Orders => Set<Order>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
               //.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Orders");
               .UseSqlServer(@"Data Source=localhost,1435;Database=Orders;User ID=sa;Password=Aa!123456");

        if (_log)
        {
            optionsBuilder
                .EnableSensitiveDataLogging()
                .LogTo(Console.WriteLine, new[] { RelationalEventId.CommandExecuted });
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().ToTable(t => t.IsTemporal());
        modelBuilder.Entity<Product>().ToTable(t => t.IsTemporal());
        modelBuilder.Entity<Order>().ToTable(t => t.IsTemporal());
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<string>().HaveMaxLength(200);
    }
}
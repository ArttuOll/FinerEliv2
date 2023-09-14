using Microsoft.EntityFrameworkCore;

namespace FinerEli.Models;

public class FoodsContext : DbContext
{
    public FoodsContext(DbContextOptions<FoodsContext> options)
        : base(options)
    {
    }

    public string DbPath { get; }

    public DbSet<Food> Foods { get; set; }
    public DbSet<ComponentValue> ComponentValues { get; set; }
    public DbSet<EufdName> EufdNames { get; set; }
    public DbSet<ComponentUnit> ComponentUnits { get; set; }
    public DbSet<ComponentClass> ComponentClasses { get; set; }
    public DbSet<Component> Components { get; set; }
}
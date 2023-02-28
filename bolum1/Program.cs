using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace bolum1;

public class ShopContext : DbContext {
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("server=localhost;database=shoppp;user=root;password=mysql123;", new MySqlServerVersion(new Version(8,0,22)));
    }
}

public class Product{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
    public double Price { get; set; }
}

public class Category{
    public int Id { get; set; }
    public string Name { get; set; }
}
class Program
{
    static void Main(string[] args)
    {
    }
}

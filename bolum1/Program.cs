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
        using(var db = new ShopContext()){
            var p = new Product(){Name = "Samsung S5", Price = 3000};

            db.Products.Add(p);

            db.SaveChanges();
        }

        using(var db = new ShopContext()){
            var products = new List<Product>(){
                new Product {Name = "Samsung S6", Price = 4000},
                new Product {Name = "Samsung S7", Price = 5000},
                new Product {Name = "Samsung S8", Price = 6000},
                new Product {Name = "Samsung S9", Price = 7000}
            };

            db.AddRange(products);

            db.SaveChanges();
        }

        AddProduct();

        AddProducts();
    }

    static void AddProduct(){
        using(var db = new ShopContext()){
            var p = new Product(){
                Name = "Samsung S10",
                Price = 8000
            };

            db.Add(p);
            db.SaveChanges();
            
            Console.WriteLine("Bir ürün eklendi.");
        }
    }

    static void AddProducts(){
        using(var db = new ShopContext()){
            var p = new List<Product>{
                new Product{Name = "Iphone 2", Price = 3000},
                new Product{Name = "Iphone 3", Price = 4000},
                new Product{Name = "Iphone 4", Price = 5000},
                new Product{Name = "Iphone X", Price = 6000}
            };

            db.AddRange(p);
            db.SaveChanges();

            Console.WriteLine("Ürünler Eklendi.");
        }
    }
}

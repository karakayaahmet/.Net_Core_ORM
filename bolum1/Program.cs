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
        // using(var db = new ShopContext()){
        //     var p = new Product(){Name = "Samsung S5", Price = 3000};

        //     db.Products.Add(p);

        //     db.SaveChanges();
        // }

        // using(var db = new ShopContext()){
        //     var products = new List<Product>(){
        //         new Product {Name = "Samsung S6", Price = 4000},
        //         new Product {Name = "Samsung S7", Price = 5000},
        //         new Product {Name = "Samsung S8", Price = 6000},
        //         new Product {Name = "Samsung S9", Price = 7000}
        //     };

        //     db.AddRange(products);

        //     db.SaveChanges();
        // }

        // AddProduct();

        // AddProducts();

        // GetAllProducts();

        // GetAllProducts2();

        //GetProductById(3);

        // GetProductByName("Iphone");

        Update(3);
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

    static void GetAllProducts(){
        using(var db = new ShopContext()){
            var products = db.Products.ToList();

            foreach (var p in products)
            {
                Console.WriteLine($"İsim : {p.Name}, Fiyat : {p.Price}");
            }
        }
    }

    static void GetAllProducts2(){
        using(var db = new ShopContext()){
            var products = db.Products.Select(p => new {p.Name, p.Price}).ToList();

            foreach (var p in products)
            {
                Console.WriteLine($"Ürün İsim : {p.Name}, Ürün Fiyat : {p.Price}");
            }
        }
    }

    static void GetProductById(int id){
        using(var db = new ShopContext()){
            var result = db.Products.Where(p => p.Id == id).FirstOrDefault();

            if (result != null){
                Console.WriteLine($"Ürün İsim : {result.Name}, Ürün Fiyat : {result.Price}");
            }
        }
    }

    static void GetProductByName(string name){
        using(var db = new ShopContext()){
            var result = db.Products.Where(p => p.Name.ToLower().Contains(name)).ToList();

            foreach (var p in result)
            {
                Console.WriteLine($"Ürün İsim : {p.Name}, Ürün Fiyat : {p.Price}");
            }
        }
    }

    static void Update(int id){
        using(var db = new ShopContext()){
            var result = db.Products.Where(p => p.Id == id).FirstOrDefault();

            if (result != null){
                result.Price *= 1.2;
                db.SaveChanges();

                Console.WriteLine("Güncelleme işlemi başarıyla gerçekleşti.");
            }
        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace bolum1;

public class Product{

    public int Id { get; set; }

    [MaxLength(100)]
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

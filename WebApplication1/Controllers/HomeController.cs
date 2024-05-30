using Microsoft.AspNetCore.Mvc;

using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private static List<Product> products = new()
        {
            new()
            {
                Id = 1,
                Name = "Samsung",
                Description="This is a phone",
                Price= 500
            },
             new()
            {
                 Id = 2,
                Name = "IPhone",
                Description="This is also a phone",
                Price= 5200
            },
            new()
            {
                Id = 3,
                Name = "Xiaomi",
                Description="This is barely a phone",
                Price= 14
            },
        };
        public IActionResult Index()
        {
            return Json(GetAllProducts());
        }
        private List<Product> GetAllProducts()
        {
            return products;
        }
        private Product GetProductById(int id)
        {
            return products.FirstOrDefault(m => m.Id == id);
        }
        public IActionResult Detail(int id)
        {
            return Json(GetProductById(id));
        }
        private List<Product> AddProduct(Product product)
        {
            products.Add(product);
            return products;
        }
        public IActionResult Add (int id, string name, string description, int price) 
        {
        Product existProduct = products.FirstOrDefault(p=>p.Id == id);
            if (existProduct == null)
            {
                Product newProduct = new()
                {
                    Id = id,
                    Name = name,
                    Description = description,
                    Price = price
                };
                return Json(AddProduct(newProduct));
            }
            else
            {
                return Json("Product already exists");   
            }
        }
    }
}

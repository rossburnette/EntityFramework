using Newtonsoft.Json;
using ProductsShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ProductsShop
{
    class Program
    {
        static void Main(string[] args)
        {
            SeedData();
            //ProductsInRange();
            //UsersWithBuyer();
            //CategoriesByProductsCount();
            //UsersEnProducts();

        }

        private static void UsersEnProducts()
        {
            ProductShopContext context = new ProductShopContext();
            var usersSolds = context.Users.Where(user => user.ProductsSold.Count != 0)
                .OrderByDescending(user => user.ProductsSold.Count).ThenBy(user => user.LastName)
                .GroupBy(user => user)
                .Select(grouping => new
                {
                    usersCount = grouping.Count(),
                    users = grouping.Select(user => new
                    {
                        firstName = user.FirstName,
                        lastName = user.LastName,
                        age = user.Age,
                        soldProducts = user.ProductsSold.GroupBy(product => product).Select(group => new
                        {
                            count = group.Count(),
                            products = group.Select(product => new
                            {
                                name = product.Name,
                                price = product.Price
                            })
                        })
                    })
                });
            SerializeObject(usersSolds, @"D:\SoftUni\Databases Advanced - Entity Framework\JSON Processing\Result\usersSolds.json");
        }

        private static void CategoriesByProductsCount()
        {
            ProductShopContext context = new ProductShopContext();
            var allCategories = context.Categories.GroupBy(categorie => categorie)
                .OrderBy(category => category.Key.Products.Count)
                .Select(categoy => new
                {
                    category = categoy.Key.Name,
                    productsCount = categoy.Key.Products.Count,
                    averagePrice = categoy.Key.Products.Average(product => product.Price),
                    totalRevenue = categoy.Key.Products.Sum(product => product.Price)
                });
            SerializeObject(allCategories, @"D:\SoftUni\Databases Advanced - Entity Framework\JSON Processing\Result\cat_prod.json");
        }

        private static void UsersWithBuyer()
        {
            ProductShopContext context = new ProductShopContext();
           var usersWanted = context.Users.Where(user => user.ProductsSold.Count(product => product.Buyer != null) != 0)
                .OrderBy(user => user.LastName)
                .ThenBy(user => user.FirstName)
                .Select(user => new
                {
                    user.FirstName,
                    user.LastName,
                    soldProducts = user.ProductsSold.Select(product => new
                    {
                        product.Name,
                        product.Price,
                        buyerFirstName = product.Buyer.FirstName,
                        buyerLastName = product.Buyer.LastName
                    })
                });
            SerializeObject(usersWanted, @"D:\SoftUni\Databases Advanced - Entity Framework\JSON Processing\Result\users.json");



        }

        private static void ProductsInRange()
        {
            ProductShopContext context = new ProductShopContext();
            var products = context.Products.Where(product => product.Price > 500 && product.Price < 1000 && product.Buyer == null)
                .OrderBy(product => product.Price)
                .Select(product => new
                {
                    name = product.Name,
                    price = product.Price,
                    seller = (product.Seller.FirstName + " " + product.Seller.LastName).Trim()
                });
            SerializeObject(products, @"D:\SoftUni\Databases Advanced - Entity Framework\JSON Processing\Result\products.json");

            XElement root = new XElement("products");
            foreach (var product in products)
            {
                XElement productElement = new XElement("product");
                productElement.SetAttributeValue(nameof(product.name), product.name);
                productElement.SetAttributeValue(nameof(product.price), product.price);
                productElement.SetAttributeValue(nameof(product.seller), product.seller);

                root.Add(productElement);
            }

           // string json = JsonConvert.SerializeObject(products);
           // XmlDocument doc = JsonConvert.DeserializeXmlNode(json);
            root.Save(@"D:\SoftUni\Databases Advanced - Entity Framework\JSON Processing\Result\products.xml");
        }

        private static void SerializeObject<T>(T entity, string path)
        {
            string json = JsonConvert.SerializeObject(entity, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(path, json);
        }

        private static void SeedData()
        {
            SeedUsers();
           // SeedProducts();
           // SeedCategories();
        }

        private static void SeedCategories()
        {
            ProductShopContext context = new ProductShopContext();
            string jsonCategories = File.ReadAllText(@"D:\SoftUni\Databases Advanced - Entity Framework\JSON Processing\Exercises\categories.json");
            IEnumerable<Category> categories = JsonConvert.DeserializeObject<IEnumerable<Category>>(jsonCategories);
            var products = context.Products.ToList();
            Random rnd = new Random();
            foreach (var category in categories)
            {
                for (int i = 0; i < products.Count/4; i++)
                {
                    category.Products.Add(products[rnd.Next(1, products.Count)]);
                }
            }
            context.Categories.AddRange(categories);
            context.SaveChanges();
        }

        private static void SeedProducts()
        {
            ProductShopContext context = new ProductShopContext();
            string jsonProducts = File.ReadAllText(@"D:\SoftUni\Databases Advanced - Entity Framework\JSON Processing\Exercises\products.json");
            IEnumerable<Product> products = JsonConvert.DeserializeObject<IEnumerable<Product>>(jsonProducts);
            Random rnd = new Random();
            int usersCount = context.Users.Count();

            foreach (var product in products)
            {
                product.SelledId = rnd.Next(1, usersCount + 1);
                double hasBuyerFactor = rnd.NextDouble();
                if(hasBuyerFactor <= 0.7)
                {
                    product.BuyerId = rnd.Next(1, usersCount + 1);
                }

            }

            context.Products.AddRange(products);
            context.SaveChanges();

        }

        private static void SeedUsers()
        {
            ProductShopContext context = new ProductShopContext();
            string jsonUsers = File.ReadAllText(@"D:\SoftUni\Databases Advanced - Entity Framework\JSON Processing\Exercises\users.json");
            IEnumerable<User> importedUsers = JsonConvert.DeserializeObject<IEnumerable<User>>(jsonUsers);
            context.Users.AddRange(importedUsers);
            context.SaveChanges();

        }
    }
}

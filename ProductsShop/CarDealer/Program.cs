using CarDealer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new CarDealerContext();
            //SeedData();
            //OrderedCustomers(context);
            //ToyotaCars();
            //LocalSuppliers();
            //CarsAndParts();
            CustomerCars();
            //SalesAndDiscount();
        }

        private static void SalesAndDiscount()
        {
            using(var context = new CarDealerContext())
            {
                var salesDiscount = context.Sales.Select(s => new
                {
                    car = new { s.Car.Make, s.Car.Model, s.Car.TravelledDistance },
                    customerName = s.Customer.Name,
                    s.Discount,
                    price = s.Car.Parts.Sum(p => p.Price),
                    //priceWithDiscount = (s.Car.Parts.Sum(p => p.Price)) - (s.Car.Parts.Sum(p => p.Price) * s.Discount)
                });
                string json = JsonConvert.SerializeObject(salesDiscount, Formatting.Indented);
                File.WriteAllText(@"D:\SoftUni\Databases Advanced - Entity Framework\JSON Processing\Result\alabala.json", json);
            }
        }

        private static void CustomerCars()
        {
            var context = new CarDealerContext();
            var customers = context.Customers.Where(customer => customer.Sales.Any())
                .Select(c => new
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count,
                    spentMoney = c.Sales.Sum(s => s.Car.Parts.Sum(p => p.Price))
                }).OrderByDescending(c => c.spentMoney).ThenByDescending(c => c.boughtCars);
            Console.WriteLine(JsonConvert.SerializeObject(customers,Formatting.Indented));
            string json = JsonConvert.SerializeObject(customers, Formatting.Indented);
            File.WriteAllText(@"D:\SoftUni\Databases Advanced - Entity Framework\JSON Processing\Result\alabala.json", json);
        }

        private static void CarsAndParts()
        {
            var context = new CarDealerContext();
            var cars = context.Cars.Select(c => new
            {
                car = new
                {
                    c.Make,
                    c.Model,
                    c.TravelledDistance,
                    price = c.Parts.Sum(p => p.Price)
                },
                parts = c.Parts.Select(part => new
                {
                    part.Name,
                    part.Price
                })
            });

            Console.WriteLine(JsonConvert.SerializeObject(cars, Formatting.Indented));
        }

        private static void LocalSuppliers()
        {
            var context = new CarDealerContext();
            var suppliers = context.Suppliers.Where(supplier => supplier.IsImporter == false).Select(supplier => new
            {
                Id = supplier.Id,
                Name = supplier.Name,
                partsCount = supplier.Parts.Count
            });
            Console.WriteLine(JsonConvert.SerializeObject(suppliers, Formatting.Indented));
        }

        private static void ToyotaCars()
        {
            var context = new CarDealerContext();
            var toyotaCars = context.Cars.Where(car => car.Make == "Toyota")
                .OrderBy(car => car.Model).ThenByDescending(car => car.TravelledDistance);
            Console.WriteLine(JsonConvert.SerializeObject(toyotaCars, Formatting.Indented));
        }

        private static void OrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers.OrderBy(customer => customer.BirthDate).ThenByDescending(customer => customer.IsYoungDriver);
            Console.WriteLine(JsonConvert.SerializeObject(customers, Formatting.Indented));
            
        }

        private static void SeedData()
        {
            //SeedSuppliers();
            //SeedParts();
            //SeedCars();
            // SeedCustomers();
            SeedSales();
        }

        private static void SeedSales()
        {
            double[] discounts = new double[] { 0, 0.05, 0.10, 0.20, 0.30, 0.40, 0.50 };
            using(var context = new CarDealerContext())
            {
                Random rnd = new Random();
                var cars = context.Cars.ToList();
                var customers = context.Customers.ToList();
                for (int i = 0; i < 50; i++)
                {
                    var car = cars[rnd.Next(cars.Count)];
                    var customer = customers[rnd.Next(customers.Count)];
                    var discount = discounts[rnd.Next(discounts.Length)];
                    if (customer.IsYoungDriver)
                    {
                        discount += 0.5;
                    }

                    Sale sale = new Sale()
                    {
                        Car = car,
                        Customer = customer,
                        Discount = discount
                    };

                    context.Sales.Add(sale);
                }

                context.SaveChanges();
            }
        }

        private static void SeedCustomers()
        {
            var customers = ParseJsonCollection<Customer>(@"D:\SoftUni\Databases Advanced - Entity Framework\JSON Processing\Exercises\customers.json");
            using(var context = new CarDealerContext())
            {
                context.Customers.AddRange(customers);
                context.SaveChanges();
            }
        }

        private static void SeedCars()
        {
            var cars = ParseJsonCollection<Car>(@"D:\SoftUni\Databases Advanced - Entity Framework\JSON Processing\Exercises\cars.json");
            using(var context = new CarDealerContext())
            {
                Random rnd = new Random();
                var parts = context.Parts.ToList();
                foreach (var car in cars)
                {
                    int randomPartsCount = rnd.Next(10, 21);
                    for (int i = 0; i < randomPartsCount; i++)
                    {
                        car.Parts.Add(parts[rnd.Next(randomPartsCount)]);
                    }

                    context.Cars.Add(car);
                }

                context.SaveChanges();
            }
        }

        private static void SeedParts()
        {
            var parts = ParseJsonCollection<Part>(@"D:\SoftUni\Databases Advanced - Entity Framework\JSON Processing\Exercises\parts.json");
            using(var context = new CarDealerContext())
            {
                Random rnd = new Random();
                var suppliers = context.Suppliers.ToList();
                foreach (var part in parts)
                {
                    part.Supplier = suppliers[rnd.Next(suppliers.Count)];
                    context.Parts.Add(part);
                }
                context.Parts.AddRange(parts);
                context.SaveChanges();
            }
        }

        private static void SeedSuppliers()
        {
            var suppliers = ParseJsonCollection<Supplier>(@"D:\SoftUni\Databases Advanced - Entity Framework\JSON Processing\Exercises\suppliers.json");

            using(var context = new CarDealerContext())
            {
                context.Suppliers.AddRange(suppliers);
                context.SaveChanges();
            }
        }

        static IEnumerable<T> ParseJsonCollection<T>(string path)
        {
            string json = File.ReadAllText(path);
            var collection = JsonConvert.DeserializeObject<IEnumerable<T>>(json);
            return collection;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace InventoryManagementSystem
{
    internal class Inventory
    {
        public List<Product> Products { get; set; } = new List<Product>();

        private const string FilePath = "data.json";

        public void Load()
        {
            if (File.Exists(FilePath))
            {
                string json = File.ReadAllText(FilePath);
                var products = JsonSerializer.Deserialize<List<Product>>(json);

                if (products != null)
                {
                    Products = products;
                }
                else
                {
                    Products = new List<Product>();
                    // Skapa en tom JSON-fil
                    json = JsonSerializer.Serialize(Products, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(FilePath, json);
                }
            }

        }

        public void Save()
        {
            File.WriteAllText(FilePath, JsonSerializer.Serialize(Products));
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }
        public bool FindProductById(int id, out Product product)
        {
            product = Products.FirstOrDefault(p => p.Id == id);
            return product != null;
        }
        public void DeleteProduct(int id)
        {
            Products.RemoveAll(p => p.Id == id);
        }
        public void UpdateProduct(int id, string name, int quantity, decimal price)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                product.Name = name;
                product.Quantity = quantity;
                product.Price = price;
            }
        }




        public void ViewProducts()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("ID".PadRight(15) + "Name".PadRight(15) + "Quantity".PadRight(15) + "Price".PadRight(15));
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.Black;
            foreach (var p in Products) p.DisplayProductInfo();
        }

        public void GenerateReport()
        {
            decimal totalValue = Products.Sum(p => p.Price * p.Quantity);
            Console.WriteLine($"Total Inventory Value: {totalValue:C}");
            Console.WriteLine($"Number of Products: {Products.Count}");
        }

    }
}

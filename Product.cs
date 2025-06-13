using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem
{
    internal class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public void DisplayProductInfo()
        {
            Console.WriteLine(Id.ToString().PadRight(15) + Name.ToString().PadRight(15) + Quantity.ToString().PadRight(15) + Price.ToString("C").PadRight(15));
        }
    }
}

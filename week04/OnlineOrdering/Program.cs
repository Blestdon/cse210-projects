using System;

namespace OnlineOrderingProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            // USA customer and address
            Address addr1 = new Address("123 Main St", "New York", "NY", "USA");
            Customer cust1 = new Customer("John Doe", addr1);

            // Nigerian customer and address
            Address addr2 = new Address("12 Unity Road", "Owerri", "Imo", "Nigeria");
            Customer cust2 = new Customer("Chinwe Okafor", addr2);

            // Products for USA customer
            Product prod1 = new Product("Laptop", "LP1001", 999.99, 1);
            Product prod2 = new Product("Wireless Mouse", "MS2002", 25.50, 2);

            Order order1 = new Order(cust1);
            order1.AddProduct(prod1);
            order1.AddProduct(prod2);

            // Products for Nigerian customer
            Product prod3 = new Product("Generator", "GN3001", 450.00, 1);
            Product prod4 = new Product("Voltage Stabilizer", "VS4002", 120.00, 1);
            Product prod5 = new Product("Solar Lantern", "SL5003", 75.00, 2);

            Order order2 = new Order(cust2);
            order2.AddProduct(prod3);
            order2.AddProduct(prod4);
            order2.AddProduct(prod5);

            // Display order 1 details (USA)
            Console.WriteLine(order1.GetPackingLabel());
            Console.WriteLine(order1.GetShippingLabel());
            Console.WriteLine($"Total Price: ${order1.CalculateTotalPrice():0.00}");
            Console.WriteLine(new string('-', 40));

            // Display order 2 details (Nigeria)
            Console.WriteLine(order2.GetPackingLabel());
            Console.WriteLine(order2.GetShippingLabel());
            Console.WriteLine($"Total Price: ${order2.CalculateTotalPrice():0.00}");
        }
    }
}

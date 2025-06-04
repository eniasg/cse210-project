using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Create addresses
        Address usaAddress = new Address("123 Main St", "New York", "NY", "USA");
        Address zimbabweAddress = new Address("812 Tingini St", "Old Mabvuku", "Harare", "Zimbabwe");
        
        // Create customers
        Customer customer1 = new Customer("John Smith", usaAddress);
        Customer customer2 = new Customer("Enias Gramu", zimbabweAddress);
        
        // Create products
        Product laptop = new Product("Laptop", "P100", 899.99m, 1);
        Product mouse = new Product("Wireless Mouse", "P101", 24.99m, 2);
        Product keyboard = new Product("Mechanical Keyboard", "P102", 89.99m, 1);
        Product headphones = new Product("Noise-Cancelling Headphones", "P103", 199.99m, 1);
        
        // Create orders
        Order order1 = new Order(customer1);
        order1.AddProduct(laptop);
        order1.AddProduct(mouse);
        
        Order order2 = new Order(customer2);
        order2.AddProduct(keyboard);
        order2.AddProduct(headphones);
        order2.AddProduct(mouse);
        
        // Display order information
        DisplayOrder(order1);
        DisplayOrder(order2);
    }
    
    static void DisplayOrder(Order order)
    {
        Console.WriteLine("PACKING LABEL:");
        Console.WriteLine(order.GetPackingLabel());
        
        Console.WriteLine("\nSHIPPING LABEL:");
        Console.WriteLine(order.GetShippingLabel());
        
        Console.WriteLine($"\nTOTAL PRICE: ${order.CalculateTotalCost():0.00}");
        Console.WriteLine("\n=================================\n");
    }
}
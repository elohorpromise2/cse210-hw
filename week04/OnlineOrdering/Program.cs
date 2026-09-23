using System;

class Program
{
    static void Main(string[] args)
    {
        // Order 1 - USA Customer
        Address address1 = new Address("123 Main St", "Rexburg", "ID", "USA");
        Customer customer1 = new Customer("Promise Elohor", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "LPT-101", 999.99, 1));
        order1.AddProduct(new Product("Mouse", "MSE-202", 25.50, 2));
        order1.AddProduct(new Product("Keyboard", "KBD-303", 45.00, 1));

        // Order 2 - International Customer
        Address address2 = new Address("45 Allen Avenue", "Lagos", "Lagos", "Nigeria");
        Customer customer2 = new Customer("John Okafor", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Monitor", "MON-404", 199.99, 1));
        order2.AddProduct(new Product("USB Cable", "USB-505", 9.99, 3));

        // Display Order 1
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.CalculateTotalCost():0.00}\n");
        Console.WriteLine("-----------------------------------\n");

        // Display Order 2
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.CalculateTotalCost():0.00}\n");
    }
}
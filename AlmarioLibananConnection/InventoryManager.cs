// InventoryManager class
using System.Collections.Generic;
using System.IO;
using System;

class InventoryManager
{
    private List<Product> inventory;

    public InventoryManager()
    {
        inventory = LoadInventory();
    }

    private List<Product> LoadInventory()
    {
        List<Product> inventory = new List<Product>();

        if (File.Exists("inventory.csv"))
        {
            using (StreamReader reader = new StreamReader("inventory.csv"))
            {
                while (!reader.EndOfStream)
                {
                    string[] line = reader.ReadLine().Split(',');

                    // Check if there are at least four columns in the CSV
                    if (line.Length >= 4)
                    {
                        int id = int.Parse(line[0]);
                        string name = line[1];
                        int quantity = int.Parse(line[2]);
                        decimal price = decimal.Parse(line[3]);

                        // Assume category is not present in the CSV
                        string category = "";

                        // Check if there are five columns (including category)
                        if (line.Length >= 5)
                        {
                            category = line[4];
                        }

                        inventory.Add(new Product(id, name, quantity, price, category));
                    }
                }
            }
        }

        return inventory;
    }



    public void SaveInventory()
    {
        using (StreamWriter writer = new StreamWriter("inventory.csv"))
        {
            foreach (Product product in inventory)
            {
                // Assuming Category is the fifth column
                writer.WriteLine($"{product.Id},{product.Name},{product.Quantity},{product.Price},{product.Category}");
            }
        }
    }



    public void SellProduct()
    {
        Console.Write("Enter product ID: ");
        int productId = int.Parse(Console.ReadLine());

        Product product = inventory.Find(p => p.Id == productId);

        if (product != null)
        {
            Console.Write("Enter quantity to sell: ");
            int quantityToSell = int.Parse(Console.ReadLine());

            if (quantityToSell <= product.Quantity)
            {
                product.Quantity -= quantityToSell;
                Console.WriteLine($"Sold {quantityToSell} {product.Name}(s). Total Cost: {product.Price * quantityToSell:C}");

                if (product.Quantity < 10)
                {
                    Console.WriteLine($"Warning: {product.Name} quantity is below the threshold.");
                }
            }
            else
            {
                Console.WriteLine("Insufficient stock to fulfill the order.");
            }
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }





    public void SearchProduct()
    {
        Console.WriteLine("Choose search criteria:");
        Console.WriteLine("1. Search by ID");
        Console.WriteLine("2. Search by Name");
        Console.WriteLine("3. Search by Category");
        Console.Write("Enter your choice: ");
        int searchChoice = int.Parse(Console.ReadLine());

        Console.Write("Enter search term: ");
        string searchTerm = Console.ReadLine().ToLower();

        List<Product> results = new List<Product>();

        switch (searchChoice)
        {
            case 1:
                foreach (Product product in inventory)
                {
                    if (product.Id.ToString().Contains(searchTerm))
                    {
                        results.Add(product);
                    }
                }
                break;
            case 2:
                foreach (Product product in inventory)
                {
                    if (product.Name.ToLower().Contains(searchTerm))
                    {
                        results.Add(product);
                    }
                }
                break;
            case 3:
                foreach (Product product in inventory)
                {
                    if (product.Category.ToLower().Contains(searchTerm))
                    {
                        results.Add(product);
                    }
                }
                break;
            default:
                Console.WriteLine("Invalid choice. No matching products found.");
                return;
        }

        if (results.Count > 0)
        {
            foreach (Product product in results)
            {
                Console.WriteLine($"{product.Id} - {product.Name} ({product.Quantity} in stock) - Price: {product.Price:C} - Category: {product.Category}");
            }
        }
        else
        {
            Console.WriteLine("No matching products found.");
        }
    }






    public void CheckInventory()
    {
        foreach (Product product in inventory)
        {
            Console.WriteLine($"{product.Id} - {product.Name} ({product.Quantity} in stock) - Price: {product.Price:C}");
        }
    }
}

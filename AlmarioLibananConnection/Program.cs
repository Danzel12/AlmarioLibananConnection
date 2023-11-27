using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmarioLibananConnection
{
    class Program
    {
        static void Main()
        {
            InventoryManager inventoryManager = new InventoryManager();

            while (true)
            {
                Console.WriteLine("WELCOME TO HONGHANG DRUGSTORE WHERE EVERYTHING IS LEGAL\n");
                Console.WriteLine("1. Buy Drugs");
                Console.WriteLine("2. Search Product");
                Console.WriteLine("3. Check Inventory");
                Console.WriteLine("4. Exit\n");

                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        inventoryManager.SellProduct();
                        break;
                    case 2:
                        inventoryManager.SearchProduct();
                        break;
                    case 3:
                        inventoryManager.CheckInventory();
                        break;
                    case 4:
                        inventoryManager.SaveInventory();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}

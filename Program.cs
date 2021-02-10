using Baby_Spice_ConsoleProject.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Baby_Spice_ConsoleProject
{
    class Program
    {
        static void Main(string[] args)
        {
            bool showMenu = true;
            while (showMenu)
            {
                MainMenu();
            }

            bool MainMenu()
            {
                Console.Clear();
                Console.WriteLine("Welcome to Dufflin/Munder Cardboard Co. ");
                Console.WriteLine("Sales Portal!\n");
                Console.WriteLine("1. Enter Sales");
                Console.WriteLine("2. Generate Report For Accountant");
                Console.WriteLine("3. Add New Sales Employee");
                Console.WriteLine("4. Find A Sale");
                Console.WriteLine("5. Exit");

                switch (Console.ReadLine())
                {
                    case "1":
                        showMenu = false;
                        Console.Clear();
                        EnterSales();
                        return true;
                    case "2":
                        Console.WriteLine("Generate A Report");
                        return true; ;
                    case "3":
                        Console.WriteLine("Update me");
                        return true;
                    case "4":
                        Console.WriteLine("Enter Sale Info");
                        return true;
                    case "5":
                        return false;
                    default:
                        return true;
                }
            }
            void EnterSales()
            {
                Console.WriteLine("Which Sales Employee Are You?");
                var closers = new List<SalesEmployee>
                {
                    new SalesEmployee( "Dwight", "Hale", 1),
                    new SalesEmployee( "Tim", "Halbert", 2),
                    new SalesEmployee( "Phyllis", "Leaf", 3),
                };

                foreach (var closer in closers)
                {
                    Console.WriteLine($"{closer.IdNumber}. {closer.FirstName} {closer.LastName}");
                }
                
                var selection = Console.ReadLine();
                var selectedSeller = closers.Find(closer => closer.IdNumber == int.Parse(selection));
                Console.Clear();
                Console.WriteLine($"Hi, {selectedSeller.FirstName}!");
                Thread.Sleep(2000);
                Console.Clear();
                Console.WriteLine("Please Enter The Client's Name:");
                var clientName = Console.ReadLine();
                Console.WriteLine("Please Enter the Client ID");

            }
        }
    }
}

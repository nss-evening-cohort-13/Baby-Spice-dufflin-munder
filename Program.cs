using System;
using System.Collections.Generic;
using System.Linq;
using Baby_Spice_ConsoleProject.Employees;

namespace Baby_Spice_ConsoleProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var salesPeople = new List<SalesEmployee>
            {
                  new SalesEmployee("Dwight", "Hyte", 1),
                  new SalesEmployee("Tim", "Halbert", 2),
                  new SalesEmployee("Phyllis", "Leaf", 3)
            };
                                
           
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
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
                        EnterSales();
                        return true;
                    case "2":
                        Console.WriteLine("Generate A Report");
                        return true; ;
                    case "3":
                        CreateNewSalesperson();                          
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
                var x = Console.ReadLine();
                Console.WriteLine($"{x}");
                showMenu = true;
            }

           void CreateNewSalesperson()
            {
                Console.WriteLine("Enter new salesperson's first name:");
                string salesFirstName;
                salesFirstName = Console.ReadLine();

                Console.WriteLine("Enter new salesperson's last name:");
                string salesLastName;
                salesLastName = Console.ReadLine();

                var newSalesEmployee = (salesFirstName + salesLastName);

                Console.WriteLine($"Hi, {salesFirstName}");

            }

         }
    }
}

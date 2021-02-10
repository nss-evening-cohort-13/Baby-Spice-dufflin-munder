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
            var salesPeople = new List<SalesEmployee>
            {
                  new SalesEmployee("Dwight", "Hyte", 1),
                  new SalesEmployee("Tim", "Halbert", 2),
                  new SalesEmployee("Phyllis", "Leaf", 3)
            };
                                
           
            bool showMenu = true;

            var accountants = new List<AccountantEmployee>
            {
                new AccountantEmployee("Oscar", "Martinez", 1),
                new AccountantEmployee("Angela", "Martin", 2),
                new AccountantEmployee("Kevin", "Malone", 3)
            };

            
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
                        Console.Clear();
                        EnterSales();
                        return true;
                    case "2":
                        showMenu = false;
                        GenerateReport();
                        return true;
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
                foreach (var closer in salesPeople)
                {
                    Console.WriteLine($"{closer.IdNumber}. {closer.FirstName} {closer.LastName}");
                }
                
                var selection = Console.ReadLine();
                var selectedSeller = salesPeople.Find(closer => closer.IdNumber == int.Parse(selection));
                Console.Clear();
                Console.WriteLine($"Hi, {selectedSeller.FirstName}!");
                Thread.Sleep(2000);
                Console.Clear();
                Console.WriteLine("Please Enter The Client's Name:");
                var clientName = Console.ReadLine();

                //TODO: make a random client ID with no repeats 
                Console.WriteLine("Enter A Client ID");
                var randomCliId = int.Parse(Console.ReadLine());

                //moving on
                Console.WriteLine("Enter The Dollar Amount For The Sale:");
                var saleAmount = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter The Frequency Of Payment (I.E. Weekly, Monthly, etc."); //CAPSLOCK
                var payDay = Console.ReadLine();

                Console.WriteLine("Enter Contract Term Length: ");
                var term = Console.ReadLine();

                var sale = new Sale(selectedSeller, clientName, randomCliId, saleAmount, payDay, term);
                selectedSeller.Sales.Add(sale);
                Caboose();
                
            }

            void GenerateReport()
            {
                Console.WriteLine("\nGenerate A Report");
                Console.WriteLine("---------------------------");
                Console.WriteLine("Choose Which Accountant To Generate A Report For:");
                foreach (var accountant in accountants)
                {
                    Console.WriteLine($"{accountant.IdNumber}. {accountant.FirstName}");
                }
                var selectionNumber = Console.ReadLine();
                var selectedAccountant = accountants.Find(accountant => accountant.IdNumber == int.Parse(selectionNumber));
                Console.WriteLine("\nMonthly Sales Report");
                Console.WriteLine($"For: {selectedAccountant.FirstName}");
                Console.WriteLine("---------------------------");
                int count = 0;
                foreach(var salesPerson in salesPeople)
                {
                    count++;
                    Console.WriteLine($"\n{count}. {salesPerson.FirstName} {salesPerson.LastName}");
                    Console.WriteLine("Clients:".PadLeft(10));
                    // Add in foreach to print each of salespersons clients
                    Console.WriteLine($"Total:");
                }
                Caboose();
            }

            void Caboose()
            {
                Console.WriteLine("\nPress 1 To Return to Main Menu Or Any Other Key To Exit");
                var command = Console.ReadLine();
                if (command == "1")
                {
                    showMenu = true;
                }
            }

           void CreateNewSalesperson()
            {
                Console.WriteLine("Enter new salesperson's first name:");
                string salesFirstName;
                salesFirstName = Console.ReadLine();

                Console.WriteLine("Enter new salesperson's last name:");
                string salesLastName;
                salesLastName = Console.ReadLine();

                var newSalesEmployee = new SalesEmployee(salesFirstName, salesLastName, salesPeople.Last().IdNumber + 1);
                
                salesPeople.Add(newSalesEmployee);

                Console.WriteLine($"Hi, {salesFirstName}");
                Caboose();

            }

         }
    }
}

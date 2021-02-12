using Baby_Spice_ConsoleProject.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Spectre.Console;

namespace Baby_Spice_ConsoleProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //defining offices and employees
            var offices = new List<Office>
            {
                new Office("Scott's Tots", 1, "Scranton"),
                new Office("Head Branch", 2, "New York City"),
                new Office("Watch A New Show Already", 3, "Nashville")
            };

            offices[0].SalesEmployees = new List<SalesEmployee>
            {
                new SalesEmployee("Dwight", "Hyte", 1),
                new SalesEmployee("Tim", "Halbert", 2),
                new SalesEmployee("Phyllis", "Leaf", 3)
            };

            offices[1].SalesEmployees = new List<SalesEmployee>
            {
                new SalesEmployee("Dingle", "Dangle", 1),
                new SalesEmployee("Hoingy", "Boingy", 2),
                new SalesEmployee("Russell", "Bustle", 3)
            };

            offices[2].SalesEmployees = new List<SalesEmployee>
            {
                new SalesEmployee("Dwight", "Hyte", 1),
                new SalesEmployee("Tim", "Halbert", 2),
                new SalesEmployee("Phyllis", "Leaf", 3)
            };

            var accountants = new List<AccountantEmployee>
            {
                new AccountantEmployee("Oscar", "Martinez", 1),
                new AccountantEmployee("Angela", "Martin", 2),
                new AccountantEmployee("Kevin", "Malone", 3)
            };

            var rule = new Rule("[green]WELCOME TO DUFFLIN MUNDER[/]");
            AnsiConsole.Render(rule);

            // setting global variables
            bool showMenu = true;
            bool showGreetMenu = true;
            var selectedOffice = new Office("default", 0, default);
            var salesPeople = selectedOffice.SalesEmployees;

            // holds a random client id
            List<int> clientGeneratedId = new List<int>();



            // menu logic
            while (showGreetMenu)
            {
                showGreetMenu = greetMenu();
            }

            while (showMenu)
            {
                showMenu = MainMenu();
            }


            // methods
            bool greetMenu()
            {
                Console.WriteLine("Please Select An Option: ");
                Console.WriteLine("1. Select Office.");
                Console.WriteLine("2. Create New Office.");

                switch (Console.ReadLine())
                {
                    case "1":
                        SelectOffice();
                        return false;
                    case "2":
                        CreateOffice();
                        return true;
                    default:
                        return true;
                }
            }

            void SelectOffice()
            {
                foreach (var office in offices)
                {
                    Console.WriteLine($"{office.OfficeId}. {office.Name} - {office.Location}");
                }
                var officeSelection = int.Parse(Console.ReadLine());
                selectedOffice = offices.Find(office => office.OfficeId == officeSelection);
                salesPeople = selectedOffice.SalesEmployees;
            }

            void CreateOffice()
            {
                Console.WriteLine("Create a new office, Provide Name!");
                var name = Console.ReadLine();
                Console.WriteLine("Provide Location");
                var location = Console.ReadLine();

                var newOffice = new Office(name, offices.Last().OfficeId + 1, location);

                offices.Add(newOffice);


            }


            bool MainMenu()
            {
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
                        showMenu = false;
                        GenerateReport();
                        return true;
                    case "3":
                        CreateNewSalesperson();
                        return true;
                    case "4":
                        FindSaleInfo();
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
                if (salesPeople.Capacity > 0)
                {
                    foreach (var closer in salesPeople)
                    {
                        Console.WriteLine($"{closer.IdNumber}. {closer.FirstName} {closer.LastName}");
                    }
                    var selection = Console.ReadLine();
                    var selectedSeller = salesPeople.Find(closer => closer.IdNumber == int.Parse(selection));

                    Console.WriteLine($"Hi, {selectedSeller.FirstName}!");
                    Console.WriteLine("Please Enter The Client's Name:");
                    var clientName = Console.ReadLine();

                    //TODO: make a random client ID with no repeats 
                    int number;
                    var rand = new Random();
                    do
                    {
                        number = rand.Next(1000, 9999);
                    } while (clientGeneratedId.Contains(number));
                    clientGeneratedId.Add(number);

                    int lastId = clientGeneratedId.Last();
                    Console.WriteLine($"Client ID is now {lastId}");


                    Console.WriteLine("Enter The Dollar Amount For The Sale:");
                    var saleAmount = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter The Frequency Of Payment (I.E. Weekly, Monthly, etc."); //CAPSLOCK
                    var payDay = Console.ReadLine();

                    Console.WriteLine("Enter Contract Term Length: ");
                    var term = Console.ReadLine();

                    var sale = new Sale(selectedSeller, clientName, lastId, saleAmount, payDay, term);
                    selectedSeller.Sales.Add(sale);
                    Caboose();
                }
                else
                {
                    Console.WriteLine("No sales employees please return to main menu and create one.");
                    Caboose();
                }



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
                Console.WriteLine("Please select which report you would like to generate: \n1. Office Wide Report\n2. Itemized Salesperson Report ");


                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("\nTotal Office Sales Report");
                        Console.WriteLine($"For: {selectedAccountant.FirstName}");
                        Console.WriteLine("---------------------------");
                        var grandTotal = 0;
                        foreach (var salesPerson in salesPeople)
                        {
                            foreach (var sale in salesPerson.Sales)
                            {
                                Console.WriteLine($"- {sale.Client}: ${sale.Amount}");
                                grandTotal += sale.Amount;
                            }
                        }
                        Console.WriteLine($"Your office total sales are: ${grandTotal}");
                        break;
                    case "2":
                        Console.WriteLine("\nItemized Sales Report");
                        Console.WriteLine($"For: {selectedAccountant.FirstName}");
                        Console.WriteLine("---------------------------");
                        int salesPersonCount = 0;
                        foreach (var salesPerson in salesPeople)
                        {
                            salesPersonCount++;
                            Console.WriteLine($"\n{salesPersonCount}. {salesPerson.FirstName} {salesPerson.LastName}");
                            Console.WriteLine("Clients:".PadLeft(10));
                            int saleCount = 0;
                            int salesTotal = 0;
                            foreach (var sale in salesPerson.Sales)
                            {
                                saleCount++;
                                Console.WriteLine($"\t{saleCount}. {sale.Client}");
                                salesTotal += sale.Amount;
                            }
                            Console.WriteLine($"Total: ${salesTotal}");
                        }
                        break;
                }



                Caboose();
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

            void FindSaleInfo()
            {
                Console.WriteLine("Enter a Client ID to find Report!");
                var searchId = int.Parse(Console.ReadLine());
                foreach (var salesPerson in salesPeople)
                {
                    var foundSale = salesPerson.Sales.Find(sale => sale.ClientId == searchId);
                    if (foundSale != null)
                    {
                        Console.WriteLine($"Sales Agent {salesPerson.FirstName} {salesPerson.LastName}");
                        Console.WriteLine($"ClientID: {foundSale.ClientId}");
                        Console.WriteLine($"Sale: ${foundSale.Amount}");
                        Console.WriteLine($"Recurring: {foundSale.Recurring}");
                        Console.WriteLine($"Time Frame:{foundSale.TimeFrame} ");
                    }


                }
                Caboose();
            }

            void Caboose()
            {
                Console.WriteLine("\nPress Enter To Return To Main Menu");
                var command = Console.ReadLine();
                showMenu = true;
            }

        }
    }
}

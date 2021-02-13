using Baby_Spice_ConsoleProject.Employees;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
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
                new SalesEmployee("Ronald", "McDonald", 1),
                new SalesEmployee("Charlie", "Day", 2),
                new SalesEmployee("Dee", "Reynolds", 3)
            };

            var accountants = new List<AccountantEmployee>
            {
                new AccountantEmployee("Oscar", "Martinez", 1),
                new AccountantEmployee("Angela", "Martin", 2),
                new AccountantEmployee("Kevin", "Malone", 3)
            };

            AnsiConsole.Render(
                new FigletText("DUFFLIN MUNDER SALES CONSOLE")
                    .Centered()
                    .Color(Color.Wheat1));
            Thread.Sleep(3000);
            Console.Clear();
            var rule = new Rule("[green]DUFFLIN MUNDER(tm) all rights reserved 2021.[/]");

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
                AnsiConsole.Markup("[white]Please Select An Option: [/]");
                AnsiConsole.Markup("\n1. [dodgerblue2]Select[/] [wheat1]Office.[/]");
                AnsiConsole.Markup("\n2. [lime]Create[/] [wheat1]New Office.[/]\n");

                switch (Console.ReadLine())
                {
                    case "1":
                        SelectOffice();
                        return false;
                    case "2":
                        CreateOffice();
                        Console.Clear();
                        return true;
                    default:
                        return true;
                }
            }

            void SelectOffice()
            {
                Console.Clear();
                AnsiConsole.Render(rule);
                foreach (var office in offices)
                {
                    AnsiConsole.Markup($"[white]{office.OfficeId}.[/] [cyan1][underline]{office.Name} - {office.Location}[/][/]\n");
                }
                var officeSelection = int.Parse(Console.ReadLine());
                selectedOffice = offices.Find(office => office.OfficeId == officeSelection);
                salesPeople = selectedOffice.SalesEmployees;
            }

            void CreateOffice()
            {
                Console.Clear();
                AnsiConsole.Render(rule);

                AnsiConsole.Render(new Markup("[wheat1]Create New Office: [/]"));
                AnsiConsole.Render(new Markup("[bold red]Enter Name [/]"));
                var name = Console.ReadLine();
                Console.WriteLine("------------");
                AnsiConsole.Render(new Markup("[bold red]Enter Location [/]"));
                var location = Console.ReadLine();
                var newOffice = new Office(name, offices.Last().OfficeId + 1, location);
                offices.Add(newOffice);
            }

            bool MainMenu()
            {
                Console.Clear();
                AnsiConsole.Render(rule);
                AnsiConsole.Render(new Markup("[white]Please Select An Option: [/]"));
                AnsiConsole.Render(new Markup("\n1. [cyan1]Enter[/] [wheat1]Sales[/]"));
                AnsiConsole.Render(new Markup("\n2. [green1]Generate[/] [wheat1]Report For Accountant[/]"));
                AnsiConsole.Render(new Markup("\n3. [fuchsia]Add New[/] [wheat1]Sales Employee[/]"));
                AnsiConsole.Render(new Markup("\n4. [#ffff00]Find[/] [wheat1]A Sale[/]"));
                AnsiConsole.Render(new Markup("\n5. [bold red]Exit[/]\n"));
                

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
                Console.Clear();
                AnsiConsole.Render(rule);
                AnsiConsole.Markup("[wheat1]Which Sales Employee Are You?[/]\n");
                if (salesPeople.Capacity > 0)
                {
                    foreach (var closer in salesPeople)
                    {
                        AnsiConsole.Markup($"[dodgerblue2]{closer.IdNumber}. {closer.FirstName} {closer.LastName}[/]\n");
                    }
                    var selection = Console.ReadLine();
                    var selectedSeller = salesPeople.Find(closer => closer.IdNumber == int.Parse(selection));

                    AnsiConsole.Render(new Markup($"[wheat1]Hi,[/] [dodgerblue2]{selectedSeller.FirstName}![/]\n"));
                    AnsiConsole.Render(new Markup("[wheat1]Please Enter The Client's[/] [aqua]Name:[/]\n"));

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
                    AnsiConsole.Markup($"[wheat1]Client ID is now[/] [red]{lastId}[/]\n");
                    AnsiConsole.Markup("[wheat1]Enter The[/] [lime]Dollar Amount[/] [wheat1]For The Sale:[/]\n");
 
                    var saleAmount = int.Parse(Console.ReadLine());
                    if (saleAmount <= 0)
                    {
                        AnsiConsole.Markup("[red]I DECLARE BANKRUPTCY![/]\n");
                    }

                    AnsiConsole.Markup($"[wheat1]Enter The[/] [fuchsia]Frequency[/] [wheat1]Of Payment (I.E. Weekly, Monthly, etc.)[/]\n");
                    var payDay = Console.ReadLine();

                    AnsiConsole.Markup($"[wheat1]Enter Contract[/] [darkorange]Term Length: [/]\n");
                    var term = Console.ReadLine();

                    var sale = new Sale(selectedSeller, clientName, lastId, saleAmount, payDay, term);
                    selectedSeller.Sales.Add(sale);
                    Caboose();
                }
                else
                {
                    Console.WriteLine("No Current Sales Employees, Please Return To Main Menu To Add An Employee.");
                    Caboose();
                }
            }

            void GenerateReport()
            {
                AnsiConsole.Markup("\n[wheat1]Generate A Report[/]\n");
                AnsiConsole.Markup("[wheat1]---------------------------[/]\n");
                AnsiConsole.Markup("[wheat1]Choose Which Accountant To Generate A Report For:[/]\n");

                foreach (var accountant in accountants)
                {
                    AnsiConsole.Markup($"[white]{accountant.IdNumber}.[/] [underline cyan1]{accountant.FirstName}[/]\n");
                }
                var selectionNumber = Console.ReadLine();
                var selectedAccountant = accountants.Find(accountant => accountant.IdNumber == int.Parse(selectionNumber));
                AnsiConsole.Markup("[wheat1]Please Select Which Report You Would Like To Generate: \n[white]1.[/] [lime]Office Wide[/] Report\n[white]2.[/] [fuchsia]Itemized Salesperson[/] Report \n[white]3.[/] [aqua]Specific Salesperson[/] Report[/]\n");

                switch (Console.ReadLine())
                {
                    case "1":
                        AnsiConsole.Markup("\n[underline wheat1]Total Office Sales Report[/]\n");
                        AnsiConsole.Markup($"[wheat1]For: {selectedAccountant.FirstName}[/]\n");
                        AnsiConsole.Markup("[wheat1]---------------------------[/]\n");
                        var grandTotal = 0;
                        foreach (var salesPerson in salesPeople)
                        {
                            foreach (var sale in salesPerson.Sales)
                            {
                                AnsiConsole.Markup($"[wheat1]-[/] [aqua]{sale.Client}:[/] [lime]${sale.Amount}[/]\n");
                                grandTotal += sale.Amount;
                            }
                        }
                        AnsiConsole.Markup($"[wheat1]Your office total sales are: [lime]${grandTotal}[/][/]\n");
                        break;
                    case "2":
                        AnsiConsole.Markup("\n[underline wheat1]Itemized Sales Report[/]\n");
                        AnsiConsole.Markup($"[wheat1]For: {selectedAccountant.FirstName}[/]\n");
                        AnsiConsole.Markup("[wheat1]---------------------------[/]\n");
                        int salesPersonCount = 0;
                        foreach (var salesPerson in salesPeople)
                        {
                            salesPersonCount++;
                            AnsiConsole.Markup($"\n[white]{salesPersonCount}.[/] [underline aqua]{salesPerson.FirstName} {salesPerson.LastName}[/]\n");
                            AnsiConsole.Markup("\t[wheat1]Clients:[/]\n".PadLeft(10));
                            int saleCount = 0;
                            int salesTotal = 0;
                            foreach (var sale in salesPerson.Sales)
                            {
                                saleCount++;
                                AnsiConsole.Markup($"\t\t[white]{saleCount}.[/] [underline #ffff00]{sale.Client}[/]\n");
                                salesTotal += sale.Amount;
                            }
                            AnsiConsole.Markup($"\t[wheat1]Total:[/] [lime]${salesTotal}[/]\n");
                        }
                        break;
                    case "3":
                        AnsiConsole.Markup("[wheat1]Select Which Salesperson To Generate A Report For:[/]\n");
                        foreach (var salesPerson in salesPeople)
                        {
                            AnsiConsole.Markup($"[white]{salesPerson.IdNumber}.[/] [underline cyan1]{salesPerson.FirstName} {salesPerson.LastName}[/]\n");
                        }
                        var selection = int.Parse(Console.ReadLine());
                        var selectedSalesPerson = salesPeople.Find(salesPerson => salesPerson.IdNumber == selection);
                        AnsiConsole.Markup("\n[wheat1]Itemized Sales Report[/]");
                        AnsiConsole.Markup($"[wheat1]For: {selectedAccountant.FirstName}[/]\n");
                        AnsiConsole.Markup("[wheat1]---------------------------[/]\n");
                        AnsiConsole.Markup($"\n[underline aqua]{selectedSalesPerson.FirstName} {selectedSalesPerson.LastName}'s Sales:[/]\n");
                        var total = 0;
                        foreach (var sale in selectedSalesPerson.Sales)
                        {
                            AnsiConsole.Markup($"\n[wheat1]Client Name:[/] \t\t[aqua]{sale.Client}[/]\n");
                            AnsiConsole.Markup($"[wheat1]Client ID:[/] \t\t[red]{sale.ClientId}[/]\n");
                            AnsiConsole.Markup($"[wheat1]Sale Amount:[/] \t\t[lime]${sale.Amount}[/]\n");
                            AnsiConsole.Markup($"[wheat1]Frequency:[/] \t\t[fuchsia]{sale.Recurring}[/]\n");
                            AnsiConsole.Markup($"[wheat1]Contract Length:[/] \t[darkorange]{sale.TimeFrame}[/]\n");
                            total += sale.Amount;
                        }
                        AnsiConsole.Markup($"[wheat1]Total Sales:[/] \t[lime]${total}[/]\n");
                        break;
                }
                Caboose();
            }

            void CreateNewSalesperson()
            {

                
=======
                Console.Clear();
                AnsiConsole.Render(rule);
                AnsiConsole.Render(new Markup("[wheat1]\nEnter New Salesperson's First Name: [/]"));

                string salesFirstName;
                salesFirstName = Console.ReadLine();

                AnsiConsole.Render(new Markup("[wheat1]Enter New Salesperson's Last Name: [/]"));
                string salesLastName;
                salesLastName = Console.ReadLine();

                var newSalesEmployee = new SalesEmployee(salesFirstName, salesLastName, salesPeople.Last().IdNumber + 1);

                salesPeople.Add(newSalesEmployee);

                AnsiConsole.Render(new Markup($"[deepskyblue1]Hi, {salesFirstName}[/]"));
                Caboose();
            }

            void FindSaleInfo()
            {
                Console.Clear();
                AnsiConsole.Render(rule);
                AnsiConsole.Render(new Markup("[#ffff00]\n Enter A Client ID To Find Report![/]\n"));

                var searchId = int.Parse(Console.ReadLine());
                var found = false;
                foreach (var salesPerson in salesPeople)
                {
                    var foundSale = salesPerson.Sales.Find(sale => sale.ClientId == searchId);
                    if (foundSale != null)
                    {
                        AnsiConsole.Markup($"[#a082ec]Sales Agent: {salesPerson.FirstName} {salesPerson.LastName}[/]");
                        AnsiConsole.Markup($"[#bf7ed8]\n Client Name: {foundSale.Client}[/]");
                        AnsiConsole.Markup($"[#6381dc]\n Client ID: {foundSale.ClientId}[/]");
                        AnsiConsole.Markup($"[#0fdb5b]\n Sale Amount: ${foundSale.Amount}[/]");
                        AnsiConsole.Markup($"[#e48c62]\n Frequency: {foundSale.Recurring}[/]");
                        AnsiConsole.Markup($"[#a79728]\n Contract Length: {foundSale.TimeFrame}[/] ");
                        found = true;
                    } 
                }
                    if (!found)
                    {
                        AnsiConsole.Render(new Markup("[bold red]\n No Client Found With That ID[/]"));
                        
                    }

                Caboose();
            }

            void Caboose()
            {
                AnsiConsole.Render(new Markup("[blue]\nPress Enter To Return To Main Menu[/]"));
                var command = Console.ReadLine();
                showMenu = true;
            }
        }
    }
}

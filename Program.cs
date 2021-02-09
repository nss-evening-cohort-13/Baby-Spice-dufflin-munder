using System;

namespace Baby_Spice_ConsoleProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Dufflin/Munder Cardboard Co. ");
            Console.WriteLine("Sales Portal!\n");
            Console.WriteLine("1. Enter Sales");
            Console.WriteLine("2. Generate Report For Accountant");
            Console.WriteLine("3. Add New Sales Employee");
            Console.WriteLine("4. Find A Sale");
            Console.WriteLine("5. Exit");

            var running = true;
            while (running)
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Which Sales Employee Are You?");
                        break;
                    case "2":
                        Console.WriteLine("Generate A Report");
                        break;
                    case "3":
                        Console.WriteLine("Update me");
                        break;
                    case "4":
                        Console.WriteLine("Enter Sale Info");
                        break;
                    case "5":
                        Console.WriteLine("Beat it, Bozo!");
                        running = false;
                        break;
                }
            }
        }
    }
}

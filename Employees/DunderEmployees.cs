using System;
using System.Collections.Generic;
using System.Text;

namespace Baby_Spice_ConsoleProject.Employees
{
    class DunderEmployees
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DunderEmployees(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public void Greet()
        {
            Console.WriteLine($"Hi, {FirstName}");
        }
    }
   
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Baby_Spice_ConsoleProject.Employees
{
    abstract class DunderEmployees
    {
        public int IdNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public void Greet()
        {
            Console.WriteLine($"Hi, {FirstName}");
        }
    }
   
}

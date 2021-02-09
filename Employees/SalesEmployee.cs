using System;
using System.Collections.Generic;
using System.Text;
using Baby_Spice_ConsoleProject;

namespace Baby_Spice_ConsoleProject.Employees
{
    class SalesEmployee : DunderEmployees
    {
        public List<Sale> Sales { get; set; }

        public SalesEmployee(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}

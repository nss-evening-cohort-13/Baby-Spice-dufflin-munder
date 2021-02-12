using System;
using System.Collections.Generic;
using System.Text;
using Baby_Spice_ConsoleProject;

namespace Baby_Spice_ConsoleProject.Employees
{
    class SalesEmployee : DunderEmployees
    {
        public List<Sale> Sales { get; set; } = new List<Sale>();

        public SalesEmployee(string firstName, string lastName, int idNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            IdNumber = idNumber;
        }
    }
}

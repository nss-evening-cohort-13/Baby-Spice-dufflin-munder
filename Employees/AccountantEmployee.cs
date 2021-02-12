using System;
using System.Collections.Generic;
using System.Text;

namespace Baby_Spice_ConsoleProject.Employees
{
    class AccountantEmployee : DunderEmployees
    {
        public AccountantEmployee(string firstName, string lastName, int idNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            IdNumber = idNumber;
        }
    }
}

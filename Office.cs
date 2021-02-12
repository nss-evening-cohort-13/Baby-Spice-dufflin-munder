using System;
using System.Collections.Generic;
using System.Text;
using Baby_Spice_ConsoleProject.Employees;

namespace Baby_Spice_ConsoleProject
{
    class Office
    {
        public string Name { get; set; }
        public int OfficeId { get; set; }
        public List<SalesEmployee> SalesEmployees { get; set; } = new List<SalesEmployee>();
        public string Location { get; set; }

        public Office(string name, int officeId, string location)
        {
            Name = name;
            Location = location;
            OfficeId = officeId;
        }
    }
}

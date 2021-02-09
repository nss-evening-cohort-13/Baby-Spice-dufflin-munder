using System;
using System.Collections.Generic;
using System.Text;
using Baby_Spice_ConsoleProject.Employees;

namespace Baby_Spice_ConsoleProject
{
    class Sale
    {
        public SalesEmployee SalesAgent { get; set; }
        public string Client { get; set; }
        public int ClientId { get; set; }
        public int Amount { get; set; }
        public string Recurring { get; set; }
        public string TimeFrame { get; set; }

        public Sale(SalesEmployee salesAgent, string client, int clientId, int amount, string recurring, string timeFrame)
        {
            SalesAgent = salesAgent;
            Client = client;
            Amount = amount;
            Recurring = recurring;
            TimeFrame = timeFrame;
            ClientId = clientId;
        }
    }
}

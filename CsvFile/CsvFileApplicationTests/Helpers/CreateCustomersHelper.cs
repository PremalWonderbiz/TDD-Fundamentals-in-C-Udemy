using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvFileApplication;

namespace CsvFileApplicationTests.Helpers
{
    public static class CreateCustomersHelper
    {
        public static List<Customer> GetCustomers(int count)
        {
            var customers = new List<Customer>();
            for (int i = 1; i <= count; i++)
            {
                var customer = new Customer()
                {
                    Name = "Customer" + i,
                    ContactNumber = "900000000" + i
                };
                customers.Add(customer);
            }
            return customers;
        }
    }
}

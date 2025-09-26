using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvFileApplication;

namespace CsvFileApplicationTests
{
    public class FakeCustomerCsvFileWriter : ICustomerCsvFileWriter
    {
        public List<(string FileName, List<Customer> Customers)> Calls { get; private set; } = new();
        public void Write(string fileName, List<Customer> customers)
        {
            Calls.Add((fileName, customers));
        }
    }
}

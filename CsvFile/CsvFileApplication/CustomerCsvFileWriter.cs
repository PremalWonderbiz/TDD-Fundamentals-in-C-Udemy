using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvFileApplication
{
    public class CustomerCsvFileWriter : ICustomerCsvFileWriter
    {
        private readonly IFileSystem _fileSystem;
        public CustomerCsvFileWriter(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public void Write(string fileName, List<Customer> customers)
        {
            if(customers is null) throw new ArgumentNullException(nameof(customers));
            foreach (var customer in customers)
            {
                var line = customer.Name + ", " + customer.ContactNumber;
                _fileSystem.WriteLine(fileName, line);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvFileApplication;
using CsvFileApplicationTests.Helpers;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace CsvFileApplicationTests
{
    [TestFixture]
    public class DeDuplicatingCsvFileWriterTests
    {
        [TestCase(2)]
        [TestCase(5)]
        [TestCase(20)]
        public void UniqueCustomers(int numOfCustomers)
        {
            //Arrange
            var customers = CreateCustomersHelper.GetCustomers(numOfCustomers);

            var csvFileWriter = new FakeCustomerCsvFileWriter();
            var sut = new DeDuplicatingCsvFileWriter(csvFileWriter);
            var fileName = "myCustomers.csv";

            //Act
            sut.Write(fileName, customers);

            //Assert
            AssertCustomersWereWrittenToFile("myCustomers.csv", customers, csvFileWriter);
        }

        [Test]
        public void OneDuplicateCustomers()
        {
            //Arrange
            var customers = new List<Customer>();
            var customer1 = new Customer { Name = "Customer1", ContactNumber = "123" };
            var customer2 = new Customer { Name = "Customer1", ContactNumber = "456" };
            customers.Add(customer1);
            customers.Add(customer2);

            var csvFileWriter = new FakeCustomerCsvFileWriter();
            var sut = new DeDuplicatingCsvFileWriter(csvFileWriter);
            var fileName = "myCustomers.csv";

            //Act
            sut.Write(fileName, customers);

            //Assert
            AssertCustomersWereWrittenToFile("myCustomers.csv", new List<Customer> { customer1 }, csvFileWriter);
        }
        
        [Test]
        public void MultipleDuplicateCustomers()
        {
            //Arrange
            var customers = new List<Customer>();
            var customer1 = new Customer { Name = "Prem", ContactNumber = "123" };
            var customer2 = new Customer { Name = "Prem", ContactNumber = "456" };
            var customer3 = new Customer { Name = "Amit", ContactNumber = "123" };
            var customer4 = new Customer { Name = "Amit", ContactNumber = "456" };
            customers.Add(customer1);
            customers.Add(customer2);
            customers.Add(customer3);
            customers.Add(customer4);

            var uniqueCustomers = CreateCustomersHelper.GetCustomers(3);
            customers.AddRange(uniqueCustomers);

            var csvFileWriter = new FakeCustomerCsvFileWriter();
            var sut = new DeDuplicatingCsvFileWriter(csvFileWriter);
            var fileName = "myCustomers.csv";

            var expectedCustomers = new List<Customer> { customer1, customer3 };
            expectedCustomers.AddRange(uniqueCustomers);

            //Act
            sut.Write(fileName, customers);

            //Assert
            AssertCustomersWereWrittenToFile("myCustomers.csv", expectedCustomers, csvFileWriter);
        }

        private static void AssertCustomersWereWrittenToFile(string expectedFileName, List<Customer> expectedCustomers, FakeCustomerCsvFileWriter csvFileWriter)
        {
            var call = csvFileWriter.Calls.Where(c => c.FileName == expectedFileName);
            ClassicAssert.IsTrue(call.Any(), $"No call made for file {expectedFileName}");
            CollectionAssert.AreEquivalent(expectedCustomers, call.First().Customers);
        }
    }
}

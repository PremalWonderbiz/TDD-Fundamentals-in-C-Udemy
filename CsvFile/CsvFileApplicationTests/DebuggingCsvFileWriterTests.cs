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
    public class DebuggingCsvFileWriterTests
    {
        [Test]
        public void TwoCsvsFileWriters()
        {
            //Arrange
            var customers = CreateCustomersHelper.GetCustomers(50);

            var csvFileWriter = new FakeCustomerCsvFileWriter();
            var debugCsvFileWriter = new FakeCustomerCsvFileWriter();
            var sut = new DebuggingCsvFileWriter(csvFileWriter, debugCsvFileWriter);
            var fileName = "myCustomers.csv";

            //Act
            sut.Write(fileName, customers);

            //Assert
            AssertCustomersWereWrittenToFile("myCustomers.csv", customers, csvFileWriter);
            AssertCustomersWereWrittenToFile("myCustomers_debug.csv", customers, debugCsvFileWriter);
        }
        
        [Test]
        [Ignore("Only run to test against file system")]
        public void RunTheTest()
        {
            //Arrange
            var customers = CreateCustomersHelper.GetCustomers(50);

            var csvFileWriter = new DeDuplicatingCsvFileWriter(new BatchedCsvFileWriter(new CustomerCsvFileWriter(new RealFileSystem()), 1500));
            var debugCsvFileWriter = new BatchedCsvFileWriter(new CustomerCsvFileWriter(new RealFileSystem()), 20);
            var sut = new DebuggingCsvFileWriter(csvFileWriter, debugCsvFileWriter);
            var fileName = "myCustomers.csv";

            //Act
            sut.Write(fileName, customers);

        }


        private static void AssertCustomersWereWrittenToFile(string expectedFileName, List<Customer> expectedCustomers, FakeCustomerCsvFileWriter csvFileWriter)
        {
            var call = csvFileWriter.Calls.Where(c => c.FileName == expectedFileName);
            ClassicAssert.IsTrue(call.Any(), $"No call made for file {expectedFileName}");
            CollectionAssert.AreEquivalent(expectedCustomers, call.First().Customers);
        }
    }
}

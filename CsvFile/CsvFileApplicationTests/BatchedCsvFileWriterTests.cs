using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvFileApplication;
using CsvFileApplicationTests.Helpers;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace CsvFileApplicationTests
{
    [TestFixture]
    public class BatchedCsvFileWriterTests
    {
        [TestFixture]
        public class Write
        {
            [TestFixture]
            public class SingleFile
            {
                [Test]
                public void FiveCustomers()
                {
                    //Arrange
                    var customer1 = new Customer()
                    {
                        Name = "Manas",
                        ContactNumber = "9977446655"
                    };

                    var customer2 = new Customer()
                    {
                        Name = "Ganesh",
                        ContactNumber = "9898773377"
                    };

                    var customer3 = new Customer()
                    {
                        Name = "Nikhil",
                        ContactNumber = "9876785675"
                    };

                    var customers = new List<Customer>();
                    customers.Add(customer1);
                    customers.Add(customer2);
                    customers.Add(customer3);

                    var csvFileWriter = new FakeCustomerCsvFileWriter();
                    var sut = new BatchedCsvFileWriter(csvFileWriter);
                    var fileName = "cust.csv";

                    //Act
                    sut.Write(fileName, customers);

                    //Assert
                    AssertCustomersWereWrittenToFile("cust1.csv", customers, csvFileWriter);
                }

                [Test]
                public void TowCustomers()
                {
                    //Arrange
                    var customers = CreateCustomersHelper.GetCustomers(2);

                    var csvFileWriter = new FakeCustomerCsvFileWriter();
                    var sut = new BatchedCsvFileWriter(csvFileWriter);
                    var fileName = "myCustomers.csv";

                    //Act
                    sut.Write(fileName, customers);

                    //Assert
                    AssertCustomersWereWrittenToFile("myCustomers1.csv", customers, csvFileWriter);
                }

                [Test]
                public void TenCustomers()
                {
                    //Arrange
                    var customers = CreateCustomersHelper.GetCustomers(10);

                    var csvFileWriter = new FakeCustomerCsvFileWriter();
                    var sut = new BatchedCsvFileWriter(csvFileWriter);
                    var fileName = "myCustomers.csv";

                    //Act
                    sut.Write(fileName, customers);

                    //Assert
                    AssertCustomersWereWrittenToFile("myCustomers1.csv", customers, csvFileWriter);
                    ClassicAssert.AreEqual(1, csvFileWriter.Calls.Count);
                }

            }

            private static void AssertCustomersWereWrittenToFile(string expectedFileName, List<Customer> expectedCustomers, FakeCustomerCsvFileWriter csvFileWriter)
            {
                var call = csvFileWriter.Calls.Where(c => c.FileName == expectedFileName);
                ClassicAssert.IsTrue(call.Any(), $"No call made for file {expectedFileName}");
                CollectionAssert.AreEquivalent(expectedCustomers, call.First().Customers);
            }

            [TestFixture]
            public class TwoFile
            {
                [Test]
                public void TwelveCustomers()
                {
                    //Arrange
                    var customers = CreateCustomersHelper.GetCustomers(12);

                    var csvFileWriter = new FakeCustomerCsvFileWriter();
                    var sut = new BatchedCsvFileWriter(csvFileWriter);
                    var fileName = "cust.csv";

                    //Act
                    sut.Write(fileName, customers);

                    //Assert

                    AssertCustomersWereWrittenToFile("cust1.csv", customers.Take(10).ToList(), csvFileWriter);

                    AssertCustomersWereWrittenToFile("cust2.csv", customers.Skip(10).Take(2).ToList(), csvFileWriter);
                }

                [Test]
                public void TwentyCustomers()
                {
                    //Arrange
                    var customers = CreateCustomersHelper.GetCustomers(20);

                    var csvFileWriter = new FakeCustomerCsvFileWriter();
                    var sut = new BatchedCsvFileWriter(csvFileWriter);
                    var fileName = "cust.csv";

                    //Act
                    sut.Write(fileName, customers);

                    //Assert

                    AssertCustomersWereWrittenToFile("cust1.csv", customers.Take(10).ToList(), csvFileWriter);
                    AssertCustomersWereWrittenToFile("cust2.csv", customers.Skip(10).ToList(), csvFileWriter);
                    ClassicAssert.AreEqual(2, csvFileWriter.Calls.Count);
                }
            }

            [TestFixture]
            public class ThreeFile
            {
                [Test]
                public void TwentyTowCustomers()
                {
                    //Arrange
                    var customers = CreateCustomersHelper.GetCustomers(22);

                    var csvFileWriter = new FakeCustomerCsvFileWriter();
                    var sut = new BatchedCsvFileWriter(csvFileWriter);
                    var fileName = "allCustomers.csv";

                    //Act
                    sut.Write(fileName, customers);

                    //Assert

                    AssertCustomersWereWrittenToFile("allCustomers1.csv", customers.Take(10).ToList(), csvFileWriter);
                    AssertCustomersWereWrittenToFile("allCustomers2.csv", customers.Skip(10).Take(10).ToList(), csvFileWriter);
                    AssertCustomersWereWrittenToFile("allCustomers3.csv", customers.Skip(20).ToList(), csvFileWriter);
                }

                [Test]
                public void ThirtyCustomers()
                {
                    //Arrange
                    var customers = CreateCustomersHelper.GetCustomers(22);

                    var csvFileWriter = new FakeCustomerCsvFileWriter();
                    var sut = new BatchedCsvFileWriter(csvFileWriter);
                    var fileName = "allCustomers.csv";

                    //Act
                    sut.Write(fileName, customers);

                    //Assert

                    AssertCustomersWereWrittenToFile("allCustomers1.csv", customers.Take(10).ToList(), csvFileWriter);
                    AssertCustomersWereWrittenToFile("allCustomers2.csv", customers.Skip(10).Take(10).ToList(), csvFileWriter);
                    AssertCustomersWereWrittenToFile("allCustomers3.csv", customers.Skip(20).ToList(), csvFileWriter);
                    ClassicAssert.AreEqual(3, csvFileWriter.Calls.Count);
                }
            }

            [TestFixture]
            public class DifferentBatchSize
            {
                [Test]
                public void FourCustomers_WithBatchSize3_ShouldWriteToTwoFiles()
                {
                    //Arrange
                    var customers = CreateCustomersHelper.GetCustomers(4);

                    var csvFileWriter = new FakeCustomerCsvFileWriter();
                    var sut = new BatchedCsvFileWriter(csvFileWriter, 3);
                    var fileName = "differentBatchSize.csv";

                    //Act
                    sut.Write(fileName, customers);

                    //Assert

                    AssertCustomersWereWrittenToFile("differentBatchSize1.csv", customers.Take(3).ToList(), csvFileWriter);

                    AssertCustomersWereWrittenToFile("differentBatchSize2.csv", customers.Skip(3).ToList(), csvFileWriter);
                }
                
                [Test]
                public void FiftyCustomers_WithBatchSize20_ShouldWriteToThreeFiles()
                {
                    //Arrange
                    var customers = CreateCustomersHelper.GetCustomers(50);

                    var csvFileWriter = new FakeCustomerCsvFileWriter();
                    var sut = new BatchedCsvFileWriter(csvFileWriter, 20);
                    var fileName = "differentBatchSize.csv";

                    //Act
                    sut.Write(fileName, customers);

                    //Assert

                    AssertCustomersWereWrittenToFile("differentBatchSize1.csv", customers.Take(20).ToList(), csvFileWriter);

                    AssertCustomersWereWrittenToFile("differentBatchSize2.csv", customers.Skip(20).Take(20).ToList(), csvFileWriter);

                    AssertCustomersWereWrittenToFile("differentBatchSize3.csv", customers.Skip(40).ToList(), csvFileWriter);
                }
            }

        }
        
    }
}

using CsvFileApplication;
using NUnit.Framework;
using NSubstitute;
using NUnit.Framework.Legacy;

namespace CsvFileApplicationTests
{
    //SOLID
    //Single Responsibility
    //Open/Closed
    //Liskov Substitution
    //Interface segregation
    //Dependency Inversion

    [TestFixture]
    public class CustomerCsvFileWriterTests
    {
        [Test]
        public void Write_GivenNoCustomer_ShouldWriteNoCustomerDataToCsvFile()
        {
            //Arrange
            var fileSystem = Substitute.For<IFileSystem>();
            var sut = new CustomerCsvFileWriter(fileSystem);

            //Act
            sut.Write("customer.csv", new List<Customer>());

            //Assert
            fileSystem.Received(0).WriteLine("customer.csv", Arg.Any<string>());
        }
        
        [Test]
        public void Write_GivenNull_ShouldWriteNoCustomerDataToCsvFile()
        {
            //Arrange
            var fileSystem = Substitute.For<IFileSystem>();
            var sut = new CustomerCsvFileWriter(fileSystem);

            //Assert and Act
            Assert.Throws<ArgumentNullException>(() => sut.Write("customer.csv", null));
        }

        [Test]
        public void Write_GivenOneCustomer_ShouldWriteCustomerDataToCsvFile()
        {
            //Arrange
            var customer = new Customer()
            {
                Name = "Premal",
                ContactNumber = "986373373"
            };
            var customers = new List<Customer>() { customer };
            
            var fileSystem = Substitute.For<IFileSystem>();
            var sut = new CustomerCsvFileWriter(fileSystem);

            //Act
            sut.Write("customer.csv", customers);

            //Assert
            fileSystem.Received(1).WriteLine("customer.csv", "Premal, 986373373");
        }
        
        [Test]
        public void Write_GivenTowCustomer_ShouldWriteBothCustomersDataToCsvFile()
        {
            //Arrange
            var customer1 = new Customer()
            {
                Name = "Premal",
                ContactNumber = "9977446655"
            };
            
            var customer2 = new Customer()
            {
                Name = "DJ",
                ContactNumber = "9898773377"
            };

            var customers = new List<Customer>();
            customers.Add(customer1);
            customers.Add(customer2);
            
            var fileSystem = Substitute.For<IFileSystem>();
            var sut = new CustomerCsvFileWriter(fileSystem);

            //Act
            sut.Write("cust.csv", customers);   

            //Assert
            fileSystem.Received(1).WriteLine("cust.csv", "Premal, 9977446655");
            fileSystem.Received(1).WriteLine("cust.csv", "DJ, 9898773377");
        }

        [Test]
        public void GivenCustomers_ShouldWriteOnlyCustomersDataToCsvFile()
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

            var fileSystem = Substitute.For<IFileSystem>();
            var sut = new CustomerCsvFileWriter(fileSystem);

            //Act
            sut.Write("cust.csv", customers);

            //Assert
            fileSystem.Received(3).WriteLine("cust.csv", Arg.Any<string>());
        }

    }
}

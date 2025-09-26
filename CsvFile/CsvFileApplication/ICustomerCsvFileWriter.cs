namespace CsvFileApplication
{
    public interface ICustomerCsvFileWriter
    {
        void Write(string fileName, List<Customer> customers);
    }
}
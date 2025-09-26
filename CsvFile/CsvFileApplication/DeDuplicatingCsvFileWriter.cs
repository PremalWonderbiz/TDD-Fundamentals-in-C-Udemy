using CsvFileApplication;

namespace CsvFileApplicationTests
{
    public class DeDuplicatingCsvFileWriter : ICustomerCsvFileWriter
    {
        private ICustomerCsvFileWriter _csvFileWriter;

        public DeDuplicatingCsvFileWriter(ICustomerCsvFileWriter csvFileWriter)
        {
            this._csvFileWriter = csvFileWriter;
        }

        public void Write(string fileName, List<Customer> customers)
        {
            _csvFileWriter.Write(fileName, customers.DistinctBy(c => c.Name).ToList());
        }
    }
}
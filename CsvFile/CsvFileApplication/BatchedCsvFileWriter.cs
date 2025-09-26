using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvFileApplication
{
    public class BatchedCsvFileWriter : ICustomerCsvFileWriter
    {
        private ICustomerCsvFileWriter _csvFileWriter;
        private int _batchSize = 10;

        public BatchedCsvFileWriter(ICustomerCsvFileWriter csvFileWriter)
        {
            _csvFileWriter = csvFileWriter;
        }

        public BatchedCsvFileWriter(ICustomerCsvFileWriter csvFileWriter, int batchSize)
        {
            _csvFileWriter = csvFileWriter;
            _batchSize = batchSize;
        }

        public void Write(string fileName, List<Customer> customers)
        {
            var baseFileName = Path.GetFileNameWithoutExtension(fileName);
            var batch = customers.Take(_batchSize).ToList();
            var remainingCustomers = customers.Skip(_batchSize);
            var batchCount = 1;

            while(batch.Any())
            {
                _csvFileWriter.Write(baseFileName + batchCount + ".csv", batch);
                batchCount += 1;
                batch = remainingCustomers.Take(_batchSize).ToList();
                remainingCustomers = remainingCustomers.Skip(_batchSize);
            }          
        }
    }
}

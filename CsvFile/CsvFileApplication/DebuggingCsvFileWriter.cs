using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvFileApplication
{
    public class DebuggingCsvFileWriter
    {
        private ICustomerCsvFileWriter _csvFileWriter;
        private ICustomerCsvFileWriter _debugCsvFileWriter;

        public DebuggingCsvFileWriter(ICustomerCsvFileWriter csvFileWriter, ICustomerCsvFileWriter debugCsvFileWriter)
        {
            this._csvFileWriter = csvFileWriter;
            _debugCsvFileWriter = debugCsvFileWriter;
        }

        public void Write(string fileName, List<Customer> customers)
        {
            _csvFileWriter.Write(fileName, customers.DistinctBy(c => c.Name).ToList());

            var baseFileName = Path.GetFileNameWithoutExtension(fileName);
            _debugCsvFileWriter.Write($"{baseFileName}_debug.csv", customers);
        }
    }
}

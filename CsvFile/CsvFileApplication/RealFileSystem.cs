using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvFileApplication
{
    public class RealFileSystem : IFileSystem
    {
        public void WriteLine(string fileName, string line)
        {
            File.AppendAllLines(fileName, new List<string> { line });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvFileApplication
{
    public interface IFileSystem
    {
        void WriteLine(string fileName, string line);
    }
}

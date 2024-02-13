using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFile;

namespace Autokereskedés
{
    public class Infile
    {
        public string[] fileLine { get; private set; }
        private TextFileReader reader;
        public Infile(string fileName)
        {
            reader = new TextFileReader(fileName);

        }
        public bool ReadInputFile()
        {
            if (reader.ReadLine(out string line))
            {
                char[] delimiters = new char[] { ','};
                string[] tokens = line.Split(delimiters,
                StringSplitOptions.RemoveEmptyEntries);
                fileLine = tokens;
                return true;
            }
            return false;
        }

    }
}

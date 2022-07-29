using System;
using System.Collections.Generic;
using System.IO;

namespace Infrastructure
{
    public class CsvFileAdapter
    {
        private readonly FileInfo _file;

        private const char Separator = ',';
        private const char Formatter = '"';
        private const char Empty = ' ';

        public CsvFileAdapter(FileInfo file)
        {
            _file = file ?? throw new ArgumentNullException("Provided file can't be null");
        }

        public IEnumerable<(string, string)> Read()
        {
            foreach (string line in File.ReadAllLines(_file.FullName))
            {
                int index = line.IndexOf(Separator);
                string first = line.Substring(0, index).Trim(Empty);
                string second = line.Substring(index + 1).Trim(Formatter, Empty);
                yield return (first, second);
            }
        }
    }
}

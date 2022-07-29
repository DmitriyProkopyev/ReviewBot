using System;
using System.IO;
using System.Linq;

namespace Application
{
    public static class Config
    {
        public const string Extension = ".csv";

        public static string GetPath()
        {
            string result = string.Empty;

            try
            {
                result = Directory.EnumerateFiles(AppContext.BaseDirectory)
                .First(path => path.EndsWith(Extension));
            }
            catch
            {
                throw new FileNotFoundException($"Required {Extension} file must be placed in the same folder as the application");
            }

            return result;
        }
    }
}

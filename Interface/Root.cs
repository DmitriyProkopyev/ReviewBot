using System;
using System.IO;
using Infrastructure;
using Domain;
using Application;

namespace Interface
{
    static class Root
    {
        [STAThread]
        private static void Main()
        {
            var file = new FileInfo(Config.GetPath());

            var adapter = new CsvFileAdapter(file);
            var formatter = new ReviewsFormatter();

            var book = new ReviewBook(adapter, formatter);
            var userInterface = new ConsoleInterface(book);
            userInterface.Start();
        }
    }
}

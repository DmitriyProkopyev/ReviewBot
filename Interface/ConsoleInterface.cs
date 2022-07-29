using System;
using Domain;
using System.Windows.Forms;

namespace Interface
{
    public class ConsoleInterface
    {
        private readonly ReviewBook _book;

        public const string InvalidInput = "Invalid input, try again";

        public ConsoleInterface(ReviewBook book)
        {
            _book = book ?? throw new ArgumentNullException(nameof(book));
        }

        public void Start()
        {
            int index = 0;

            foreach (string name in _book.Names)
            {
                index++;
                Console.WriteLine(index + ". " + name);
            }

            Console.WriteLine("\nНомер замечания:\n");

            while (true)
            {
                index = ReadInt();
                ClearLine();

                if (index < 1 || index > _book.Count)
                {
                    Error();
                    continue;
                }

                Clipboard.SetText(_book[index - 1]);
            }
        }

        private int ReadInt()
        {
            int result = 0;

            while (!int.TryParse(Console.ReadLine(), out result))
            {
                ClearLine();
                Error();
            }

            return result;
        }

        private void Error()
        {
            Console.WriteLine(InvalidInput);
            System.Threading.Thread.Sleep(500);
            ClearLine();
        }

        private void ClearLine()
        {
            Console.CursorTop -= 1;
            Console.CursorLeft = 0;
            
            for (int i = 0; i < Console.WindowWidth; i++)
                Console.Write(' ');

            Console.CursorTop -= 1;
            Console.CursorLeft = 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloOperators
{
    public class SimpleProgram
    {
        public ConsoleColor forReturn;
        public void ShowError(string error)
        {
            forReturn = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(error);
            Console.ForegroundColor = forReturn;
        }
        public string AskUser(string text)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(text);
            return Console.ReadLine();
        }

    }
}

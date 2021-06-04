using System;

namespace UsefulFunctions
{
    public static class ConsoleFunc
    {
        public static string AskUser(string text)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(text);
            return Console.ReadLine();
        }
        static void Main()
        {
            
        }
    }

    //private static void Main()
    //{ }
}

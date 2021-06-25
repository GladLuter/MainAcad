using System;
using System.Threading;

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

        public static void BeepString(string text)
        {
            var CharArray = text.ToCharArray();
            //Use foreach loop for character array in which
            foreach (var item2 in CharArray)
            {
                switch (item2)
                {
                    case '.': //Implement Console.Beep(1000, 250) for '.'
                        Console.Beep(1000, 250);
                        break;
                    case '-': // and Console.Beep(1000, 750) for '-'
                        Console.Beep(1000, 750);
                        break;
                    default: //Use Thread.Sleep(50) to separate sounds
                        Thread.Sleep(50);
                        break;
                }
            }
        }

        static void Main()
        {
            
        }
    }

    //private static void Main()
    //{ }
}

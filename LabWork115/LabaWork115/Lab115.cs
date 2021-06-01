using System;
using System.Threading;
using UsefulFunctions;

namespace LabaWork115
{
    class Program
    {
        static void Main(string[] args)
        {
            int a;
            try
            {
                do
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(@"Please,  type the number:
                    1.  f(a,b) = |a-b| (unary)
                    2.  f(a) = a (binary)
                    3.  music
                    4.  morse sos
          
                    ");
                    try
                    {
                        a = (int)uint.Parse(Console.ReadLine());
                        switch (a)
                        {
                            case 1:
                                My_strings();
                                Console.WriteLine("");
                                break;
                            case 2:
                                My_Binary();
                                Console.WriteLine("");
                                break;
                            case 3:
                                My_music();
                                Console.WriteLine("");
                                break;
                            case 4:
                                Morse_code();
                                Console.WriteLine("");
                                break;
                            default:
                                Console.WriteLine("Exit");
                                break;
                        }

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error" + e.Message);
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Press Spacebar to exit; press any key to continue");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                while (Console.ReadKey().Key != ConsoleKey.Spacebar);
                Console.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #region ToFromBinary
        static void My_Binary()
        {
            //Implement positive integer variable input

            //Present it like binary string
            //   For example, 4 as 100

            //Use modulus operator to obtain the remainder  (n % 2) 
            //and divide variable by 2 in the loop

            //Use the ToCharArray() method to transform string to chararray
            //and Array.Reverse() method

        }
        #endregion

        #region ToFromUnary
        static void My_strings()
        {
            Console.Clear();
            //Declare int and string variables for decimal and binary presentations
            int[] UserNumbers = new int[3] { 0, 0, 0 };
            string[] UserStrings = new string[2] { "", "" };
            string UserAnswer;
            string[] UserAnswerArr;
            int parseResult;

            while (true)
            {
                //Implement two positive integer variables input
                UserAnswer = ConsoleFunc.AskUser(UserNumbers[0] == 0 ? "Please,  enter 1 or 2 numbers" : "Please,  enter 1 more number");
                UserAnswerArr = UserAnswer.Split();
                if (UserAnswerArr.Length == 0)
                {
                    continue;
                }

                for (int i = 0; i <= Math.Min(UserNumbers[0], UserAnswerArr.Length - 1); i++)
                {
                    if (int.TryParse(UserAnswerArr[i], out parseResult) && parseResult == 0) { continue; }
                    UserNumbers[++UserNumbers[0]] = parseResult;
                }

                if (UserNumbers[0] != 2) { continue; }

                //To present each of them in the form of unary string use for loop
                for (int i = 0; i < UserStrings.Length; i++)
                {
                    for (int j = 0; j < UserNumbers[i + 1]; j++)
                    {
                        UserStrings[i] += "1";
                    }
                }

                Console.WriteLine($"Unary string for number {UserNumbers[1]} is {UserStrings[0]}");
                Console.WriteLine($"Unary string for number {UserNumbers[2]} is {UserStrings[1]}");

                //Use concatenation of these two strings 
                //Note it is necessary to use some symbol ( for example “#”) to separate
                string separate = "#";

                //Realize the  algorithm for replacing '1#1' to '#' by using the for loop 
                for (int i = 0; i <= Math.Min(UserNumbers[1], UserNumbers[2]) + 1; i++)
                {
                    //Delete the '#' from algorithm result
                    if (UserNumbers[1] - i < 0 && UserNumbers[2] - i < 0) { separate = ""; } //Check the numbers on the equality 0
                    else if (UserNumbers[1]-i < 0 || UserNumbers[2] - i < 0) { separate = "1"; }
                    //Output the result 
                    Console.WriteLine($"{((UserNumbers[1] - i > 0) ? new String('1', UserNumbers[1] - i): "")}" +
                        $"{separate}" +
                        $"{((UserNumbers[2] - i > 0) ? new String('1', UserNumbers[2] - i) : "")}");
                }
                                             
                break;
            }
        }
        #endregion

        #region My_music
        static void My_music()
        {
            //HappyBirthday
            Thread.Sleep(2000);
            Console.Beep(264, 125);
            Thread.Sleep(250);
            Console.Beep(264, 125);
            Thread.Sleep(125);
            Console.Beep(297, 500);
            Thread.Sleep(125);
            Console.Beep(264, 500);
            Thread.Sleep(125);
            Console.Beep(352, 500);
            Thread.Sleep(125);
            Console.Beep(330, 1000);
            Thread.Sleep(250);
            Console.Beep(264, 125);
            Thread.Sleep(250);
            Console.Beep(264, 125);
            Thread.Sleep(125);
            Console.Beep(297, 500);
            Thread.Sleep(125);
            Console.Beep(264, 500);
            Thread.Sleep(125);
            Console.Beep(396, 500);
            Thread.Sleep(125);
            Console.Beep(352, 1000);
            Thread.Sleep(250);
            Console.Beep(264, 125);
            Thread.Sleep(250);
            Console.Beep(264, 125);
            Thread.Sleep(125);
            Console.Beep(2642, 500);
            Thread.Sleep(125);
            Console.Beep(440, 500);
            Thread.Sleep(125);
            Console.Beep(352, 250);
            Thread.Sleep(125);
            Console.Beep(352, 125);
            Thread.Sleep(125);
            Console.Beep(330, 500);
            Thread.Sleep(125);
            Console.Beep(297, 1000);
            Thread.Sleep(250);
            Console.Beep(466, 125);
            Thread.Sleep(250);
            Console.Beep(466, 125);
            Thread.Sleep(125);
            Console.Beep(440, 500);
            Thread.Sleep(125);
            Console.Beep(352, 500);
            Thread.Sleep(125);
            Console.Beep(396, 500);
            Thread.Sleep(125);
            Console.Beep(352, 1000);
        }
        #endregion

        #region Morse
        static void Morse_code()
        {
            //Create string variable for 'sos'      

            //Use string array for Morse code
            string[,] Dictionary_arr = new string[,] { { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" },
            { ".-   ", "-... ", "-.-. ", "-..  ", ".    ", "..-. ", "--.  ", ".... ", "..   ", ".--- ", "-.-  ", ".-.. ", "--   ", "-.   ", "---  ", ".--. ", "--.- ", ".-.  ", "...  ", "-    ", "..-  ", "...- ", ".--  ", "-..- ", "-.-- ", "--.. ", "-----", ".----", "..---", "...--", "....-", ".....", "-....", "--...", "---..", "----." }};
            //Use ToCharArray() method for string to copy charecters to Unicode character array
            //Use foreach loop for character array in which

            //Implement Console.Beep(1000, 250) for '.'
            // and Console.Beep(1000, 750) for '-'

            //Use Thread.Sleep(50) to separate sounds
            //                  
        }

        #endregion
    }
}

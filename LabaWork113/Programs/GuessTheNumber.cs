using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloOperators
{
    class GuessTheNumber : SimpleProgram
    {
        public override void Run()
        {
            const int minVal = 1;
            const int maxVal = 100;

            Console.Clear();
            ShowTheCondition();
            var rand = new Random();
            int num = rand.Next(minVal, rand.Next(minVal + 1, maxVal)); // lets try random max value for more random number :)

            string UserAnswer;
            int parseResult;

            int counter = 0;

            while (true)
            {
                UserAnswer = AskUser("Please,  enter your guess (0 to repeat the rules):");
                if (UserAnswer.ToLower() == "q")
                {
                    return;
                }

                int.TryParse(UserAnswer, out parseResult);
                if(parseResult == 0)
                {
                    ShowTheCondition();
                    continue;
                } else if(parseResult > maxVal || parseResult < minVal)
                {
                    ShowError("You must enter number between " + minVal + " and " + maxVal);
                    continue;
                }

                counter++;

                if (parseResult > num)
                {
                    SendMessage(parseResult + " - Too high!", ConsoleColor.Magenta);
                } else if (parseResult < num)
                {
                    SendMessage(parseResult + " - Too low!", ConsoleColor.Blue);
                }
                else
                {
                    SendMessage(parseResult + " is right! Conngratilations, you try only " + counter + " times!", ConsoleColor.Cyan);
                    Console.ReadLine();
                    return;
                }
                
            }
        }
        private void ShowTheCondition()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"-User must guess the Number between 1 and max number defined by program
-They are told if they are too high, too low or if they have guessed the number correctly

");
            Console.WriteLine("For exit press q");
            //Implement input of the number
            // Implement input the for circle to calculate factorial of the number
            // Output the result
        }

        private void SendMessage(string text, ConsoleColor inpColor)
        {
            forReturn = Console.ForegroundColor;
            Console.ForegroundColor = inpColor;
            Console.WriteLine(text);
            Console.ForegroundColor = forReturn;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloOperators
{
    class Factorial : SimpleProgram
    {
        public void Run()
        {
            Console.Clear();
            ShowTheCondition();

            string UserAnswer;
            int parseResult;
            long result;
            int i;
            List<long> calculations = new List<long>();
            calculations.Add(1); // for 0

            while (true)
            {
                UserAnswer = AskUser("Please,  type number (r to repeat the rules)");
                if (UserAnswer.ToLower() == "q")
                {
                    return;
                } else if (UserAnswer.ToLower() == "r")
                {
                    ShowTheCondition();
                    continue;
                }

                int.TryParse(UserAnswer, out parseResult);
                
                if (calculations.Count() - 1 >= parseResult)
                {
                    ShowResult(parseResult + "! = " + calculations[parseResult]);
                    continue;
                }

                result = calculations.Last();
                i = calculations.Count();
                for(;i <= parseResult; i++)
                {
                    result *= i;
                    calculations.Add(result);
                }

                ShowResult($"{parseResult}! = {result}");

            }

        }
        private void ShowTheCondition()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"Implement input of the number
Implement input the for circle to calculate factorial of the number 
Output the result");
            Console.WriteLine("For exit press q");
            //Implement input of the number
            // Implement input the for circle to calculate factorial of the number
            // Output the result
        }
    }
}

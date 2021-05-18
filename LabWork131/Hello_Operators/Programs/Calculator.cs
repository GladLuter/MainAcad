using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloOperators
{
    public enum CalculatorVariant
    {
        Repeat,
        Multiplication,
        Divide,
        Addition,
        Subtraction,
        Exponentiation
    }
    class Calculator : SimpleProgram
    {
        public void Run()
        {
            const int UserNumbersCount = 2;
            Console.Clear();
            ShowTheCondition();
            string UserAnswer;
            string[] UserAnswerArr;
            double?[] UserNumbers;
            CalculatorVariant SelectedVariant;           

            while (true)
            {
                UserAnswer = AskUser("Please,  type numbers by step (0 to repeat the rules)");
                if (UserAnswer.ToLower() == "q")
                {
                    return;
                }
                else if (!Enum.TryParse(UserAnswer, out SelectedVariant) || !Enum.IsDefined(typeof(CalculatorVariant), SelectedVariant))
                {
                    continue;
                }

                if (SelectedVariant == CalculatorVariant.Repeat)
                {
                    ShowTheCondition();
                    continue;
                }

                UserNumbers = new double?[UserNumbersCount + 1] { null, null, null }; // +1 for result

                int j = 0;

                while (true)
                {
                    UserAnswer = AskUser(j == 0 ? "Please,  enter 1 or 2 numbers" : "Please,  enter 1 more number");
                    UserAnswerArr = UserAnswer.Split();
                    if (UserAnswerArr.Count() == 0) 
                    {
                        continue;
                    } 

                    for (int i = 0; i <= Math.Min(UserNumbersCount, UserAnswerArr.Count()-1); i++)
                    {
                        
                        double parseResult;
                        Double.TryParse(UserAnswerArr[i], out parseResult);
                        
                        for (j = 0; j <= UserNumbersCount-1; j++)
                        {
                            if (UserNumbers[j] == null)
                            {
                                UserNumbers[j] = parseResult;
                                break;
                            }
                        }
                        if (j == UserNumbersCount - 1)
                        {
                            break;
                        }
                    }

                    if (j != UserNumbersCount - 1)
                    {
                        continue;
                    } 
                    else if (SelectedVariant == CalculatorVariant.Divide && UserNumbers[1] == 0) 
                    {
                        ShowError("You can't Divide to 0!!!");
                        double? reserv = UserNumbers[0];
                        UserNumbers = new double?[UserNumbersCount + 1] { null, null, null };
                        UserNumbers[0] = reserv;
                        continue;
                    }

                    switch(SelectedVariant)
                    {
                        case CalculatorVariant.Addition:
                            UserNumbers[2] = UserNumbers[0] + UserNumbers[1];
                            break;
                        case CalculatorVariant.Divide:
                            UserNumbers[2] = UserNumbers[0] / UserNumbers[1];
                            break;
                        case CalculatorVariant.Multiplication:
                            UserNumbers[2] = UserNumbers[0] * UserNumbers[1];
                            break;
                        case CalculatorVariant.Subtraction:
                            UserNumbers[2] = UserNumbers[0] - UserNumbers[1];
                            break;
                        case CalculatorVariant.Exponentiation:
                            UserNumbers[2] = Math.Pow((double)UserNumbers[0], (double)UserNumbers[1]);
                            break;
                    }
                    ShowResult($"{UserNumbers[0]} {GetSymbol(SelectedVariant)} {UserNumbers[1]} = {UserNumbers[2]}");                  
                    ShowTheCondition();
                    break;
                }
            }

        }
        
        private void ShowTheCondition()
        {
            // Set Console.ForegroundColor  value
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"Select the arithmetic operation:
1. Multiplication 
2. Divide 
3. Addition 
4. Subtraction
5. Exponentiation ");
            Console.WriteLine("For exit press q");
            // Implement option input (1,2,3,4,5)
            //     and input of  two or one numbers
            //  Perform calculations and output the result 
        }

        private char GetSymbol(CalculatorVariant SelectedOperation)
        {
            switch (SelectedOperation)
            {
                case CalculatorVariant.Addition:
                    return '+';
                case CalculatorVariant.Divide:
                    return '/';
                case CalculatorVariant.Multiplication:
                    return '*';
                case CalculatorVariant.Exponentiation:
                    return '^';
                case CalculatorVariant.Subtraction:
                    return '-';
                default:
                    return ' ';
            }
        }
    }
}

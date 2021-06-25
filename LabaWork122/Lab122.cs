using System;
using System.Text;
using UsefulFunctions;

namespace LabaWork122
{
    class Lab122
    {
        static void Main(string[] args)
        {
            string UserAnswer;
            string[] UserAnswerArr;
            int[] BoxParams = new int[4];
            char? Symbol = null;
            string message = "";

            //Implement start position, width and height input
            while (BoxParams[0] < BoxParams.Length - 1)
            {                     
                UserAnswer = ConsoleFunc.AskUser("Please, enter Box parameters (start position, width and height)");
                UserAnswerArr = UserAnswer.Split();
                if (UserAnswerArr.Length == 0)
                {
                    continue;
                }
                for (int i = 0; i < UserAnswerArr.Length; i++)
                {
                    if (!int.TryParse(UserAnswerArr[i], out BoxParams[BoxParams[0] + 1]) || BoxParams[BoxParams[0] + 1] <= 0) { break; }     
                    BoxParams[0]++;
                }
            }

            //Implement symbol input
            while (Symbol is null)
            {    
                UserAnswer = ConsoleFunc.AskUser("Please, enter 1 symbol (allowed *,+,.)");
                switch (UserAnswer)
                {
                    case "*":
                        Symbol = '*';
                        break;
                    case "+":
                        Symbol = '+';
                        break;
                    case ".":
                        Symbol = '.';
                        break;
                }
            }
            //Implement message input
            while (message == "")
            {
                message = ConsoleFunc.AskUser("Please, enter message of box");
            }

            try
            {
                //Create Box class instance
                Box box = new Box(BoxParams, (char)Symbol, message);
                //Use  Box.Draw() method
                box.Draw();

                Console.WriteLine("Press any key...");
                Console.ReadLine();
            }
            catch (Exception)
            {
                Console.WriteLine("Error!");
            }
        }

    }
}

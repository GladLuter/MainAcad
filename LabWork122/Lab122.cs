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
            int StartPosition = 0, Width = 0, Height = 0, UserAnswerInt = 0;
            char? Symbol = null;
            string message = "";
            StringBuilder QuestionTxt = new StringBuilder();

            //Implement start position, width and height input
            while (StartPosition == 0 || Width == 0 || Height == 0)
            {
                if (StartPosition == 0)
                {
                    QuestionTxt.Clear();
                    QuestionTxt.Append("Please, enter start position");
                }
                else if (Width == 0)
                {
                    QuestionTxt.Clear();
                    QuestionTxt.Append("Please, enter width of box");
                }
                else if (Height == 0)
                {
                    QuestionTxt.Clear();
                    QuestionTxt.Append("Please, enter height of box");
                }

                UserAnswer = ConsoleFunc.AskUser(QuestionTxt.ToString());

                if (int.TryParse(UserAnswer, out UserAnswerInt) && UserAnswerInt <= 0) { continue; }
                else if (StartPosition == 0)
                    StartPosition = UserAnswerInt;
                else if (Width == 0)
                    Width = UserAnswerInt;
                else if (Height == 0)
                    Height = UserAnswerInt;
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
                Box box = new Box();
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

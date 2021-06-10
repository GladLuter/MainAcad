using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaWork122
{
    public class Box : IBox
    {
        private int[] BoxParams;
        public Box(int[] BoxParams_, char Symbol_, string message_)
        {
            BoxParams = BoxParams_;
            Symbol = Symbol_;
            message = message_;
            StartPosition = int.MaxValue;
            Width = int.MinValue;
            Height = int.MinValue;
        }
        //1.  Implement public  auto-implement properties for start position (point position)
        //auto-implement properties for width and height of the box
        //and auto-implement properties for a symbol of a given set of valid characters (*, + ,.) to be used for the border 
        //and a message inside the box
        public int StartPosition { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public char Symbol { get; private set; }
        public string message { get; private set; }

        //2.  Implement public Draw() method
        //to define start position, width and height, symbol, message  according to properties
        //Use Math.Min() and Math.Max() methods
        //Use draw() to draw the box with message
        public void Draw()
        {
            int i;
            for (i = 0; i < BoxParams.Length; i++)
            {
                StartPosition = Math.Min(StartPosition, BoxParams[i]);
                Width = Math.Max(Width, BoxParams[i]);
            }
            for (i = 0; i < BoxParams.Length; i++)
            {
                if (StartPosition == BoxParams[i] || Width == BoxParams[i])
                    continue;
                Height = BoxParams[i];
                break;
            }

            draw();

        }
        //3.  Implement private method draw() with parameters 
        //for start position, width and height, symbol, message
        //Change the message in the method to return the Box square
        //Use Console.SetCursorPosition() method
        //Trim the message if necessary
        private void draw()
        {
            Console.Clear();
            Console.CursorTop = 0;
            Console.CursorLeft = StartPosition;
            Console.WriteLine(new string(Symbol, Width));
            string[] messageArr = message.Split(default(char[]), Height-2);
            for (int i = 0; i < Height; i++)
            {
                Console.CursorLeft = StartPosition;
                Console.Write(Symbol);
                if(messageArr.Length >= i + 1)
                {
                    Console.Write(messageArr[i]);
                    if (messageArr[i].Length < Width - 2)
                    {
                        Console.Write(new string(' ', Width - messageArr[i].Length - 2));
                    }
                }else { 
                    Console.Write(new string(' ', Width-2)); 
                }
                Console.WriteLine(Symbol);
            }
            Console.CursorLeft = StartPosition;
            Console.WriteLine(new string(Symbol, Width));
        }

    }
}

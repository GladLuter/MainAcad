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
        private const int QtyBorders = 2;
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
            for (i = 1; i < BoxParams.Length; i++)
            {
                StartPosition = Math.Min(StartPosition, BoxParams[i]);
                Width = Math.Max(Width, BoxParams[i]);
            }
            for (i = 1; i < BoxParams.Length; i++)
            {
                if (StartPosition == BoxParams[i] || Width == BoxParams[i])
                    continue;
                Height = BoxParams[i];
                break;
            }
            // for square:
            if (Height == int.MinValue)
                Height = Width;

            // for border in each side
            Width += QtyBorders; 
            Height += QtyBorders;
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

            string[] messageArr = new string[Height - QtyBorders];//message.Split(null, Height - 2);
            //substring to fill up arr
            int SplitPosition = 0, LineLen = 0, i;

            for (i = 0; i < Height - QtyBorders; i++)
            {
                LineLen = Math.Min(message.Length - SplitPosition, Width - QtyBorders);
                messageArr[i] = message.Substring(SplitPosition, LineLen);               
                if (LineLen < Width - QtyBorders)
                    break;
                SplitPosition += Width - QtyBorders;
            }
            for (i = 0; i < Height - QtyBorders; i++)
            {
                Console.CursorLeft = StartPosition;
                Console.Write(Symbol);
                if (messageArr.Length >= i + 1 && messageArr[i] is not null)
                {
                    Console.Write(messageArr[i]);
                    if (messageArr[i].Length < Width - QtyBorders)
                    {
                        Console.Write(new string(' ', Width - messageArr[i].Length - QtyBorders));
                    }
                }
                else
                {
                    Console.Write(new string(' ', Width - QtyBorders));
                }
                Console.WriteLine(Symbol);
            }
            Console.CursorLeft = StartPosition;
            Console.WriteLine(new string(Symbol, Width));
        }

    }
}

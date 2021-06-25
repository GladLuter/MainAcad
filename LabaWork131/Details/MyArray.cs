using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaWork131
{
    class MyArray
    {
        int[] arr;

        public void Assign(int[] arr, int size)
        {
            // 5) add block try (outside of existing block try)
            try
            {
                try
                {
                    this.arr = new int[size];

                    // 1) assign some value to cell of array arr, which index is out of range
                    for (int i = 0; i < arr.Length; i++)
                        this.arr[i] = i + 1;

                    //this.arr[this.arr.Length + 15] = 15; // error

                    //for (int i = 0; i < arr.Length; i++)
                    //    this.arr[i] = arr[i] / arr[i + 1];


                    // 7) use unchecked to assign result of operation 1000000000 * 100 
                    // to last cell of array
                    //arr[arr.Length - 1] = 1000000000 * 100;

                    //NullReferenceException
                    CatchExceptionClass test = null;
                    Console.WriteLine(test.ToString());
                }
                // 2) catch exception index out of rage
                catch(IndexOutOfRangeException ex)
                {
                    Console.WriteLine($"We have exception out of range, with details: {ex.Message}");
                }
                //catch(Exception ex)
                //{
                //    // output message
                //    Console.WriteLine($"We have last stage exception, with details: {ex.Message}");
                //}
            }
            // 4) catch devision by 0 exception
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"We have exception devine by 0, with details: {ex.Message}");
            }
            // 6) add catch block for null reference exception of outside block try  
            // change the code to execute this block (any method of any class)
            catch (NullReferenceException ex)
            {
                UsefulFunctions.ConsoleFunc.BeepString(".-");
                Console.WriteLine($"We have exception nullable, with details: {ex.Message}");
            }
            //catch (Exception ex)
            //{
            //    // output message
            //    Console.WriteLine($"We have last stage exception, with details: {ex.Message}");
            //}           
        }
    }
}

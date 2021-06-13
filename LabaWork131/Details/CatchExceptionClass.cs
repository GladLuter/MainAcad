using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaWork131
{
    class CatchExceptionClass
    {
        public void CatchExceptionMethod()
        {
            try
            {
                MyArray ma = new MyArray();

                // 3) replace second elevent of array by 0

                int[] arr = new int[4] { 1, 4, 8, 5 };
                ma.Assign(arr, 4);

            }

            // 8) catch all other exceptions here
            catch
            {
                // 9) print System.Exception properties:
                // HelpLink, Message, Source, StackTrace, TargetSite

            }

            // 10) add finally block, print some message
            // explain features of block finally
            finally
            {

            }
        }
    }
}

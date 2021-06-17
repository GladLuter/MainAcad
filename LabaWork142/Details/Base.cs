using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaWork142
{
    public class Base<T> where T : new()
    {
        static Base()
        {
            System.Console.WriteLine("  Base static constructor");
            T intern = new T();
        }

    }
}

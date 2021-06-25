using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaWork142
{
    public sealed class Derived : Base<Derived>
    {
        public Derived()
        {
            System.Console.WriteLine("      Derived constructor");
        }
    }
}

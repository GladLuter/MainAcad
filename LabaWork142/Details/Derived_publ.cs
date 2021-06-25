using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaWork142
{
    public sealed class Derived_publ : Base_publ<Derived_publ>
    {
        public Derived_publ()
        {
            System.Console.WriteLine("      Derived constructor");
        }
    }
}

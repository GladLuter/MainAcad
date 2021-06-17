using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaWork141
{
    // 1) inherit EventArgs
    public class GoodsInfoEventArgs : EventArgs
    {
        // 2) declare property GoodsName
        // think about get and set attributes
        public string GoodsName { get; private set; }

        // 3) declare constructor to initialize GoodsName
        public GoodsInfoEventArgs(string name)
        {
            Console.WriteLine($"GoodsInfoEventArgs : EventArgs was created with name - {name}");
            GoodsName = name;
        }

    }
}

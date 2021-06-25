using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaWork141
{
    class Customer
    {
        // 6) declare private field name
        private string Name;

        // 7) declare constructor to initialize name
        public Customer(string name)
        {
            Console.WriteLine($"{DateTime.Now}: {name} was created");
            Name = name;
        }

        // 8) declare method GotNewGoods with 2 parameters:
        // 1 - object type
        // 2 - GoodsInfoEventArgs type
        public void GotNewGoods(object SomeObj, GoodsInfoEventArgs info)
        {
            Console.WriteLine($"{DateTime.Now}: {Name} recive info from {SomeObj} in method GotNewGoods about new good - {info.GoodsName}");
        }

    }
}

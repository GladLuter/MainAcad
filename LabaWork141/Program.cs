using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaWork141
{
    class Program
    {
        static void Main(string[] args)
        {
            // 9) declare object of OnlineShop
            Console.WriteLine($"OnlineShop MyShop will be created");
            OnlineShop MyShop = new OnlineShop();
            Console.WriteLine($"OnlineShop MyShop was created");

            // 10) declare several objects of Customer
            const int DBSize = 15;
            Customer[] CustomerDB = new Customer[DBSize];
            Console.WriteLine($"CustomerDB array was created");

            // 11) subscribe method GotNewGoods() of every Customer instance 
            // to event NewGoodsInfo of object of OnlineShop
            for (int i = 0; i < DBSize; i++)
            {
                CustomerDB[i] = new Customer($"Customer{i}");
                MyShop.OnlineShopHandler += CustomerDB[i].GotNewGoods;
                Console.WriteLine($"Customer{i} was created and added to MyShop.OnlineShopHandler");
            }

            // 12) invoke method NewGoods() of object of OnlineShop
            // discuss results
            Console.WriteLine($"MyShop will call NewGoods");
            MyShop.NewGoods("New goods arrived");
            Console.WriteLine($"MyShop was called NewGoods");

        }
    }
}

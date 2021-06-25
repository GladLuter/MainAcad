using System;

namespace LabaWork123
{
    class Lab123
    {
        static void Main(string[] args)
        {
            // 10) declare 2 objects
            var money1 = new Money(15, CurrencyTypes.EU);
            Console.Write("money1: ");
            money1.ShowCurrent();
            var money2 = new Money(30, CurrencyTypes.UAH);
            Console.Write("money2: ");
            money2.ShowCurrent();
            // 11) do operations
            // add 2 objects of Money
            var money3 = money1 + money2;
            Console.Write("money1 + money2: ");
            money3.ShowCurrent();
            // add 1st object of Money and double
            money1 += 5d;
            Console.Write("money1 += 5: ");
            money1.ShowCurrent();
            // decrease 2nd object of Money by 1 
            Console.Write("money2--: ");
            money2--;
            money2.ShowCurrent();
            // increase 1st object of Money
            money1 *= 3;
            Console.Write("money1 * 3: ");
            money1.ShowCurrent();

            // compare 2 objects of Money
            Console.WriteLine($"money1 > money2: {money1 > money2}");

            // compare 2nd object of Money and string
            Console.WriteLine($"money1 == 'this?': {money1 == "this?"}");

            // check CurrencyType of every object
            Console.WriteLine($"money1 is {(money1 ? "true":"false")}");
            Console.WriteLine($"money2 is {(money2 ? "true" : "false")}");
            money2 = null;
            Console.WriteLine($"money2 = null");
            Console.WriteLine($"money2 is {(money2 ? "true" : "false")}");

            // convert 1st object of Money to string
            Console.WriteLine($"money1 is {(string)money1}");
        }
    }
}

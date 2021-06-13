using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaWork123
{
    // 1) declare enumeration CurrencyTypes, values UAH, USD, EU
    public enum CurrencyTypes
    {
        UAH = 1,
        USD = 27, 
        EU = 33
    }

    public class Money
    {
        // 2) declare 2 properties Amount, CurrencyType
        public double Amount { get; set; }
        public CurrencyTypes CurrencyType { get; set; }
        // 3) declare parameter constructor for properties initialization
        public Money(double Amount_ = 0, CurrencyTypes CurrencyType_ = CurrencyTypes.UAH)
        {
            Amount = Amount_;
            CurrencyType = CurrencyType_;
        }

        public void ShowCurrent()
        {
            Console.WriteLine($"{this.Amount} {this.CurrencyType}");
        }

        public Money(Money money) : this(money.Amount, money.CurrencyType) { }
        // 4) declare overloading of operator + to add 2 objects of Money
        public static Money operator +(Money money1, Money money2)
        {
            Money result = new();
            if (money1.CurrencyType == money2.CurrencyType)
            {
                result.CurrencyType = money1.CurrencyType;
                result.Amount = money1.Amount + money2.Amount;
            }
            else {
                result.Amount = ((int)money1.CurrencyType) * money1.Amount + ((int)money2.CurrencyType) * money2.Amount;
            }
            return result;
        }

        public static Money operator +(Money money, double num)
        {
            Money result = new(money.Amount + num, money.CurrencyType);
            return result;
        }

        // 5) declare overloading of operator -- to decrease object of Money by 1
        public static Money operator --(Money money)
        {
            Money result = new(money.Amount - 1, money.CurrencyType);
            return result;
        }

        // 6) declare overloading of operator * to increase object of Money 3 times
        public static Money operator *(Money money, double num)
        {
            Money result = new(money.Amount * num, money.CurrencyType);
            return result;
        }

        // 7) declare overloading of operator > and < to compare 2 objects of Money
        public static bool operator >(Money money1, Money money2)
        {
            if(money1.CurrencyType == money2.CurrencyType)
            {
                return money1.Amount > money2.Amount;
            }
            else
            {
                return ((int)money1.CurrencyType) * money1.Amount > ((int)money2.CurrencyType) * money2.Amount;
            }
        }
        public static bool operator <(Money money1, Money money2)
        {
            return money2 > money1;
        }

        // 8) declare overloading of operator true and false to check CurrencyType of object
        public static bool operator true(Money money)
        {
            return money != null;
        }
        public static bool operator false(Money money)
        {
            return money == null;
        }

        // 9) declare overloading of implicit/ explicit conversion  to convert Money to double, string and vice versa
        public static implicit operator double(Money money) { return money.Amount; }
        public static implicit operator string(Money money) { return money.CurrencyType.ToString(); }
        //public static explicit operator bool(Money v)
        //{
        //    return true;
        //}
    }
}

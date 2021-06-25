using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaWork143
{
    // 12) change methods of sorting to properties
    //public static IComparer SortWeightAscending
    //{
    //    get { return (IComparer)}
    //}

    // 1) implement interface IComparable
    public class Animal : IComparable
    {
        public Animal(string Genus_, int Weight_)
        {
            Genus = Genus_;
            Weight = Weight_;
        }
        // 2) declare properties and parameter constructor
        public string Genus { get; private set; }
        public int Weight { get; private set; }

        // 3) implement method ComareTo()
        // it compares Genus of type string - return result of method String.Compare 
        // for this.genus and argument object
        // don't forget to cast object to Animal
        public int CompareTo(object obj)
        {
            if (obj is null)
                throw new NotImplementedException();

            var incObj = (Animal)obj;
            return this.Genus.CompareTo(incObj.Genus);
        }

        // 4) declare methods SortWeightAscending(), SortGenusDescending()
        // they are static and return IComparer
        // return type is custed from constructor of classes SortWeightAscendingHelper, 
        // SortGenusDescendingHelper calling
        public static IComparer<Animal> SortWeightAscending() { return new SortWeightAscendingHelper(); }
        public static IComparer<Animal> SortGenusDescending() { return new SortGenusDescendingHelper(); }



        // 5) declare 2 nested private classes SortWeightAscendingHelper, SortGenusDescendingHelper 
        // they implement interface IComparer
        // every nested class has implemented method Comare with 2 parameters of object and return int
        // class SortWeightAscendingHelper sort weight by ascending
        // class SortGenusDescendingHelper sort genus by descending
        private class SortWeightAscendingHelper : IComparer<Animal>
        {
            public int Compare(Animal x, Animal y)
            {
                return x.Weight - y.Weight;
                //if(x.Weight == y.Weight) { return 0; }
                //else if (x.Weight > y.Weight) { return 1; }
                //else if (x.Weight < y.Weight) { return -1; }
                //throw new NotImplementedException();
            }
        }
        private class SortGenusDescendingHelper : IComparer<Animal>
        {
            public int Compare(Animal x, Animal y)
            {
                return y.Genus.CompareTo(x.Genus);
            }
        }


    }
}

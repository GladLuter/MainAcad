using System;
using System.Collections.Generic;

namespace LabaWork143
{
    class Program
    {
        static void Main(string[] args)
        {
            const int AnimalsQty = 15;
            // 10) Create an array of Animal objects and object of Animals    
            // print animals with foreach operator for object of Animals
            var Animals = new Animals(AnimalsQty);
            var rand = new Random();
            for (int i = 0; i < AnimalsQty; i++)
            {
                Animals.Add($"Animal{i}", rand.Next());
            }


            // 11) Invoke 3 types of sorting 
            // and print results with foreach operator for array of Animal objects
            Console.WriteLine($"Created Animals");
            foreach (Animal item in Animals)
            {
                Console.WriteLine($"Genus: {item.Genus}; Weight:{item.Weight}");
            }

            Animals.Sort(Animal.SortWeightAscending());
            Console.WriteLine(new string('-', 100));
            Console.WriteLine($"Used SortWeightAscending");
            foreach (Animal item in Animals)
            {
                Console.WriteLine($"Genus: {item.Genus}; Weight:{item.Weight}");
            }

            Animals.Sort(Animal.SortGenusDescending());
            Console.WriteLine(new string('-', 100));
            Console.WriteLine($"Used SortGenusDescending");
            foreach (Animal item in Animals)
            {
                Console.WriteLine($"Genus: {item.Genus}; Weight:{item.Weight}");
            }


            Console.ReadLine();
        }
    }
}

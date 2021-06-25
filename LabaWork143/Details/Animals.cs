using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaWork143
{
    //6) implement interface IEnumerable
    public class Animals : IEnumerable
    {
        // 7) declare private array of Animal
        private Animal[] AnimalsArr;
        private int CurIdx;

        // 8) declare parameter constructor to initialize array
        public Animals(int qty) { AnimalsArr = new Animal[qty]; CurIdx = -1; }

        public void Add(Animal animal)
        {
            Add(animal.Genus, animal.Weight);
        }
        public void Add(string Genus_, int Weight_)
        {
            if (CurIdx == AnimalsArr.Length - 1)
                return;

            CurIdx++;
            AnimalsArr[CurIdx] = new Animal(Genus_, Weight_);
        }
        // 9) implement method GetEnumerator(), which returns IEnumerator
        // use foreach on array of Animal
        // and yield return for every animal

        public IEnumerator GetEnumerator()
        {
            foreach (var animal in AnimalsArr)
            {
                yield return animal;
            }
        }

    }
}

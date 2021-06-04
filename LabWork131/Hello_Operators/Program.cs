using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloOperators
{
    public enum LabVariant
    {
        Type1 = 1, Type2, Type3, Type4
    }

    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine(@"Please, type the number of Lab1.3 type:
1. Farmer, wolf, goat and cabbage puzzle
2. Console calculator
3. Factirial calculation
4. Guess the Number

or any other key to exit
            ");

            if (!Enum.TryParse(Console.ReadLine(), out LabVariant UserVariant) || !Enum.IsDefined(typeof(LabVariant), UserVariant))
            {
                Console.WriteLine(@"Exit
Press any key");
                Console.ReadLine();
                return;
            }

            var SelectedProgram = GetProgramm(UserVariant);
            if (SelectedProgram != null)
            {
                SelectedProgram.Run();
            }

            Console.WriteLine("Press any key");
            Console.ReadLine();
        }

        private static SimpleProgram GetProgramm(LabVariant Variant) {

            switch (Variant)
            {
                case LabVariant.Type1:
                    return new FarmerPuzzle();
                    //break;
                case LabVariant.Type2:
                    return new Calculator();
                    //break;
                case LabVariant.Type3:
                    return new Factorial();
                    //break;
                case LabVariant.Type4:
                    return new GuessTheNumber();
                    //break;
                default:
                    return null;
            }

        }

    }
}

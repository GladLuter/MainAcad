using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloOperators
{
    public enum FermerVariant
    {
        Repeat,
        ThereFarmerAndWolf,
        ThereFarmerAndCabbage,
        ThereFarmerAndGoat,
        ThereFarmer,
        BackFarmerAndWolf,
        BackFarmerAndCabbage,
        BackFarmerAndGoat,
        BackFarmer,
        ShowFirstCoast,
        ShowSecondCoast
    }

    public enum FarmerProperty
    {
        wolf,
        goat,
        cabbage
    }

    public class Coast
    {
        ConsoleColor forReturn;
        public Coast(bool first = false)
        {
            isFarmare = first;
            isGoat = first;
            isCabbage = first;
            isWolf = first;
        }

        public void StepRun(FarmerProperty? TakeAway)
        {
            isFarmare = !isFarmare;
            switch (TakeAway)
            {
                case FarmerProperty.wolf:
                    isWolf = !isWolf;
                    break;
                case FarmerProperty.goat:
                    isGoat = !isGoat;
                    break;
                case FarmerProperty.cabbage:
                    isCabbage = !isCabbage;
                    break;
            }
        }

        public bool StepCheck(FarmerProperty? TakeAway)
        {
            // if we don't have a farmer, he will come now
            // we have problems only when we he will left coast
            if (!isFarmare) 
            {
                return true;
            }

            bool isWolfCheck = isWolf;
            bool isGoatCheck = isGoat;
            bool isCabbageCheck = isCabbage;

            switch(TakeAway)
            {
                case FarmerProperty.wolf:
                    if (!isWolf)
                    {
                        ShowError("Error: we don't have a wolf on this island!");
                        return false;
                    }
                    isWolfCheck = !isWolfCheck;
                    break;
                case FarmerProperty.goat:
                    if (!isGoat)
                    {
                        ShowError("Error: we don't have a goat on this island!");
                        return false;
                    }
                    isGoatCheck = !isGoatCheck;
                    break;
                case FarmerProperty.cabbage:
                    if (!isCabbage)
                    {
                        ShowError("Error: we don't have a cabbage on this island!");
                        return false;
                    }
                    isCabbageCheck = !isCabbageCheck;
                    break;    
            }

            if(isWolfCheck && isGoatCheck)
            {
                ShowError("Error: wolf will eat goat!!!");
                return false;
            } else if (isGoatCheck && isCabbageCheck)
            {
                ShowError("Error: goat will eat cabbage!!!");
                return false;
            }
            
            return true;

        }
        public void ShowCoast() 
        {
            forReturn = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("On this coast we have:");
            Console.WriteLine("Farmare:" + (isFarmare ? "1" : "0"));
            Console.WriteLine("Wolf:" + (isWolf ? "1" : "0"));
            Console.WriteLine("Goat:" + (isGoat ? "1" : "0"));
            Console.WriteLine("Cabbage:" + (isCabbage ? "1" : "0"));
            Console.ForegroundColor = forReturn;
        }

        public bool AllIn()
        {
            return isWolf && isGoat && isCabbage;
        }

        private bool isWolf;
        private bool isGoat;
        private bool isCabbage;
        public bool isFarmare;

        private void ShowError(string error)
        {
            forReturn = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(error);
            Console.ForegroundColor = forReturn;
        }

    }
    
    public class FarmerPuzzle : SimpleProgram
    {
        public void Run()
        {
            Console.Clear();
            ShowTheCondition();
            string UserAnswer;
            FermerVariant SelectedVariant;
            Coast coast1 = new Coast(true);
            Coast coast2 = new Coast();
            FarmerProperty? farmerProperty;

            while (true)
            {
                UserAnswer = AskUser("Please,  type numbers by step (0 to repeat the rules)");
                if (UserAnswer.ToLower() == "q") {
                    return;
                } 
                else if(!Enum.TryParse(UserAnswer, out SelectedVariant) || !Enum.IsDefined(typeof(FermerVariant), SelectedVariant))
                {
                    continue;
                }

                if (SelectedVariant == FermerVariant.Repeat)
                {
                    ShowTheCondition();
                    continue;
                }

                if (ProhibitedAction(coast1, coast2, SelectedVariant))
                {
                    continue;
                }

                switch (SelectedVariant)
                {
                    case FermerVariant.ThereFarmer:
                    case FermerVariant.BackFarmer:
                        farmerProperty = null;
                        break;
                    case FermerVariant.ThereFarmerAndWolf:
                    case FermerVariant.BackFarmerAndWolf:
                        farmerProperty = FarmerProperty.wolf;
                        break;
                    case FermerVariant.ThereFarmerAndGoat:
                    case FermerVariant.BackFarmerAndGoat:
                        farmerProperty = FarmerProperty.goat;
                        break;
                    case FermerVariant.ThereFarmerAndCabbage:
                    case FermerVariant.BackFarmerAndCabbage:
                        farmerProperty = FarmerProperty.cabbage;
                        break;
                    case FermerVariant.ShowFirstCoast:
                        coast1.ShowCoast();
                        continue;
                    case FermerVariant.ShowSecondCoast:
                        coast2.ShowCoast();
                        continue;
                    default:
                        ShowError("unknown error, try again");
                        continue;
                }

                if(coast1.StepCheck(farmerProperty) && coast2.StepCheck(farmerProperty))
                {
                    coast1.StepRun(farmerProperty);
                    coast2.StepRun(farmerProperty);
                    forReturn = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Step was success");
                    Console.ForegroundColor = forReturn;

                    if (coast2.AllIn())
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("You WIN!!!");
                        Console.ReadLine();
                        return;
                    }
                }

            }
            

        }

        private void ShowTheCondition() {

            //Key sequence: 3817283 or 3827183
            // Declare 7 int variables for the input numbers and other variables
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"From one bank to another should carry a wolf, goat and cabbage. 
At the same time can neither carry nor leave together on the banks of a wolf and a goat, 
a goat and cabbage. You can only carry a wolf with cabbage or as each passenger separately. 
You can do whatever how many flights. How to transport the wolf, goat and cabbage that all went well?");
            Console.WriteLine("There: farmer and wolf - 1");
            Console.WriteLine("There: farmer and cabbage - 2");
            Console.WriteLine("There: farmer and goat - 3");
            Console.WriteLine("There: farmer  - 4");
            Console.WriteLine("Back: farmer and wolf - 5");
            Console.WriteLine("Back: farmer and cabbage - 6");
            Console.WriteLine("Back: farmer and goat - 7");
            Console.WriteLine("Back: farmer  - 8");
            Console.WriteLine("Show: first coast  - 9");
            Console.WriteLine("Show: second coast  - 10");
            Console.WriteLine("For exit press q");
            // Implement input and checking of the 7 numbers in the nested if-else blocks with the  Console.ForegroundColor changing
        }

        private bool ProhibitedAction(Coast coast1, Coast coast2, FermerVariant SelectedVariant)
        {
            if (coast1.isFarmare)
            {
                switch (SelectedVariant)
                {
                    case FermerVariant.BackFarmer:
                    case FermerVariant.BackFarmerAndGoat:
                    case FermerVariant.BackFarmerAndCabbage:
                    case FermerVariant.BackFarmerAndWolf:
                        ShowError("You can't do it, farmer on first coast");
                        return true;                  
                }
            }
            else if(coast2.isFarmare)
            {
                switch (SelectedVariant)
                {
                    case FermerVariant.ThereFarmer:
                    case FermerVariant.ThereFarmerAndCabbage:
                    case FermerVariant.ThereFarmerAndGoat:
                    case FermerVariant.ThereFarmerAndWolf:
                        ShowError("You can't do it, farmer on second coast");
                        return true;
                }
            }
            return false;
        }
    }
}

using System;

namespace LabaWork132
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Observation titmouse flight");
            Bird My_Bird = new Bird("Titmouse", 20);

            //1. Create the skeleton code with the  basic exception handling for the menu in the main method 
            //try - catch
            // 1. begin
            char rdk;
            try
            {
                do
                {
                    rdk = Console.ReadKey().KeyChar;
                } while (rdk != ' ');
            }
            catch (Exception mn)
            {
                Console.WriteLine($"We have exception with message: {mn.Message}");
            }

            //2. Create code for the nested special exception handling in the main method
            //try - catch - catch - finally
            // 2. begin
            try
            {
                var Inp = UsefulFunctions.ConsoleFunc.AskUser("Enter exeption text");
                throw (new Exception(Inp));
            }
            catch (Exception e)
            {

                Console.WriteLine($"CLS exception: Message -{e.Message} Sorce -{e.Source}");
            }
            finally { Console.WriteLine("For the next step ..."); }

            //3. Create the menu for three options in the inner try block  
            //In the second option throw the System.Exception
            // 3. begin
            Console.WriteLine(@"Monitoring in Try block
Please, type the number
1.array overflow
2.throw exception
3.user exception");

            try
            {
                uint variant = uint.Parse(Console.ReadLine());
                switch (variant)
                {
                    //4. in case 1 code array overflow exception 
                    case 1:
                        Console.WriteLine(GetOverflow());
                        break;
                    //in case 2 code throw (new System.Exception("Oh! My system exception..."));
                    case 2:
                        throw (new Exception("Oh! My system exception..."));
                    //in case 3  code the sequentially incrementing of Bird speed until to the exception 
                    case 3:
                        foreach (var item in My_Bird.FlySpeedGradation)
                        {
                            My_Bird.FlyAway(item);
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (BirdFlewAwayException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.When);
                Console.WriteLine(e.Why);
            }
            catch (Exception ex)
            {
                //throw;
                Console.WriteLine($"We have Exception - {ex.Message}");
            }

            // 3. end 

            // 2. end

            // 1. end

            static int GetOverflow()
            {
                return GetOverflow();
            }

        }
    }
}

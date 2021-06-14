using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaWork132
{
    //Create the Bird class with the fields, properties, constructors and the method
    //The public void FlyAway( int incrmnt ) method generates custom exception 
    public class Bird : IBird
    {
        //Create constructors
        public Bird(string name = "Unknown", int speed = 0)
        {
            Nick = name;
            BirdSpeed = speed;
        }
        //Create fields and properties
        private bool BirdFlewAway;
        public int BirdSpeed { get; private set; }
        public int[] FlySpeedGradation { get; private set; } = { 5, 15, 25, 35 };
        public string Nick { get; set; }

        private void SetNextSpeed()
        {
            for (int i = 0; i < FlySpeedGradation.Length; i++)
            {
                if (FlySpeedGradation[i] > BirdSpeed)
                {
                    BirdSpeed = FlySpeedGradation[i];
                    break;
                }
            }
        }

        //Implement Method public void FlyAway( int incrmnt ) which check Bird state by reading field  BirdFlewAway
        // check BirdFlewAway
        // if true 
            // write the message to console
        // else
            // increment the Bird speed by method argument
            // check the condition (NormalSpeed >= FlySpeed[3]) 
            // If it's true 
                // BirdFlewAway = true and we generate custom exception    BirdFlewAwayException(string.Format("{0} flew with incredible speed!", Nick), "Oh! Startle.", DateTime.Now)
                // with HelpLink = "http://en.wikipedia.org/wiki/Tufted_titmouse" else  console.writeline about Bird speed 
        public void FlyAway(int incrmnt)
        {
            if (BirdFlewAway)
            {
                Console.WriteLine("Bird flew away");
                return;
            }

            BirdSpeed += incrmnt;
            //SetNextSpeed();

            if (BirdSpeed >= FlySpeedGradation[3])
            {
                BirdFlewAway = true;
                var Ex = new BirdFlewAwayException($"{Nick} flew with incredible speed!", "Oh! Startle.", DateTime.Now);
                Ex.HelpLink = "http://en.wikipedia.org/wiki/Tufted_titmouse";
                throw Ex;
            }
            else
                Console.WriteLine($"Current speed is {BirdSpeed}");
        }      

    }
}

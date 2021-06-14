using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaWork132
{
    //Create the BirdFlewAwayException class, derived from ApplicationException  with two properties  
    //When
    //Why
    public class BirdFlewAwayException: ApplicationException
    {
        //Create constructors
        public BirdFlewAwayException(string message, string cause, DateTime time) : base(message)
        { When = time; Why = cause; }
        public DateTime When { get; private set; }
        public string Why { get; private set; }
    } 
}

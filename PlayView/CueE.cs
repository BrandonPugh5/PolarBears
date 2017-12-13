using System;
using System.Collections.Generic;

namespace PolarBearsProgram
{
    
    public class Cue
    {
       public List<Triggers> trigs = new List<Triggers>();
        
        String cueName; 

        public Cue(String Objectname)
        {
            Name(Objectname);
        
        }

        public void Name(String Objectname)
        {
            cueName = Objectname;
    
        }

        public String ReturnName()
        {
            return cueName;
        }

        //returns refrence name to cue
        public override string ToString()
        {
            return cueName;
        }
        //adds a trigger to to list of Trigger objects
        public void TriggerAdd(String plc,String motor, Boolean pause,String direction, int rotation, int acceleration,int deceleration, int velocity, int time)
        {
            trigs.Add(new Triggers(plc, motor, pause,direction, rotation, acceleration,deceleration, velocity, time));
        }

        public List<Triggers> ReturnTrigger()
        {
            return trigs;
        }
    }
}
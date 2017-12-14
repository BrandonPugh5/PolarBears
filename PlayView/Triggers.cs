using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PolarBearsProgram
{
    public class Triggers
    {
       public String rplc;
        public String rmotor;
        public Boolean rpause;
        public String rdirection;
        public int rrotation;
        public int raccel;
        public int rdecel;
        public int rvel;
        public int rtime;

        public Triggers(String plc, String motor, Boolean pause,String direction, int rotation, int acceleration,int deceleration, int velocity,int time)
        {
            this.rplc = plc;
            this.rmotor = motor;
            this.rpause = pause;
            this.rdirection = direction;
            this.rrotation = rotation;
            this.raccel = acceleration;
            this.rdecel = deceleration;
            this.rvel = velocity;
            this.rtime = time;
        }

        public String PLC()
        {
            return rplc;
        }

        public String Motor()
        {
            return rmotor;
        }

        public Boolean Pause()
        {
            return rpause;
        }
        public String Direction()
        {
            return rdirection;
        }

        public int Rotation()
        {
            return rrotation;
        }

        public int Acceleration()
        {
            return raccel;
        }

        public int Deceleration()
        {
            return rdecel;
        }


        public int Velocity()
        {
            return rvel;
        }

        public int Time()
        {
            return rtime;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolarBearsProgram
{
    public class Motor
    {
        string ip;
        int rotation_limit;
        int accel_limit;
        int velocity_limit;
        int decel_limit;
        String serial;

        public Motor(String IP, String serial, int Acceleration,int Deceleration, int Velocity)
        {
            this.ip = IP;
            //this.rotation_limit = Rotation;
            this.serial = serial;
            this.accel_limit = Acceleration;
            this.decel_limit = Deceleration;
            this.velocity_limit = Velocity;
            //this.decel_limit = Deceleration;
        }

        public string IP()
        {
            return ip;
        }

        public int Rotation_Limit()
        {
            return rotation_limit;
        }
        public int Acceleration_Limit()
        {
            return accel_limit;
        }
        public int Deceleration_Limit()
        {
            return decel_limit;
        }

        public int Velocity_Limit()
        {
            return velocity_limit;
        }

        public override string ToString()
        {
            return serial;
        }
    }
}


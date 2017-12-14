using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolarBearsProgram
{
    public class Motor
    {
       
        int rotation_limit;
        int accel_limit;
        int velocity_limit;
        int decel_limit;
        public string ip { get; set; }
        public int AccelLimit { get; set; }
        public int VelocityLimit { get; set; }
        public int DecelLimit { get; set; }
        public int RotationSoftLimit { get; set; }
        public int AccelSoftLimit { get; set; }
        public int DecelSoftLimit { get; set; }
        public int VelocitySoftLimit { get; set; }
        public String serial;

        public Motor(String ip, String Serial, int AccelLimit, int DecelLimit, int VelocityLimit,/* int RotationSoftLimit*/ int AccelSoftLimit, int DecelSoftLimit, int VelocitySoftLimit)
        {
            this.ip = ip;
            this.serial = Serial;
            this.AccelLimit = AccelLimit;
            this.DecelLimit = DecelLimit;
            this.VelocityLimit = VelocityLimit;
            this.RotationSoftLimit = RotationSoftLimit;
            this.AccelSoftLimit = AccelSoftLimit;
            this.DecelSoftLimit = DecelSoftLimit;
            this.VelocitySoftLimit = VelocitySoftLimit;
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


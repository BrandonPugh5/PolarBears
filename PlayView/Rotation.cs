using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolarBearsProgram
{
   public class Rotation
    {
        public int initialPosition;
        public int currentPosition;
        public int turnedDegrees = 0;
        public double degree;

        public Rotation(int position)
        {
            this.currentPosition = position;//tracks position of the motor
        }

        public double Degrees()
        {

            degree = ((currentPosition - initialPosition) / 2100) % 360; //2100 encoder counts per degree rotation
            
            turnedDegrees = (currentPosition - initialPosition) / 2100;
            return Math.Abs(degree);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PetrieDish
{
    public class Bacterium
    {
        public Point CurrentPoint { get; set; }
        public Double Speed { get; set; }
        public Point DirectionPoint { get; set; }
        public Int32 Counter { get; set; }
        private Random Randomizer { get; set; }
        private Int32 DirectionCounter { get; set; }

        public Bacterium(Point currPoint, Double speed)
        {
            CurrentPoint = currPoint;
            Speed = speed;
            Counter = 0;
            Randomizer = new Random(DateTime.Now.Millisecond);
            DirectionPoint = new Point(Randomizer.NextDouble(), Randomizer.NextDouble());
            DirectionCounter = Randomizer.Next(10, 40);
        }

        public void LifeCicle()
        {
            Vector direction = Point.Subtract(CurrentPoint, DirectionPoint);
            direction = Vector.Multiply(Speed / direction.Length, direction);
            CurrentPoint = Vector.Add(direction, CurrentPoint);
            Counter++;
            DirectionCounter--;
            if (DirectionCounter == 0)
            {
                DirectionPoint = new Point(Randomizer.NextDouble(), Randomizer.NextDouble());
                DirectionCounter = Randomizer.Next(10, 40);
            }
        }
    }
}

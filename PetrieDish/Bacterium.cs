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
        public Point CurrentPoint { get; private set; }
        public Double Speed { get; private set; }
        public Vector Direction { get; private set; }
        public Int32 Counter { get; private set; }
        private Random Randomizer { get; set; }
        private Int32 DirectionCounter { get; set; }
        private Dish Parent { get; set; }
        public Boolean IsDead { get { return LifeCounter == 0; } }
        private Int32 LifeCounter { get; set; }
        private Int32 DivisionCounter { get; set; }
        public Int32 Generation { get; private set; }

        public Bacterium(Point currPoint, Double speed, Dish parent)
        {
            CurrentPoint = currPoint;
            Speed = speed;
            Counter = 0;
            Parent = parent;
            Randomizer = new Random((Int32)DateTime.Now.Millisecond);
            System.Threading.Thread.Sleep(1);
            Direction = NewDirection();
            DirectionCounter = Randomizer.Next(10, 40);
            LifeCounter = Randomizer.Next(20, 25);
            DivisionCounter = Randomizer.Next(15, 25);
            Generation = 0;
        }

        public Bacterium(Bacterium parent)
            : this(parent.CurrentPoint, parent.Speed, parent.Parent)
        { Generation = parent.Generation++; }

        public void LifeCicle()
        {
            if (Parent.Validate(Vector.Add(Direction, CurrentPoint)))
            {
                CurrentPoint = Vector.Add(Direction, CurrentPoint);
                Counter++;
                DirectionCounter--;
                LifeCounter--;
                DivisionCounter--;
                if (DirectionCounter == 0)
                {
                    Direction = NewDirection();
                    DirectionCounter = Randomizer.Next(5, 20);
                }
                if (DivisionCounter == 0)
                {
                    DivisionCounter = Randomizer.Next(15, 25);
                    Bacterium child = new Bacterium(this);
                    Parent.AddNewBacterium(child);
                }
            }

            else
            {
                Direction = NewDirection();
                DirectionCounter = Randomizer.Next(5, 20);
                LifeCicle();
            }
        }

        private Vector NewDirection()
        {
            return new Vector(Randomizer.NextDouble() - 0.5, Randomizer.NextDouble() - 0.5);
        }
    }
}

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
        private static Random Randomizer { get; set; }
        private Int32 DirectionCounter { get; set; }
        private Dish Dish { get; set; }
        public Boolean IsDead { get { return LifeCounter == 0; } }
        private Int32 LifeCounter { get; set; }
        private Int32 DivisionCounter { get; set; }
        public Int32 Generation { get; private set; }

        public Bacterium(Point currPoint, Double speed, Dish dish)
        {
            CurrentPoint = currPoint;
            Speed = speed;
            Counter = 0;
            Dish = dish;

            if (Randomizer == null)
                Randomizer = new Random((Int32)DateTime.Now.Millisecond);

            //System.Threading.Thread.Sleep(1);
            Direction = NewDirection();
            DirectionCounter = GetDirectionCounter();
            LifeCounter = Randomizer.Next(50, 100);
            DivisionCounter = GetDivisionCounter();
            Generation = 0;
        }

        public Bacterium(Bacterium parent)
            : this(parent.CurrentPoint, parent.Speed, parent.Dish)
        { Generation = parent.Generation++; }

        public Int32 GetDivisionCounter() { return Randomizer.Next(20, 50); }
        public Int32 GetDirectionCounter() { return Randomizer.Next(50, 100); }

        public void LifeCicle()
        {
            for (Int32 i = 0; i < 10; i++)
            {
                if (Dish.Validate(Vector.Add(Direction, CurrentPoint), this))
                {
                    CurrentPoint = Vector.Add(Direction, CurrentPoint);
                    DivisionCounter--;

                    if (DivisionCounter == 0)
                    {
                        DivisionCounter = GetDivisionCounter();
                        Bacterium child = new Bacterium(this);
                        Dish.AddNewBacterium(child);
                        
                    }
                    break;
                }
                else
                {
                    Direction = NewDirection();
                    DirectionCounter = GetDirectionCounter();
                }
            }
            Counter++;
            DirectionCounter--;
            LifeCounter--;
            if (DirectionCounter == 0)
            {
                Direction = NewDirection();
                DirectionCounter = GetDirectionCounter();
            }
        }

        private Vector NewDirection()
        {
            return new Vector(Randomizer.NextDouble() - 0.5, Randomizer.NextDouble() - 0.5);
        }
    }
}

using System;

namespace DiceRollerClicker
{
    public class Die
    {
        public int Sides { get; set; }
        public int Roll()
        {
            return new Random().Next(1, Sides + 1);
        }
    }
}

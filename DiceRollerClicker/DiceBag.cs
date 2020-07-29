using System.Collections.Generic;

namespace DiceRollerClicker
{
    public class DiceBag
    {
        public Dictionary<int, int> Dice = new Dictionary<int, int>();
        public DiceBag()
        {
            Dice.Add(4, 0);
            Dice.Add(6, 0);
            Dice.Add(8, 0);
            Dice.Add(10, 0);
            Dice.Add(12, 0);
            Dice.Add(20, 0);
        }
        public void UpgradeDie(int sidesToUpgradeFrom, int sidesToUpgradeTo)
        {
            if (Dice[sidesToUpgradeFrom] > 0)
            {
                Dice[sidesToUpgradeFrom] -= 1;
                Dice[sidesToUpgradeTo] += 1;
            }
            else
            {
                throw new System.Exception("No die of that size to upgrade");
            }
        }
        public long Roll()
        {
            long total = 0;
            foreach (var key in Dice.Keys)
            {
                var count = Dice[key];
                if (count > 0)
                {
                    total += halvingRoll(0, count, new Die { Sides = key });
                }
            }
            return total;
        }
        private long halvingRoll(long runningTotal, int CountOfDie, Die die)
        {
            if (CountOfDie == 1)
            {
                runningTotal += die.Roll();
            }
            else
            {
                int half = CountOfDie / 2;
                CountOfDie = CountOfDie - half;
                runningTotal += (die.Roll() * half) + halvingRoll(runningTotal, CountOfDie, die);
            }
            return runningTotal;
        }
        //private long fibanachiRoll(long runningTotal, int CountOfDie, Die die)
        //{
        //    if (CountOfDie == 1)
        //    {
        //        runningTotal += die.Roll();
        //    }
        //    else
        //    {
        //        int fib = LargestFibanachiValueLessThanCount(CountOfDie);
        //        CountOfDie -= fib;
        //        runningTotal += (die.Roll() * fib) + fibanachiRoll(runningTotal, CountOfDie, die);
        //    }
        //    return runningTotal;
        //}
        //private int LargestFibanachiValueLessThanCount(int count)
        //{
        //    List<int> fibbanachiValues = new List<int>();
        //    fibbanachiValues.Add(1);
        //    fibbanachiValues.Add(1);
        //    while (fibbanachiValues[fibbanachiValues.Count - 1] < count)
        //    {
        //        fibbanachiValues.Add(fibbanachiValues[fibbanachiValues.Count - 1] + fibbanachiValues[fibbanachiValues.Count - 2]);
        //        fibbanachiValues.RemoveAt(0);
        //    }
        //    return fibbanachiValues[fibbanachiValues.Count - 2];
        //}
    }
}

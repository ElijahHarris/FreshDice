using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace DiceRollerClicker
{
    public class GameManager : INotifyPropertyChanged
    {
        public long Score {
            get { return score; }
            set
            {
                score = value;
                FieldChanged();
            }
        }
        private long score;
        public int GoblinCount {
            get { return goblinCount; }
            set {
                goblinCount = value;
                FieldChanged();
            } }
        public int goblinCount = 0;
        public int D4Count
        {
            get { return Dice[4]; }
            set { Dice[4] = value;
                FieldChanged();
            }
        }
        public int D6Count
        {
            get { return Dice[6]; }
            set
            {
                Dice[6] = value;
                FieldChanged();
            }
        }
        public int D8Count
        {
            get { return Dice[8]; }
            set
            {
                Dice[8] = value;
                FieldChanged();
            }
        }
        public int D10Count
        {
            get { return Dice[10]; }
            set
            {
                Dice[10] = value;
                FieldChanged();
            }
        }
        public int D12Count
        {
            get { return Dice[12]; }
            set
            {
                Dice[12] = value;
                FieldChanged();
            }
        }
        public int D20Count
        {
            get { return Dice[20]; }
            set
            {
                Dice[20] = value;
                FieldChanged();
            }
        }

        public readonly Dictionary<string, int> StoreItemCosts = new Dictionary<string, int>();
        public const int DefaultDieCost = 25;


        public GameManager()
        {
            StoreItemCosts.Add("Goblin", 1000);
            StoreItemCosts.Add("NewD4", 5 * DefaultDieCost);
            StoreItemCosts.Add("NewD6", 7 * DefaultDieCost);
            StoreItemCosts.Add("NewD8", 9 * DefaultDieCost);
            StoreItemCosts.Add("NewD10", 11 * DefaultDieCost);
            StoreItemCosts.Add("NewD12", 13 * DefaultDieCost);
            StoreItemCosts.Add("NewD20", 21 * DefaultDieCost);
            Dice.Add(4, 0);
            Dice.Add(6, 0);
            Dice.Add(8, 0);
            Dice.Add(10, 0);
            Dice.Add(12, 0);
            Dice.Add(20, 0);
            D4Count = 1;
            doGoblinClicks();
        }
        private async void doGoblinClicks()
        {
            do
            {
                if (GoblinCount > 0)
                {
                    int GoblinsYetToClick = GoblinCount;
                    for (int i = 0; i < (GoblinCount >= 50 ? 50 : GoblinCount); i++)
                    {
                        if (GoblinsYetToClick > 0)
                        {
                            int GoblinsToClickThisCheck = GoblinCount / (GoblinCount >= 50 ? 50 : GoblinCount) == 0 && GoblinsYetToClick > 0 ? 1 : GoblinCount / (GoblinCount >= 50 ? 50 : GoblinCount);
                            GoblinsToClickThisCheck = GoblinsToClickThisCheck <= GoblinsYetToClick ? GoblinsToClickThisCheck : GoblinsYetToClick;
                            for (int j = 0; j < GoblinsToClickThisCheck; j++)
                            {
                                Click();
                            }
                            GoblinsYetToClick -= GoblinsToClickThisCheck;
                        }
                        await Task.Delay(4000 / (GoblinCount >= 50 ? 50 : GoblinCount));
                    }
                }
                await Task.Delay(1);
            } while (true);
        }
        public Dictionary<int, int> Dice = new Dictionary<int, int>();
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
        public void Click()
        {
            Score += Roll();
        }
        public void BuyGoblin()
        {
            if (Score - StoreItemCosts["Goblin"] >= 0)
            {
                Score -= StoreItemCosts["Goblin"];
                GoblinCount++;
            }
        }
        public void BuyD4()
        {
            if (Score - StoreItemCosts["NewD4"] >= 0)
            {
                Score -= StoreItemCosts["NewD4"];
                D4Count = D4Count + 1;
            }
        }
        public void BuyD6()
        {
            if (Score - StoreItemCosts["NewD6"] >= 0)
            {
                Score -= StoreItemCosts["NewD6"];
                D6Count = D6Count + 1;
            }
        }
        public void BuyD8()
        {
            if (Score - StoreItemCosts["NewD8"] >= 0)
            {
                Score -= StoreItemCosts["NewD8"];
                D8Count = D8Count + 1;
            }
        }
        public void BuyD10()
        {
            if (Score - StoreItemCosts["NewD10"] >= 0)
            {
                Score -= StoreItemCosts["NewD10"];
                D10Count = D10Count + 1;
            }
        }
        public void BuyD12()
        {
            if (Score - StoreItemCosts["NewD12"] >= 0)
            {
                Score -= StoreItemCosts["NewD12"];
                D12Count = D12Count + 1;
            }
        }
        public void BuyD20()
        {
            if (Score - StoreItemCosts["NewD20"] >= 0)
            {
                Score -= StoreItemCosts["NewD20"];
                D20Count = D20Count + 1;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void FieldChanged([CallerMemberName] string field = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(field));
        }
    }
}

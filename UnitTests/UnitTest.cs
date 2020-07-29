using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        private DiceRollerClicker.GameManager gm = new DiceRollerClicker.GameManager();
        [TestMethod]
        public void TestScoreGoesUpCorrectlyOnRoll()
        {
            long minimumIncreaseInScore = 0;
            long maximumIncreaseInScore = 0;
            foreach (int sides in gm.DiceBag.Dice.Keys)
            {
                minimumIncreaseInScore += gm.DiceBag.Dice[sides];
                maximumIncreaseInScore += gm.DiceBag.Dice[sides] * sides;
            }
            for (int i = 0; i < 100; i++)
            {
                long OldScore = gm.Score;
                gm.Click();
                long Score = gm.Score;
                Assert.IsTrue(Score - OldScore >= minimumIncreaseInScore);
                Assert.IsTrue(Score - OldScore <= maximumIncreaseInScore);
            }
        }
        [TestMethod]
        public void TestD4Purchase()
        {
            int CurrentStoreAmount = gm.DiceBag.Dice[4];
            long CurrentScoreAmount = gm.Score;
            gm.BuyD4();
            Assert.AreEqual(CurrentStoreAmount + 1, gm.DiceBag.Dice[4]);
            Assert.AreEqual(CurrentScoreAmount - (DiceRollerClicker.GameManager.DefaultDieCost * 5), gm.Score);
        }
        [TestMethod]
        public void TestD6Purchase()
        {
            int CurrentStoreAmount = gm.DiceBag.Dice[6];
            long CurrentScoreAmount = gm.Score;
            gm.BuyD6();
            Assert.AreEqual(CurrentStoreAmount + 1, gm.DiceBag.Dice[6]);
            Assert.AreEqual(CurrentScoreAmount - (DiceRollerClicker.GameManager.DefaultDieCost * 7), gm.Score);
        }
        [TestMethod]
        public void TestD8Purchase()
        {
            int CurrentStoreAmount = gm.DiceBag.Dice[8];
            long CurrentScoreAmount = gm.Score;
            gm.BuyD8();
            Assert.AreEqual(CurrentStoreAmount + 1, gm.DiceBag.Dice[8]);
            Assert.AreEqual(CurrentScoreAmount - (DiceRollerClicker.GameManager.DefaultDieCost * 9), gm.Score);
        }
        [TestMethod]
        public void TestD10Purchase()
        {
            int CurrentStoreAmount = gm.DiceBag.Dice[10];
            long CurrentScoreAmount = gm.Score;
            gm.BuyD10();
            Assert.AreEqual(CurrentStoreAmount + 1, gm.DiceBag.Dice[10]);
            Assert.AreEqual(CurrentScoreAmount - (DiceRollerClicker.GameManager.DefaultDieCost * 11), gm.Score);
        }
        [TestMethod]
        public void TestD12Purchase()
        {
            int CurrentStoreAmount = gm.DiceBag.Dice[12];
            long CurrentScoreAmount = gm.Score;
            gm.BuyD12();
            Assert.AreEqual(CurrentStoreAmount + 1, gm.DiceBag.Dice[12]);
            Assert.AreEqual(CurrentScoreAmount - (DiceRollerClicker.GameManager.DefaultDieCost * 13), gm.Score);
        }
        [TestMethod]
        public void TestD20Purchase()
        {
            int CurrentStoreAmount = gm.DiceBag.Dice[20];
            long CurrentScoreAmount = gm.Score;
            gm.BuyD20();
            Assert.AreEqual(CurrentStoreAmount + 1, gm.DiceBag.Dice[20]);
            Assert.AreEqual(CurrentScoreAmount - (DiceRollerClicker.GameManager.DefaultDieCost * 21), gm.Score);
        }
        [TestMethod]
        public void TestGoblinPurchase()
        {
            int CurrentStoreAmount = gm.GoblinCount;
            long CurrentScoreAmount = gm.Score;
            gm.BuyGoblin();
            Assert.AreEqual(CurrentStoreAmount + 1, gm.GoblinCount);
            Assert.AreEqual(CurrentScoreAmount + (0), gm.Score);
        }
    }
}

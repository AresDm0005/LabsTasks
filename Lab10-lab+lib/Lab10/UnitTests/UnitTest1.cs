using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab10;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ComplexTestForConstrAndSort()
        {

            int expected = 0;
            
            IExecutable[] goods = {
                new Goods(),
                new MilkProduct(),
                new FoodProduct(),
                new Toys(),
            };

            Array.Sort(goods);

            Assert.AreEqual(expected, goods[3].TotalRevenue());
        }

        [TestMethod]
        public void TestForContructors2()
        {
            int expected = 0;

            IExecutable[] goods =
            {
                new Goods("Липтон", "Pepsi Co."),
                new Goods("Кола", "Coca-Cola Co.", 99, 33),
                new Toys("Ворона", "ВШЭ"),
                new Toys("ЛЕГО Сити", "Lego", 6, "конструктор"),
                new Toys("Монополия", "Hasbro", 800, 40, 3, "настольные игры"),
                new FoodProduct("Колбаса", "Кунгурский"),
                new FoodProduct("Йогурт", "Nestle", new DateTime(2020, 2, 25), 48),
                new FoodProduct("Хлеб", "Хлебокомбинат", -50, -10),
                new FoodProduct("Пирог", "Хлебокомбинат", 65, 40, new DateTime(), 72),
                new MilkProduct("Простоквашино", "Danone"),
                new MilkProduct("Домик в деревне", "Pepsi Co.", "молоко", 1.0),
                new MilkProduct("Нытвенский", "Нытвенский", 33, 33, "Кефир", 1.0),
                new MilkProduct("Домашний", "Ярмарка", 50, 90, new DateTime(2020, 2, 22), 72, "Творог", 0.5)
            };

            
            int actual = -1;
            foreach(IExecutable good in goods)
            {
                if (good.Title() == "Хлеб" && good.Manufacturer() == "Хлебокомбинат") actual = good.Price() + good.Quantity();
            }

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CloneAndGoodsResetFunc1Test()
        {
            string expected = "Carlin";

            Goods good = new Goods(expected, "F2");
            Goods cloned = (Goods)good.Clone();
            good.Rename("Hitech");

            Assert.AreEqual(expected, cloned.Title);           
        }

        [TestMethod]
        public void CompareTest()
        {
            int expected = 0;

            Goods good1 = new Goods("ENG", "RUS", 50, 90);
            Goods good2 = new Goods("RUS", "ENG", 100, 45);

            Assert.AreEqual(expected, good1.Compare(good1, good2));
        }

        [TestMethod]
        public void GoodsResetFunc2Test()
        {
            int expected = 15 * 30;

            Goods good = new Goods("UFO", "MilkyWay", 100, 20);
            good.NewPrice(15);
            good.DeliverMade(30);

            Assert.AreEqual(expected, good.TotalRevenue());
        }

        [TestMethod]
        public void ToysTest()
        {
            bool expected = false;

            Toys toy = new Toys("UFO", "WWA", 15, 15, -1, "IMF");
            bool actual = toy.AgeRestriction > 0 && toy.Type == "IMF" && toy.Type != "";
            
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FoodTest()
        {
            bool expected = true;

            FoodProduct food = new FoodProduct("FOM", "UN", 10, 10, (new DateTime(2020, 2, 22)), 48);
            FoodProduct food1 = new FoodProduct("FOM", "UN", 10, 10, (new DateTime(2020, 2, 20)), -118);

            bool actual = food.Manufactured + (new TimeSpan(food.StorageLife, 0, 0)) > new DateTime(2020, 2, 23) && food1.StorageLife == 0;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MilkTest()
        {
            bool expected = true;

            MilkProduct milk = new MilkProduct("WWF", "CIS", 50, 1000, new DateTime(2020, 2, 22), 72, "молоко", 1.5);
            MilkProduct milk1 = new MilkProduct("EU", "UNES", 1000, 10, new DateTime(2020, 2, 22), 60, "кефир", -1);

            bool actual = (milk1.Type == "кефир" || milk1.Type == "молоко") && milk.Weight > 1.0;

            Assert.AreEqual(expected, actual);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static CoffeeHouse3ISP914.Windows.CartWindow;

namespace PriceWithDiscountTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void price420disc004fcost40320()
        {
            //Aarange
            decimal price = 420;
            decimal disc = (decimal)0.04;
            decimal cost = (decimal)403.20;

            //Act
            decimal res = CoffeeHouse3ISP914.ClassHelper.CalculatingDiscount.Discount((decimal)price, (decimal)disc);

            //Assert
            Assert.AreEqual(cost, res);
        }

        [TestMethod]
        public void price420disc004fcost40420()
        {
            //Aarange
            decimal price = 420;
            decimal disc = (decimal)0.04;
            decimal cost = (decimal)404.20;

            //Act
            decimal res = CoffeeHouse3ISP914.ClassHelper.CalculatingDiscount.Discount((decimal)price, (decimal)disc);

            //Assert
            Assert.AreEqual(cost, res);
        }

        [TestMethod]
        public void priceWdisc005fcost399()
        {
            //Aarange
            decimal price = 420;
            decimal disc = (decimal)0.05;
            decimal cost = (decimal)399;

            //Act
            decimal res = CoffeeHouse3ISP914.ClassHelper.CalculatingDiscount.Discount((decimal)price, (decimal)disc);

            //Assert
            Assert.AreEqual(cost, res);
        }

        [TestMethod]
        public void price840disc017fcost6972int()
        {
            //Aarange
            int price = 840;
            decimal disc = (decimal)0.17;
            decimal cost = (decimal)697.20;

            //Act
            decimal res = CoffeeHouse3ISP914.ClassHelper.CalculatingDiscount.Discount((decimal)price, (decimal)disc);

            //Assert
            Assert.AreEqual(cost, res);
        }

        [TestMethod]
        public void price5470disc017fcost6972int()
        {
            //Aarange
            int price = 5470;
            decimal disc = (decimal)0.17;
            decimal cost = (decimal)697.20;

            //Act
            decimal res = CoffeeHouse3ISP914.ClassHelper.CalculatingDiscount.Discount((decimal)price, (decimal)disc);

            //Assert
            Assert.AreEqual(cost, res);
        }

        [TestMethod]
        public void price540disc017fcost6972int()
        {
            //Aarange
            int price = 540;
            decimal disc = (decimal)0.17;
            decimal cost = (decimal)697.20;

            //Act
            decimal res = CoffeeHouse3ISP914.ClassHelper.CalculatingDiscount.Discount((decimal)price, (decimal)disc);

            //Assert
            Assert.AreEqual(cost, res);
        }

        [TestMethod]
        public void price540disc017fcost4482int()
        {
            //Aarange
            int price = 540;
            decimal disc = (decimal)0.17;
            decimal cost = (decimal)448.20;

            //Act
            decimal res = CoffeeHouse3ISP914.ClassHelper.CalculatingDiscount.Discount((decimal)price, (decimal)disc);

            //Assert
            Assert.AreEqual(cost, res);
        }

        [TestMethod]
        public void price5890disc097fcost4482int()
        {
            //Aarange
            int price = 5890;
            decimal disc = (decimal)0.97;
            decimal cost = (decimal)448.20;

            //Act
            decimal res = CoffeeHouse3ISP914.ClassHelper.CalculatingDiscount.Discount((decimal)price, (decimal)disc);

            //Assert
            Assert.AreEqual(cost, res);
        }
        [TestMethod]
        public void price5890disc097fcost17670int()
        {
            //Aarange
            int price = 5890;
            decimal disc = (decimal)0.97;
            decimal cost = (decimal)176.70;

            //Act
            decimal res = CoffeeHouse3ISP914.ClassHelper.CalculatingDiscount.Discount((decimal)price, (decimal)disc);

            //Assert
            Assert.AreEqual(cost, res);
        }
        [TestMethod]
        public void price10000disc023fcost7700int()
        {
            //Aarange
            int price = 10000;
            decimal disc = (decimal)0.23;
            decimal cost = (decimal)7700.00;

            //Act
            decimal res = CoffeeHouse3ISP914.ClassHelper.CalculatingDiscount.Discount((decimal)price, (decimal)disc);

            //Assert
            Assert.AreEqual(cost, res);
        }
    }
}

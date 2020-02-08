using Lab9;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            Time expected = new Time(0, 29);

            // Act
            Time t1 = new Time(5, 3);
            Time t2 = new Time(4, 34);
            Time actual = t1.DeductTime(t2);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod2()
        {
            // Arrange
            Time expected = new Time(0, 0);

            // Act
            Time t1 = new Time(3, 12);
            Time t2 = new Time(5, 80);

            Time actual = Time.DeductTime(t1, t2);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod3()
        {
            // Arrange 
            Time expected = new Time(0, 20);

            // Act
            Time actual = new Time(-1, 80);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod4()
        {
            // Arrange 
            Time expected = new Time(5, 0);

            // Act
            Time actual = new Time(5, 0);
            actual--;
            actual++;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod5()
        {
            // Arrange 
            Time expected = new Time(0, 1);

            // Act
            Time t1 = new Time(0, 0);
            Time actual;

            if ((bool)t1) actual = t1;
            else actual = new Time(0, 1);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod6()
        {
            // Arrange
            Time expected = new Time(0,0);

            // Act
            TimeArray array = new TimeArray(10);
            array[0] = new Time(0, 0);

            Time min = array[0];
            for (int i = 0; i < array.Length; i++) if (array[i] < min) min = array[i];

            // Assert
            Assert.AreEqual(expected, min);
        }

        [TestMethod]
        public void TestMethod7()
        {
            // Arrange
            Time expected = new Time(16, 30);

            // Act
            Time[] tmp = new Time[]
            {
                new Time(0, 5),
                new Time(3, 19),
                new Time(10, 14),
                expected,
                new Time(9, 49)
            };

            TimeArray array = new TimeArray(5, tmp);

            Time actual = array.MaxValue();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod8()
        {
            // Arrange
            bool expected = false;

            // Act
            TimeArray array = new TimeArray();
            bool actual;
            try
            {
                array[0] = new Time();
                actual = true;
            }
            catch (IndexOutOfRangeException)
            {
                actual = false;
            }
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod9()
        {
            // Arrange
            bool expected = false;

            // Act
            TimeArray array = new TimeArray(3);
            bool actual;
            try
            {
                Time time = array[3];
                time.Show();
                actual = true;
            }
            catch (IndexOutOfRangeException)
            {
                actual = false;
            }
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod10()
        {
            // Arrange
            bool expected = false;

            // Act
            TimeArray array = new TimeArray();

            bool actual;
            try
            {
                Time time = array[0];
                time.Show();
                actual = true;
            }
            catch (IndexOutOfRangeException)
            {
                actual = false;
            }
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod11()
        {
            // Arrange
            bool expected = false;

            // Act
            TimeArray array = new TimeArray(5);

            bool actual;
            try
            {
                array[5] = new Time();
                actual = true;
            }
            catch (IndexOutOfRangeException)
            {
                actual = false;
            }
            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}

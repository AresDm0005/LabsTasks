using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Lab11;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CapacityTest()
        {
            int expected = 23;

            MyDictionary<int, string> dict = new MyDictionary<int, string>(20);

            Assert.AreEqual(expected, dict.Capacity);
        }
        
        [TestMethod]
        public void ContainsKeyTest()
        {
            bool exp = false;

            MyDictionary<int, string> dict = new MyDictionary<int, string>();
            dict.Add(1, "Один");
            dict.Add(2, "Два");
            dict.Add(3, "Три");
            dict.Add(4, "Четыре");
            dict.Add(5, "Пять");

            bool act = dict.ContainsKey(0);
            Assert.AreEqual(exp, act);
        }

        [TestMethod]
        public void ContainsValueTest()
        {
            bool exp = true;

            MyDictionary<int, string> dict = new MyDictionary<int, string>();
            dict.Add(1, "Один");
            dict.Add(2, "Два");
            dict.Add(3, "Три");
            dict.Add(4, "Четыре");
            dict.Add(5, "Пять");

            bool act = dict.ContainsValue("Три");
            Assert.AreEqual(exp, act);
        }

        [TestMethod]
        public void ContainsTest()
        {
            bool exp = true;

            MyDictionary<int, string> dict = new MyDictionary<int, string>();
            dict.Add(1, "Один");
            dict.Add(2, "Два");
            dict.Add(3, "Три");
            dict.Add(4, "Четыре");
            dict.Add(5, "Пять");

            bool act = dict.Contains(new KeyValuePair<int, string> (1, "Один"));
            Assert.AreEqual(exp, act);
        }

        [TestMethod]
        public void RemoveTest()
        {
            int exp = 5;

            MyDictionary<int, string> dict = new MyDictionary<int, string>();
            dict.Add(1, "Один");
            dict.Add(2, "Два");
            dict.Add(3, "Три");
            dict.Add(-1, "Один");
            dict.Add(4, "Четыре");
            dict.Add(5, "Пять");

            dict.Remove(-1);
            
            Assert.AreEqual(exp, dict.Count);
        }

        [TestMethod]
        public void IndexerTest1()
        {
            string exp = "Раз";

            MyDictionary<int, string> dict = new MyDictionary<int, string>();
            dict.Add(1, "Один");
            dict.Add(2, "Два");
            dict.Add(3, "Три");
            dict.Add(4, "Четыре");
            dict.Add(5, "Пять");

            dict[1] = "Раз";
            string act = dict[1];

            Assert.AreEqual(exp, act);
        }

        [TestMethod]
        public void IndexerTest2()
        {
            int exp = -1;

            MyDictionary<int, string> dict = new MyDictionary<int, string>();
            dict.Add(1, "Один");
            dict.Add(2, "Два");
            dict.Add(3, "Три");
            dict.Add(4, "Четыре");
            dict.Add(5, "Пять");

            int act;
            try
            {
                if(dict[100] == "Сто")
                {
                    act = 100;
                }
                act = 1;
            }
            catch
            {
                act = -1;
            }

            Assert.AreEqual(exp, act);
        }

        [TestMethod]
        public void ConstructorByColl()
        {
            string exp = "Пять";

            MyDictionary<int, string> dict = new MyDictionary<int, string>();
            dict.Add(1, "Один");
            dict.Add(2, "Два");
            dict.Add(3, "Три");
            dict.Add(4, "Четыре");
            dict.Add(5, "Пять");

            MyDictionary<int, string> alph = new MyDictionary<int, string>(dict);
            string act = alph[5];

            Assert.AreEqual(exp, act);
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab12;
using GoodsTypes;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        #region OneWayList
        [TestMethod]
        public void OneAddLast()
        {
            int expect = 1004;

            OneWayList list = new OneWayList();

            list.AddLast(new Goods("Панель", "Управления", 10, 100));
            list.AddLast(new Goods("Панель", "Солнечная", 50, 1000));
            list.AddLast(new Goods("Панель", "Инструментов", 1000, 100));
            list.AddLast(new Goods("Панель", "Газовая", 300, 100));

            int actual = list.PriceOf(2) + list.Count;
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void OneAddFirst()
        {
            int expect = 50;

            OneWayList list = new OneWayList();

            list.AddFirst(new Goods("Панель", "Управления", 10, 100));
            list.AddFirst(new Goods("Панель", "Солнечная", 50, 1000));
            list.AddFirst(new Goods("Панель", "Инструментов", 1000, 100));
            list.AddFirst(new Goods("Панель", "Газовая", 300, 100));

            int actual = list.PriceOf(2);
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void OneAddAt()
        {
            int expect = 10;

            OneWayList list = new OneWayList();

            list.AddAt(0, new Goods("Панель", "Управления", 10, 100)); // 2
            list.AddAt(1, new Goods("Панель", "Солнечная", 50, 1000)); // 3
            list.AddAt(0, new Goods("Панель", "Инструментов", 1000, 100)); // 0
            list.AddAt(1, new Goods("Панель", "Газовая", 300, 100)); // 1

            int actual = list.PriceOf(2);
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void OneAddAtExceptions()
        {
            bool expect = true;
            bool f1, f2;

            OneWayList list = new OneWayList();

            try
            {
                list.AddAt(1, new Goods("Панель", "Управления", 10, 100));
                f1 = false;
            }
            catch (ArgumentOutOfRangeException e)
            {
                f1 = true;
            }

            list.AddAt(0, new Goods("Панель", "Инструментов", 1000, 100)); // 0

            try
            {
                list.AddAt(-1, new Goods("Панель", "Управления", 10, 100));
                f2 = false;
            }
            catch (ArgumentOutOfRangeException e)
            {
                f2 = true;
            }

            list.AddAt(1, new Goods("Панель", "Солнечная", 50, 1000));

            bool actual = f1 && f2 && (list.PriceOf(1) == 50);
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void OneRemove()
        {
            OneWayList list = new OneWayList();

            list.AddLast(new Goods("Панель", "Управления", 10, 100));
            list.AddLast(new Goods("Панель", "Солнечная", 50, 1000));
            list.AddLast(new Goods("Карта", "Мира", 300, 100));
            list.AddLast(new Goods("Карта", "РФ", 30, 100));
            list.AddLast(new Goods("Панель", "Инструментов", 1000, 100));
            list.AddLast(new Goods("Карта", "Политическая", 600, 100));
            list.AddLast(new Goods("Карта", "Физическая", 700, 100));
            list.AddLast(new Goods("Панель", "Газовая", 300, 100));

            int exp = list.Count - 2;
            list.Remove(new Goods("Панель", "Солнечная", 50, 1000));
            list.Remove(new Goods("Карта", "Физическая", 700, 100));
            
            int act = list.Count;
            Assert.AreEqual(exp, act);
        }

        [TestMethod]
        public void OneExp()
        {
            bool exp = false;
            bool[] act = new bool[3];

            OneWayList list = new OneWayList();

            try { list.Remove(null); act[0] = true; }
            catch { act[0] = false; }

            try { list.RemoveAt(-1); act[1] = true; }
            catch { act[1] = false; }

            try { list.RemoveAt(5); act[2] = true; }
            catch { act[2] = false; }

            bool actual = act[0] || act[1] || act[2];
            Assert.AreEqual(exp, actual);
        }

        [TestMethod]
        public void OneRemoveAt()
        {
            OneWayList list = new OneWayList();

            list.AddLast(new Goods("Панель", "Управления", 10, 100));
            list.AddLast(new Goods("Панель", "Солнечная", 50, 1000));
            list.AddLast(new Goods("Карта", "Мира", 300, 100));
            list.AddLast(new Goods("Карта", "РФ", 30, 100));
            list.AddLast(new Goods("Панель", "Инструментов", 1000, 100));
            list.AddLast(new Goods("Карта", "Политическая", 600, 100));
            list.AddLast(new Goods("Карта", "Физическая", 700, 100));
            list.AddLast(new Goods("Панель", "Газовая", 300, 100));

            int exp = list.Count - 3;
            list.RemoveAt(1);
            list.RemoveAt(5);
            list.RemoveAt(2);

            int act = list.Count;
            Assert.AreEqual(exp, act);
        }

        [TestMethod]
        public void OneClear()
        {
            bool exp = true;

            OneWayList list = new OneWayList();

            list.AddLast(new Goods("Панель", "Управления", 10, 100));
            list.AddLast(new Goods("Панель", "Солнечная", 50, 1000));
            list.AddLast(new Goods("Карта", "Мира", 300, 100));
            list.AddLast(new Goods("Карта", "РФ", 30, 100));
            list.AddLast(new Goods("Панель", "Инструментов", 1000, 100));
            list.AddLast(new Goods("Карта", "Политическая", 600, 100));
            list.AddLast(new Goods("Карта", "Физическая", 700, 100));
            list.AddLast(new Goods("Панель", "Газовая", 300, 100));
            long e = GC.GetTotalMemory(false);
            list.DeleteList();

            bool act = (GC.GetTotalMemory(true) < e);
            Assert.AreEqual(exp, act);
        }
        #endregion

        #region TwoWayList
        [TestMethod]
        public void TwoAddLast()
        {
            int expect = 1004;

            TwoWayList list = new TwoWayList();

            list.AddLast(new Goods("Панель", "Управления", 10, 100));
            list.AddLast(new Goods("Панель", "Солнечная", 50, 1000));
            list.AddLast(new Goods("Панель", "Инструментов", 1000, 100));
            list.AddLast(new Goods("Панель", "Газовая", 300, 100));

            int actual = list.PriceOf(2) + list.Count;
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void TwoAddFirst()
        {
            int expect = 50;

            TwoWayList list = new TwoWayList();

            list.AddFirst(new Goods("Панель", "Управления", 10, 100));
            list.AddFirst(new Goods("Панель", "Солнечная", 50, 1000));
            list.AddFirst(new Goods("Панель", "Инструментов", 1000, 100));
            list.AddFirst(new Goods("Панель", "Газовая", 300, 100));

            int actual = list.PriceOf(2);
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void TwoAddAt()
        {
            int expect = 50;

            TwoWayList list = new TwoWayList();

            list.AddAt(0, new Goods("Панель", "Управления", 10, 100)); // 2
            list.AddAt(1, new Goods("Панель", "Солнечная", 50, 1000)); // 3
            list.AddAt(0, new Goods("Панель", "Инструментов", 1000, 100)); // 0
            list.AddAt(1, new Goods("Панель", "Газовая", 300, 100)); // 1

            int actual = list.PriceOf(2);
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void TwoAddAtExceptions()
        {
            bool expect = true;
            bool f1, f2;

            TwoWayList list = new TwoWayList();

            try
            {
                list.AddAt(1, new Goods("Панель", "Управления", 10, 100));
                f1 = false;
            }
            catch (ArgumentOutOfRangeException e)
            {
                f1 = true;
            }

            list.AddAt(0, new Goods("Панель", "Инструментов", 1000, 100)); // 0

            try
            {
                list.AddAt(-1, new Goods("Панель", "Управления", 10, 100));
                f2 = false;
            }
            catch (ArgumentOutOfRangeException e)
            {
                f2 = true;
            }

            list.AddAt(1, new Goods("Панель", "Солнечная", 50, 1000));

            bool actual = f1 && f2 && (list.PriceOf(1) == 50);
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void TwoRemove()
        {
            TwoWayList list = new TwoWayList();

            list.AddLast(new Goods("Панель", "Управления", 10, 100));
            list.AddLast(new Goods("Панель", "Солнечная", 50, 1000));
            list.AddLast(new Goods("Карта", "Мира", 300, 100));
            list.AddLast(new Goods("Карта", "РФ", 30, 100));
            list.AddLast(new Goods("Панель", "Инструментов", 1000, 100));
            list.AddLast(new Goods("Карта", "Политическая", 600, 100));
            list.AddLast(new Goods("Карта", "Физическая", 700, 100));
            list.AddLast(new Goods("Панель", "Газовая", 300, 100));

            int exp = list.Count - 2;
            list.Remove(new Goods("Панель", "Солнечная", 50, 1000));
            list.Remove(new Goods("Карта", "Физическая", 700, 100));

            int act = list.Count;
            Assert.AreEqual(exp, act);
        }

        [TestMethod]
        public void TwoExp()
        {
            bool exp = false;
            bool[] act = new bool[3];

            TwoWayList list = new TwoWayList();

            try { list.Remove(null); act[0] = true; }
            catch { act[0] = false; }

            try { list.RemoveAt(-1); act[1] = true; }
            catch { act[1] = false; }

            try { list.RemoveAt(5); act[2] = true; }
            catch { act[2] = false; }

            bool actual = act[0] || act[1] || act[2];
            Assert.AreEqual(exp, actual);
        }

        [TestMethod]
        public void TwoRemoveAt()
        {
            TwoWayList list = new TwoWayList();

            list.AddLast(new Goods("Панель", "Управления", 10, 100));
            list.AddLast(new Goods("Панель", "Солнечная", 50, 1000));
            list.AddLast(new Goods("Карта", "Мира", 300, 100));
            list.AddLast(new Goods("Карта", "РФ", 30, 100));
            list.AddLast(new Goods("Панель", "Инструментов", 1000, 100));
            list.AddLast(new Goods("Карта", "Политическая", 600, 100));
            list.AddLast(new Goods("Карта", "Физическая", 700, 100));
            list.AddLast(new Goods("Панель", "Газовая", 300, 100));

            int exp = list.Count - 3;
            list.RemoveAt(1);
            list.RemoveAt(5);
            list.RemoveAt(2);

            int act = list.Count;
            Assert.AreEqual(exp, act);
        }

        [TestMethod]
        public void TwoClear()
        {
            bool exp = true;

            TwoWayList list = new TwoWayList();

            list.AddLast(new Goods("Панель", "Управления", 10, 100));
            list.AddLast(new Goods("Панель", "Солнечная", 50, 1000));
            list.AddLast(new Goods("Карта", "Мира", 300, 100));
            list.AddLast(new Goods("Карта", "РФ", 30, 100));
            list.AddLast(new Goods("Панель", "Инструментов", 1000, 100));
            list.AddLast(new Goods("Карта", "Политическая", 600, 100));
            list.AddLast(new Goods("Карта", "Физическая", 700, 100));
            list.AddLast(new Goods("Панель", "Газовая", 300, 100));
            long e = GC.GetTotalMemory(false);
            list.DeleteList();

            bool act = (GC.GetTotalMemory(true) < e);
            Assert.AreEqual(exp, act);
        }
        #endregion

        #region Binary

        [TestMethod]
        public void Binary()
        {
            bool exp = true;
            BinaryTree tree = new BinaryTree(10);

            tree.TurnSearchTree();
            long e = GC.GetTotalMemory(false);

            tree.ClearMemory();
            bool act = GC.GetTotalMemory(true) < e;
            Assert.AreEqual(exp, act);
        }
        #endregion

        #region Queue
        [TestMethod]
        public void QueueEmpt()
        {
            int exp = 99;
            int act = 0;

            MyQueue<Goods> queue = new MyQueue<Goods>();

            queue.Enqueue(new Goods("Калька", "Завод", 10, 150));
            queue.Enqueue(new Goods("Щука", "Лодка", 50, 100));
            queue.Enqueue(new Goods("Сельдь", "Лодка", 35, 50));

            act = queue.Capacity;
            foreach (Goods good in queue)
                act += good.Price;

            Assert.AreEqual(exp, act);
        }

        [TestMethod]
        public void QueueCapac()
        {
            int exp = 1000 + 15 + 2100;
            int act = 0;

            MyQueue<Goods> queue;
            try { queue = new MyQueue<Goods>(-10); }
            catch { queue = null; }

            act += (queue == null) ? 1000 : 0;
            queue = new MyQueue<Goods>(10);

            queue.Enqueue(new Goods("Томаты", "Овощебаза 1", 90, 100));
            queue.Enqueue(new Goods("Огурцы", "Овощебаза 1", 50, 200));
            queue.Enqueue(new Goods("Помидоры", "Овощебаза 2", 80, 300));
            queue.Enqueue(new Goods("Перец", "Овощебаза 1", 70, 400));
            queue.Enqueue(new Goods("Картофель", "Овощебаза 2", 60, 500));
            queue.Enqueue(new Goods("Свекла", "Овощебаза 2", 100, 600));

            while (queue.Count > 0)
            {
                Goods good = queue.Dequeue();
                act += good.Quantity + queue.Count;
            }

            Assert.AreEqual(exp, act);
        }

        [TestMethod]
        public void QueueClone()
        {
            bool exp = false;

            MyQueue<Goods> queue = new MyQueue<Goods>();

            queue.Enqueue(new Goods("Томаты", "Овощебаза 1", 90, 100));
            queue.Enqueue(new Goods("Огурцы", "Овощебаза 1", 50, 200));
            queue.Enqueue(new Goods("Помидоры", "Овощебаза 2", 80, 300));
            queue.Enqueue(new Goods("Перец", "Овощебаза 1", 70, 400));

            MyQueue<Goods> clone = (MyQueue<Goods>)queue.Clone();

            queue.Dequeue();
            queue.Dequeue();

            bool act = clone.Peek().Equals(queue.Peek());

            Assert.AreEqual(exp, act);
        }

        [TestMethod]
        public void QueueContains()
        {
            int exp = 1;
            int act = 0;

            MyQueue<Goods> queue = new MyQueue<Goods>();

            queue.Enqueue(new Goods("Томаты", "Овощебаза 1", 90, 100));
            queue.Enqueue(new Goods("Огурцы", "Овощебаза 1", 50, 200));
            queue.Enqueue(new Goods("Помидоры", "Овощебаза 2", 80, 300));
            queue.Enqueue(new Goods("Перец", "Овощебаза 1", 70, 400));

            MyQueue<Goods> goods = queue.SurfaceClone();

            act += goods.Contains(new Goods("Огурцы", "Овощебаза 1", 50, 200)) ? 1 : 0;
            act += goods.Contains(new Goods("Огурцы", "Овощебаза 2", 50, 200)) ? 1 : 0;

            Assert.AreEqual(exp, act);
        }

        [TestMethod]
        public void QueueExp()
        {
            bool exp = false;
            bool[] act = new bool[3];

            MyQueue<Goods> gueue = new MyQueue<Goods>();

            try { gueue.Dequeue(); act[0] = true; }
            catch { act[0] = false; }

            try { gueue.Peek(); act[1] = true; }
            catch { act[1] = false; }

            try { gueue.Contains(null); act[2] = true; }
            catch { act[2] = false; }

            bool actual = act[0] || act[1] || act[2];
            Assert.AreEqual(exp, actual);
        }

        [TestMethod]
        public void QueueClear()
        {
            bool exp = true;
            
            MyQueue<Goods> queue = new MyQueue<Goods>();
            queue.Enqueue(new Goods("Томаты", "Овощебаза 1", 90, 100));
            queue.Enqueue(new Goods("Огурцы", "Овощебаза 1", 50, 200));
            queue.Enqueue(new Goods("Помидоры", "Овощебаза 2", 80, 300));
            queue.Enqueue(new Goods("Перец", "Овощебаза 1", 70, 400));
            queue.Enqueue(new Goods("Репа", "Овощебаза 3", 65, 450));
            queue.Enqueue(new Goods("Морковь", "Овощебаза 5", 95, 440));
            long e = GC.GetTotalMemory(false);
            queue.Clean();

            bool act = (GC.GetTotalMemory(true) < e);
            Assert.AreEqual(exp, act);
        }
        #endregion
    }
}

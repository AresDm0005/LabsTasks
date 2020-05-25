using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoodsTypes;

namespace Lab13
{
    class Program
    {
        static void MyCollectionShow()
        {
            MyCollection goods = new MyCollection(5);

            Console.WriteLine("Инициализированная коллекция из 5 эл.:\n {0} Length = {1}\n", goods, goods.Length);
            Console.WriteLine();

            goods.AddDefault();
            goods.AddDefault();
            goods.AddDefault();

            goods.Add(new MilkProduct("Кефир", "Ручное добавление", 10, 15, "Кефир", 1.0));
            goods.Add(new Toys("Монополия", "Ручное добавление", 10, 15, 3, "Настолка"));

            goods.Sort(SortByProperty.Price);
            Console.WriteLine("Добавлено 5 эл. (3 случ., 2 ручн.)\nСортировка по ценам:\n {0}", goods);

            goods.Sort(SortByProperty.Title);
            Console.WriteLine("Сортировка по названиям:\n {0}", goods);

            goods.Remove(2);
            goods.Remove(5);
            Console.WriteLine("Удалено 2 элемента - 3ий,5ый:\n {0}", goods);

            goods.Clear();
            Console.WriteLine("Коллекция после очистки:\n {0}", goods);
        }

        static void JournalCheckShow()
        {
            MyNewCollection goods = new MyNewCollection(10);
            MyNewCollection items = new MyNewCollection(10);

            Console.WriteLine($"MyNewCollection #1\n{goods}\n\n");
            Console.WriteLine($"MyNewCollection #2\n{items}\n\n");

            Journal goodsJour = new Journal();
            Journal referJour = new Journal();

            goods.CollectionCountChanged += new CollectionHandler(goodsJour.CollectionCountChanged);
            goods.CollectionReferenceChanged += new CollectionHandler(goodsJour.CollectionReferenceChanged);

            goods.CollectionReferenceChanged += new CollectionHandler(referJour.CollectionReferenceChanged);
            items.CollectionReferenceChanged += new CollectionHandler(referJour.CollectionReferenceChanged);

            

            for (int i = 0; i < 5; i++)
                goods.AddDefault();

            for (int i = 0; i < 8; i++)
                items.AddDefault();

            
            goods[5] = new Goods("Каски", "Лысьва", 10, 10);
            goods[7] = new Goods("Маски", "Ткацкая", 222, 50);
            goods[1] = new Goods("Игра", "Той", 100, 77);

            items[4] = new Goods("Молоко", "Вимм-билль-данн", 400, 20);
            items[0] = new Goods("Кефир", "Простоквашино", 10, 200);

            
            goods.Remove(6);
            goods.Remove(1);
            goods.Remove(0);
            goods.Remove(4);

            items.Remove(3);
            items.Remove(3);

            Console.WriteLine("Журнал 1:\n" + goodsJour + "\n");
            Console.WriteLine("Журнал 2:\n" + referJour + "\n");
        }

        static void Main(string[] args)
        {
            MyCollectionShow();
            //JournalCheck();
        }
    }
}

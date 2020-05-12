using System;
using System.Collections;

namespace GoodsTypes
{ 
    public class DescendingSortByRevenue : IComparer
    {
        int IComparer.Compare(object obj1, object obj2)
        {
            Goods good1 = (Goods)obj1;
            Goods good2 = (Goods)obj2;
            return good2.TotalRevenue() - good1.TotalRevenue();
        }
    }

    public class AscendingSortBeyRevenue : IComparer
    {
        int IComparer.Compare(object obj1, object obj2)
        {
            Goods good1 = (Goods)obj1;
            Goods good2 = (Goods)obj2;
            return good1.TotalRevenue() - good2.TotalRevenue();
        }
    }

    public class Goods : ICloneable, IComparable
    {
        #region Значения для рандома
        private static string[] titles = { "Огурцы", "Томаты", "Салат", "Перец", "Ягоды", "Колбаса", "Сосиски",
            "Сервелат", "Тушенка", "Консервы", "Яйца", "Пельмени", "Селёдка", "Треска", "Кетчуп",
            "Майонез", "Сок", "Напиток", "Масло", "Соус", "Сыр", "Носки", "Ткань", "Костюмы", "Зонты",
            "Книга", "Документы", "Медвежонок", "Мишки", "Кот", "Кукла", "Монополия", "Дженга", "Робот",
            "Цивилизация", "Европа", "Майнкрафт", "Приставка"};
        private static string[] manufs = { "Овощебаза", "Колхоз #1", "Мясокомбинат", "Птицеферма", "Рыбкино",
            "Рикко", "Красавчик", "Молочка", "Нытва", "Кунгур",  "Ателье", "Санта", "Мастерская", "Типография", 
            "МФЦ", "Hasbro", "Firaxis", "Mojang", "Сони", "Игрушечная"};
        #endregion

        protected int price;
        protected int quantity;
        protected string manufacturer;
        protected string title;

        public int Price
        {
            get { return price; }
            protected set
            {
                if (value < 0) price = 0;
                else price = value;
            }
        }

        public int Quantity
        {
            get { return quantity; }
            protected set
            {
                if (value < 0) quantity = 0;
                else quantity = value;
            }
        }

        public string Manufacturer
        {
            get { return manufacturer; }
            protected set { manufacturer = value; }
        }

        public string Title
        {
            get { return title; }
            protected set { title = value; }
        }

        public Goods()
        {
            Title = "Не установлено";
            Manufacturer = "Не установлено";
            Price = 0;
            Quantity = 0;
        }

        public Goods(Random rand)
        {
            Title = titles[rand.Next(titles.Length)];
            Manufacturer = manufs[rand.Next(manufs.Length)];
            Price = rand.Next(20, 1501);
            Quantity = rand.Next(3, 50) * 150;
        }

        public Goods(string title, string manuf)
        {
            Title = title;
            Manufacturer = manuf;
            Price = 0;
            Quantity = 0;
        }

        public Goods(string title, string manuf, int price, int quantity)
        {
            Title = title;
            Manufacturer = manuf;
            Price = price;
            Quantity = quantity;
        }

        public void Rename(string rename)
        {
            Title = rename;
        }

        public void NewPrice(int price)
        {
            Price = price;
        }

        public void DeliverMade(int quantity)
        {
            Quantity = quantity;
        }

        public int TotalRevenue()
        {
            return Price * Quantity;
        }

        public virtual void Show()
        {
            Console.WriteLine($"Товар:\n" +
                $"Название: {Title}, производитель: {Manufacturer}\n" +
                $"Стоимость: {Price}р., Количество на складе: {Quantity} шт.\n");
        }
        
        public override string ToString()
        {
            return $"Товар: {Title}, {Manufacturer}, {Price}р., {Quantity} ед.";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !GetType().Equals(obj.GetType())) return false;

            Goods good = (Goods)obj;
            return this.ToString() == good.ToString();
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        #region Interface_Options
        public int CompareTo(object obj)
        {
            Goods good = (Goods)obj;
            return good.TotalRevenue() - this.TotalRevenue();
        }

        public int Compare(object obj1, object obj2)
        {
            Goods good1 = (Goods)obj1;
            Goods good2 = (Goods)obj2;

            return good1.TotalRevenue() - good2.TotalRevenue();
        }

        public virtual object Clone()
        {
            return new Goods(Title, Manufacturer, Price, Quantity);
        }
        #endregion
    }
}
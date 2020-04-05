using System;
using System.Collections;

namespace GoodsTypes
{
    public interface IExecutable : ICloneable, IComparable
    {
        new int CompareTo(object obj);
        int Compare(object obj1, object obj2);
        new object Clone();
        string ToString();
        int TotalRevenue();
        void Show();
        void Rename(string rename);
        void NewPrice(int price);
        void DeliverMade(int quantity);
        string Title();
        string Manufacturer();
        int Price();
        int Quantity();
    }

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


    public class Goods : IExecutable
    {
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
            Title = "NotDetermined";
            Manufacturer = "NotDetermined";
            Price = 0;
            Quantity = 0;
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
            return $"Товар: {Title}, {Manufacturer}, {Price}р., {Quantity}";
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

        public object Clone()
        {
            return new Goods(Title, Manufacturer, Price, Quantity);
        }

        string IExecutable.Title()
        {
            return Title;
        }

        string IExecutable.Manufacturer()
        {
            return Manufacturer;
        }

        int IExecutable.Price()
        {
            return Price;
        }

        int IExecutable.Quantity()
        {
            return Quantity;
        }
        #endregion
    }
}
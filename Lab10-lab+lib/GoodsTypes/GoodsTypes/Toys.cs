using System;

namespace GoodsTypes
{
    public class Toys : Goods, ICloneable
    {
        private int ageRestriction;
        private string type;

        public int AgeRestriction
        {
            get { return ageRestriction; }
            protected set
            {
                if (value < 0) ageRestriction = 0;
                else ageRestriction = value;
            }

        }

        public string Type
        {
            get { return type; }
            protected set { type = value; }
        }

        public Toys() : base()
        {
            AgeRestriction = 3;
            Type = "NotDetermined";
        }

        public Toys(string title, string manuf) : base(title, manuf)
        {
            AgeRestriction = 3;
            Type = "NotDetermined";
        }

        public Toys(string title, string manuf, int age, string type) : base(title, manuf)
        {
            AgeRestriction = age;
            Type = type;
        }

        public Toys(string title, string manuf, int price, int quantity, int age, string type) : base(title, manuf, price, quantity)
        {
            AgeRestriction = age;
            Type = type;
        }

        public override void Show()
        {
            Console.WriteLine($"Игрушка:\n" +
                $"Название: {Title}, производитель: {Manufacturer}\n" +
                $"Тип: {Type}, {AgeRestriction}+\n" +
                $"Стоимость: {Price}р., Количество на складе: {Quantity} шт.\n");
        }

        public override string ToString()
        {
            return $"Игрушка: {Title}, {Manufacturer}, {Type}, {AgeRestriction}+, {Price}р., {Quantity} шт.";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !GetType().Equals(obj.GetType())) return false;

            Toys good = (Toys)obj;
            return this.ToString() == good.ToString();
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public new object Clone()
        {
            return new Toys(Title, Manufacturer, Price, Quantity, AgeRestriction, Type);
        }

        public Goods BaseGoods
        {
            get { return new Goods(Title, Manufacturer, Price, Quantity); }
        } 
    }
}
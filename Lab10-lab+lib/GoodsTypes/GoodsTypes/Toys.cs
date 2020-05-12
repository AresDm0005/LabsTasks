using System;

namespace GoodsTypes
{
    public class Toys : Goods, ICloneable
    {
        #region Значения для рандома
        private static string[] titles = { "Медвежонок", "Мишки", "Кот", "Кукла", "Монополия", "Дженга", "Робот",
            "Цивилизация", "Майнкрафт", "Приставка", "Балда", "Лего", "Паззлы", "Рыцари", "Карты", "Формула"};
        private static string[] manufs = { "Hasbro", "Firaxis", "Mojang", "Сони", "Игрушечная", "Типография", "Настолки", 
            "Pazzzles", "Нинтендо"};
        private static string[] types = { "Настольная", "Мягкая", "Кукла", "Компьютерная", "На бумаге", "Конструктор", "Электронные" };
        #endregion

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
        
        public Toys(Random rand) 
            : base(titles[rand.Next(titles.Length)], manufs[rand.Next(manufs.Length)], rand.Next(20, 1501), rand.Next(3, 50) * 150)
        {
            Type = types[rand.Next(types.Length)];
            AgeRestriction = rand.Next(0, 19);
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

        public override object Clone()
        {
            return new Toys(Title, Manufacturer, Price, Quantity, AgeRestriction, Type);
        }

        public Goods BaseGoods
        {
            get { return new Goods(Title, Manufacturer, Price, Quantity); }
        } 
    }
}
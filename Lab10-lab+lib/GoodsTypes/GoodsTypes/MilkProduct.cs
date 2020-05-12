using System;

namespace GoodsTypes
{
    public class MilkProduct : FoodProduct
    {
        #region Значения для рандома
        private static string[] titles = { "Простоквашино", "Чудо", "Нытвенская", "Деревенское", "У бабушки", "Козье", "Село", 
            "Кез", "Тофу", "Моцаре", "Чеддер" };
        private static string[] manufs = { "Нытва", "Кунгур", "Билль-Вилль", "Молкомбинаты", "Сыродел"};
        private static string[] types = { "Молоко", "Творог", "Сыр", "Кефир", "Ряженка", "Сметана" };
        #endregion

        private string type;
        private double weight;

        public string Type
        {
            get { return type; }
            protected set { type = value; }
        }

        public double Weight
        {
            get { return weight; }
            protected set
            {
                if (weight < 0) weight = 0;
                else weight = value;
            }
        }

        public MilkProduct() : base()
        {
            Type = "Undetermined";
            Weight = 1.0;
        }

        public MilkProduct(Random rand)
            : base(titles[rand.Next(titles.Length)], manufs[rand.Next(manufs.Length)], rand.Next(20, 1501), rand.Next(3, 50) * 150)
        {
            Type = types[rand.Next(types.Length)];
            Weight = 2.1 * rand.NextDouble();
        }

        public MilkProduct(string title, string manuf) : base(title, manuf)
        {
            Type = "Undetermined";
            Weight = 1.0;
        }

        public MilkProduct(string title, string manuf, string type, double weight) : base(title, manuf)
        {
            Type = type;
            Weight = weight;
        }

        public MilkProduct(string title, string manuf, int price, int quantity, string type, double weight) : base(title, manuf, price, quantity)
        {
            Type = type;
            Weight = weight;
        }

        public MilkProduct(string title, string manuf, int price, int quantity, DateTime date, int lifeSpan, string type, double weight) : base(title, manuf, price, quantity, date, lifeSpan)
        {
            Type = type;
            Weight = weight;
        }

        public override void Show()
        {
            Console.WriteLine($"Молочные продукты:\n" +
                $"Название: {Title}, производитель: {Manufacturer}\n" +
                $"Произведено: {Manufactured}, срок годности: {StorageLife}ч\n" +
                $"Тип: {Type}, вес: {Weight} кг\n" +
                $"Стоимость: {Price}р., Количество на складе: {Quantity} шт.\n");
        }

        public override string ToString()
        {
            return $"Молочка: {Title}, {Manufacturer}, {Manufactured}, {StorageLife}ч.,\n{Type}, {Weight}, {Price}p., {Quantity}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !GetType().Equals(obj.GetType())) return false;

            MilkProduct good = (MilkProduct)obj;
            return this.ToString() == good.ToString();
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public override object Clone()
        {
            return new MilkProduct(Title, Manufacturer, Price, Quantity, Manufactured, StorageLife, Type, Weight);
        }
    }
}
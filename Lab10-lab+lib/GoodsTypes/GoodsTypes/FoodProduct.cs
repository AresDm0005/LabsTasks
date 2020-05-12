using System;

namespace GoodsTypes
{
    public class FoodProduct : Goods
    {
        #region Значения для рандома
        private static string[] titles = { "Огурцы", "Томаты", "Салат", "Перец", "Ягоды", "Колбаса", "Сосиски",
            "Сервелат", "Тушенка", "Консервы", "Яйца", "Пельмени", "Селёдка", "Треска", "Кетчуп",
            "Майонез", "Сок", "Напиток", "Масло", "Соус", "Сыр"};
        private static string[] manufs = { "Овощебаза", "Колхоз #1", "Мясокомбинат", "Птицеферма", "Рыбкино",
            "Рикко", "Красавчик", "Молочка", "Нытва", "Кунгур"};
        #endregion

        protected DateTime manufactured;
        protected int storageLife;

        public DateTime Manufactured
        {
            get { return manufactured; }
            protected set { manufactured = value; }
        }

        public int StorageLife
        {
            get { return storageLife; }
            protected set
            {
                if (value < 0) storageLife = 0;
                else storageLife = value;
            }
        }

        public FoodProduct() : base()
        {
            Manufactured = DateTime.Today - (new TimeSpan(5, 12, 30, 0));
            StorageLife = 168;
        }

        public FoodProduct(Random rand)
            : base(titles[rand.Next(titles.Length)], manufs[rand.Next(manufs.Length)], rand.Next(20, 1501), rand.Next(3, 50) * 150)
        {
            storageLife = rand.Next(24, 240);
            manufactured = DateTime.Today - (new TimeSpan(0, (int)(storageLife * rand.NextDouble() * 2) , 0, 0));
        }
         
        public FoodProduct(string title, string manuf) : base(title, manuf)
        {
            Manufactured = DateTime.Today - (new TimeSpan(5, 12, 30, 0));
            StorageLife = 168;
        }

        public FoodProduct(string title, string manuf, int price, int quantity) : base(title, manuf, price, quantity)
        {
            Manufactured = DateTime.Today - (new TimeSpan(5, 12, 30, 0));
            StorageLife = 168;
        }

        public FoodProduct(string title, string manufacturer, DateTime date, int life) : base(title, manufacturer)
        {
            Manufactured = date;
            StorageLife = life;
        }

        public FoodProduct(string title, string manufacturer, int price, int quantity, DateTime date, int lifeSpan) : base(title, manufacturer, price, quantity)
        {
            Manufactured = date;
            StorageLife = lifeSpan;
        }

        public override void Show()
        {
            Console.WriteLine($"Продукт питания:\n" +
                $"Название: {Title}, производитель: {Manufacturer}\n" +
                $"Произведено: {Manufactured}, срок годности: {StorageLife}ч\n" +
                $"Стоимость: {Price}р., Количество на складе: {Quantity} шт.\n");
        }

        public override object Clone()
        {
            return new FoodProduct(Title, Manufacturer, Price, Quantity, Manufactured, StorageLife);
        }

        public override string ToString()
        {
            return $"Продукт: {Title}, {Manufacturer}, {Manufactured}, {storageLife} ч, {Price}р., {Quantity} шт.";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !GetType().Equals(obj.GetType())) return false;

            FoodProduct good = (FoodProduct)obj;
            return this.ToString() == good.ToString();
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public Goods BaseGoods
        {
            get
            {
                return new Goods(Title, Manufacturer, Price, Quantity);
            }
        }
    }
}
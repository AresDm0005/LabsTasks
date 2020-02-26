using System;

namespace GoodsTypes
{
    public class FoodProduct : Goods
    {
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

        public override string ToString()
        {
            return $"Продукт: {Title}, {Manufacturer}, {Manufactured}, {storageLife} ч, {Price}р., {Quantity} шт.";
        }
    }
}
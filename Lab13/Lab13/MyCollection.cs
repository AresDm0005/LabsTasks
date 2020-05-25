using System;
using System.Collections.Generic;
using GoodsTypes;

namespace Lab13
{
    public enum SortByProperty
    {
        Price = 0,
        Quantity,
        Title,
        Manufacturer
    }

    class MyCollection : Collection<Goods>
    {
        protected Random rnd = new Random();
        public new int Length => base.Length;

        public MyCollection() : base() { }

        public MyCollection(int size) : base()
        {
            for (int i = 0; i < size; i++)
                AddDefault();
        }

        public void AddDefault() 
        {
            int type = rnd.Next(0, 4);
            Goods item;
            if (type == 0)
                item = new Goods(rnd);
            else if (type == 1)
                item = new Toys(rnd);
            else if (type == 2)
                item = new FoodProduct(rnd);
            else
                item = new MilkProduct(rnd);

            Add(item); 
        }
        
        public void Sort(SortByProperty sort)
        {
            switch (sort)
            {
                case SortByProperty.Price:
                    {
                        Sort(new PriceSorter());
                        break;
                    }
                case SortByProperty.Quantity:
                    {
                        Sort(new QuantitySorter());
                        break;
                    }
                case SortByProperty.Title:
                    {
                        Sort(new TitleSorter());
                        break;
                    }
                case SortByProperty.Manufacturer:
                    {
                        Sort(new ManufacturerSorter());
                        break;
                    }
                default: { break; }
            }
        }

        public override string ToString()
        {
            string txt = "";
            Node node = head;

            while (node != null)
            {
                txt += node.Data + "\n";
                node = node.Next;
            }

            if (head == null) txt = "Список пуст";

            return txt;
        }

        #region SortComparers
        private class PriceSorter : IComparer<GoodsTypes.Goods>
        {
            int IComparer<Goods>.Compare(Goods obj1, Goods obj2)
            {
                return obj1.Price - obj2.Price;
            }
        }

        private class QuantitySorter : IComparer<GoodsTypes.Goods>
        {
            int IComparer<Goods>.Compare(Goods obj1, Goods obj2)
            {
                return obj1.Quantity - obj2.Quantity;
            }
        }

        private class TitleSorter : IComparer<GoodsTypes.Goods>
        {
            int IComparer<Goods>.Compare(Goods obj1, Goods obj2)
            {
                return obj1.Title.CompareTo(obj2.Title);
            }
        }

        private class ManufacturerSorter : IComparer<GoodsTypes.Goods>
        {
            int IComparer<Goods>.Compare(Goods obj1, Goods obj2)
            {
                return obj1.Manufacturer.CompareTo(obj2.Manufacturer);
            }
        }
        #endregion
    }
}

using System;
using GoodsTypes;

namespace Lab13
{
    delegate void CollectionHandler(object source, CollectionHandlerEventArgs e);
    public class CollectionHandlerEventArgs : EventArgs
    {
        public string Name { get; }
        public string Type { get; }
        public Goods Item { get; }

        public CollectionHandlerEventArgs(string name, string type, Goods good)
        {
            Name = name;
            Type = type;
            Item = good;
        }

        public override string ToString()
        {
            return $"Событие {Type} произошло в коллекции {Name} с элементом {Item}";
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !obj.GetType().Equals(this)) return false;
            CollectionHandlerEventArgs args = (CollectionHandlerEventArgs)obj;
            return ToString() == obj.ToString();
        }
    }

    class MyNewCollection : MyCollection
    {
        private static int CollCount = 0;
        public string Name { get; private set; }

        public event CollectionHandler CollectionCountChanged;
        public event CollectionHandler CollectionReferenceChanged;

        public MyNewCollection() : base() { Initialize(); }

        public MyNewCollection(int size) : base(size) { Initialize(); }

        private void Initialize()
        {
            CollCount++;
            Name = $"MyNewCollection #{CollCount}";
        }

        public new Goods this[int index]
        {
            get
            {
                if (index < 0 || index > Length) throw new IndexOutOfRangeException();
                return FindNode(index).Next.Data;
            }

            set
            {
                if (index < 0 || index > Length) throw new IndexOutOfRangeException();
                OnCollectionReferenceChanged(this, new CollectionHandlerEventArgs(Name, "Изменение", value));
                FindNode(index).Next.Data = value;
            }
        }

        public new void AddDefault()
        {            
            base.AddDefault();
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs(Name, "Добавление", this[Length - 1]));
        }

        public new void Add(Goods item)
        {
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs(Name, "Добавление", item));
            base.Add(item);
        }

        public new bool Remove(int index)
        {
            if (index < 0 || index > Length) return false;
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs(Name, "удаление элемента", this[index]));
            base.Remove(index);
            return true;            
        }

        public override string ToString()
        {
            string txt = "";
            Node node = head;

            while(node != null)
            {
                txt += node.Data + "\n";
                node = node.Next;
            }

            if (head == null) txt = "Список пуст";

            return txt;
        }

        public virtual void OnCollectionCountChanged(object sender, CollectionHandlerEventArgs e)
        {
            CollectionCountChanged?.Invoke(sender, e);
        }

        public virtual void OnCollectionReferenceChanged(object sender, CollectionHandlerEventArgs e)
        {
            CollectionReferenceChanged?.Invoke(sender, e);
        }
    }
}

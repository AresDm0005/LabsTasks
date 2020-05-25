using System.Collections.Generic;
using GoodsTypes;

namespace Lab13
{
    public class Journal
    {
        public class JournalEntry
        {
            public string Name { get; }
            public string Type { get; }
            public Goods Item { get; }

            public JournalEntry(CollectionHandlerEventArgs e)
            {
                Name = e.Name;
                Type = e.Type;
                Item = e.Item;
            }

            public override string ToString()
            {
                return $"Событие {Type} произошло в коллекции {Name} с элементом {Item}";
            }
        }

        private List<JournalEntry> entries;

        public Journal()
        {
            entries = new List<JournalEntry>();
        }

        public void CollectionCountChanged(object sender, CollectionHandlerEventArgs e)
        {
            entries.Add(new JournalEntry(e));
        }

        public void CollectionReferenceChanged(object sender, CollectionHandlerEventArgs e)
        {
            entries.Add(new JournalEntry(e));
        }

        public override string ToString()
        {
            string txt = "";

            for (int i = 0; i < entries.Count; i++)
            {
                txt += $"#{i + 1} : {entries[i]}\n";
            }

            return txt;
        }
    }
}

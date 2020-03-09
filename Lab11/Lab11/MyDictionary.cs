using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab11
{
    public class MyDictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICloneable
    {
        private struct Entry
        {
            public int hashCode;
            public int next;
            public TKey key;
            public TValue value;
        }

        private int[] buckets;
        private Entry[] entries;

        private int count;
        private int freeList;
        private int freeCount;
        private IEqualityComparer<TKey> comparer;

        public int Capacity { get { return buckets.Length; } }

        public int Count { get { return count - freeCount; } }

        public ICollection<TKey> Keys
        {
            get
            {
                TKey[] keys = new TKey[Count];
                int index = 0;

                for (int i = 0; i < entries.Length; i++)
                {
                    if (entries[i].hashCode >= 0) { keys[index++] = entries[i].key; }
                }

                return keys;
            }
        }

        public ICollection<TValue> Values
        {
            get
            {
                TValue[] values = new TValue[Count];
                int index = 0;

                for(int i = 0; i<entries.Length; i++)
                {
                    if(entries[i].hashCode >= 0) { values[index++] = entries[i].value; }
                }

                return values;
            }
        }

        public void ShowEntries()
        {
            Console.WriteLine("Entries it is: ");
            Console.WriteLine("i --- hash --- key --- value");
            Console.ForegroundColor = ConsoleColor.Green;
            for(int i = 0; i<entries.Length; i++)
            {
                Console.WriteLine($"{i} --- {entries[i].hashCode} --- {entries[i].key} --- {entries[i].value}");
            }
            Console.ResetColor();
            Console.WriteLine("\n");
        }

        public MyDictionary() : this(0, null) { }

        public MyDictionary(int capacity) : this(capacity, null) { }

        public MyDictionary(int capacity, IEqualityComparer<TKey> comparer)
        {
            if (capacity < 0) throw new ArgumentOutOfRangeException();
            if (capacity > 0) Initialize(capacity);
            this.comparer = comparer ?? EqualityComparer<TKey>.Default;
        }

        public MyDictionary(MyDictionary<TKey, TValue> dictionary)
        {
            Initialize(dictionary.Count);
            this.comparer = EqualityComparer<TKey>.Default;

            foreach (KeyValuePair<TKey, TValue> pair in dictionary)
            {
                Add(pair);
            }
        }

        public TValue this[TKey key]
        {
            get
            {
                int index = FindEntry(key);
                if (index >= 0) return entries[index].value;

                throw new KeyNotFoundException();
            }
            set
            {
                Insert(key, value, false);
            }
        }

        private int FindEntry(TKey key)
        {
            if (key == null) throw new ArgumentNullException();

            if (buckets != null)
            {
                int hashCode = key.GetHashCode() & 0x7FFFFFFF;
                for (int i = buckets[hashCode % buckets.Length]; i >= 0; i = entries[i].next)
                {
                    if (entries[i].hashCode == hashCode && comparer.Equals(entries[i].key, key)) 
                        return i;
                }
            }
            return -1;
        }

        private void Initialize(int capacity)
        {
            int size = Functions.GetPrime(capacity);

            buckets = new int[size];
            entries = new Entry[size];

            for (int i = 0; i < size; i++)
            {
                buckets[i] = -1;
                entries[i].hashCode = -1;
            }
            
            freeList = -1;
        }

        private void Resize()
        {
            int newSize = Functions.GetPrime(count * 2);
            int[] newBuckets = new int[newSize];
            Entry[] newEntries = new Entry[newSize];

            for (int i = 0; i < newSize; i++) newBuckets[i] = -1;
            Array.Copy(entries, 0, newEntries, 0, count);


            for (int i = 0; i < count; i++)
            {
                if (newEntries[i].hashCode >= 0)
                {
                    int bucket = newEntries[i].hashCode % newSize;
                    newEntries[i].next = newBuckets[bucket];
                    newBuckets[bucket] = i;
                }
            }

            buckets = newBuckets;
            entries = newEntries;
        }

        private void Insert(TKey key, TValue value, bool add)
        {   // Общий метод для добавления/изменения пар ключ-значение

            if (key == null) throw new ArgumentNullException();
            if (buckets == null || entries == null) Initialize(0);

            // Вычисление хэш-кода и избавление от возможных отрицательных значений
            int hashCode = comparer.GetHashCode(key) & 0x7FFFFFFF;
            // Определение индекса корзины для хэша
            int targetBucket = hashCode % buckets.Length;

            // Часть для изменения пары и проверки отсутствия дублирования существующей пары
            // Пробегаем по цепочке текущей корзины
            // Признак окончания цепочки: -1
            // Если найден ключ в цепи - обновляем значение и выходим
            // Если найден ключ в цепи, а нужно было его добавить - выбрасываем исключение
            for (int i = buckets[targetBucket]; i >= 0; i = entries[i].next)
            {
                if (entries[i].hashCode == hashCode && comparer.Equals(entries[i].key, key))
                {
                    if (add)
                    {
                        throw new ArgumentException();
                    }
                    entries[i].value = value;
                    return;
                }
            }

            int index;
            if (freeCount > 0)
            {
                // Если есть дыры от удаления - заполняем их
                index = freeList;
                freeList = entries[index].next;
                freeCount--;
            }
            else
            {
                // Если промежутков нет - продолжаем последовательное заполнение entries
                if (count == entries.Length)
                {
                    Resize();
                    targetBucket = hashCode % buckets.Length;
                }

                index = count;
                count++;
            }

            entries[index].hashCode = hashCode;
            entries[index].next = buckets[targetBucket];
            entries[index].key = key;
            entries[index].value = value;

            buckets[targetBucket] = index;
        }

        public void Add(TKey key, TValue value)
        {
            Insert(key, value, true);
        }

        public bool Remove(TKey key)
        {
            if (key == null) throw new ArgumentNullException();

            if (buckets != null)
            {
                int hashCode = key.GetHashCode() & 0x7FFFFFFF;
                int bucket = hashCode % buckets.Length;
                int last = -1;

                for (int i = buckets[bucket]; i >= 0; last = i, i = entries[i].next)
                {
                    if (entries[i].hashCode == hashCode && comparer.Equals(entries[i].key, key))
                    {
                        if (last < 0)
                        {
                            buckets[bucket] = entries[i].next;
                        }
                        else
                        {
                            entries[last].next = entries[i].next;
                        }
                        entries[i].hashCode = -1;
                        entries[i].next = freeList;
                        entries[i].key = default(TKey);
                        entries[i].value = default(TValue);
                        freeList = i;
                        freeCount++;
                        return true;
                    }
                }
            }

            return false;
        }

        public bool ContainsKey(TKey key)
        {
            return FindEntry(key) >= 0;
        }

        public bool ContainsValue(TValue value)
        {
            if (entries != null)
            {
                for (int i = 0; i < entries.Length; i++)
                {
                    if (entries[i].hashCode >= 0)
                    {
                        if (EqualityComparer<TValue>.Default.Equals(entries[i].value, value)) 
                            return true;
                    }
                }
            }

            return false;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            if (key == null) throw new ArgumentNullException();

            int index = FindEntry(key);
            if (index >= 0)
            {
                value = entries[index].value;
                return true;
            }

            value = default(TValue);
            return false;
        }

        public void Add(KeyValuePair<TKey, TValue> pair)
        {
            Add(pair.Key, pair.Value);
        }

        public bool Remove(KeyValuePair<TKey, TValue> pair)
        {
            return Remove(pair.Key);
        }

        public bool Contains(KeyValuePair<TKey, TValue> pair)
        {
            int index = FindEntry(pair.Key);
            if (index >= 0 && EqualityComparer<TValue>.Default.Equals(entries[index].value, pair.Value))
            {
                return true;
            }
            return false;
        }

        public void Clear()
        {
            if (count > 0)
            {
                for (int i = 0; i < buckets.Length; i++)
                {
                    buckets[i] = -1;
                    entries[i].hashCode = -1;                    
                }                
                Array.Clear(entries, 0, count);

                freeList = -1;
                count = 0;
                freeCount = 0;
            }
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] arr, int index)
        {
            if (arr == null) throw new ArgumentNullException();
            if (index < 0 || index > arr.Length) throw new ArgumentOutOfRangeException();
            if (arr.Length - index < Count) throw new ArgumentException();

            int count = this.count;
            Entry[] entries = this.entries;

            for (int i = 0; i < count; i++)
            {
                if (entries[i].hashCode >= 0)
                {
                    arr[index++] = new KeyValuePair<TKey, TValue>(entries[i].key, entries[i].value);
                }
            }
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return new Enumerator(this, Enumerator.KEY_VALUE_PAIR);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this, Enumerator.DICT_ENTRY);
        }

        public bool IsReadOnly { get { return false; } }

        public struct Enumerator: IEnumerator<KeyValuePair<TKey, TValue>>, IDictionaryEnumerator
        {
            private MyDictionary<TKey, TValue> dict;
            private int index;
            private KeyValuePair<TKey, TValue> current;
            private int getEnumeratorRetType;

            internal const int DICT_ENTRY = 1;
            internal const int KEY_VALUE_PAIR = 2;

            internal Enumerator(MyDictionary<TKey, TValue> dict, int getEnumeratorRetType)
            {
                this.dict = dict;
                index = 0;
                this.getEnumeratorRetType = getEnumeratorRetType;
                current = new KeyValuePair<TKey, TValue>();
            }

            public KeyValuePair<TKey, TValue> Current { get { return current; } }

            public bool MoveNext()
            {
                while((uint)index <= (uint)dict.Count)
                {
                    if(dict.entries[index].hashCode >= 0)
                    {
                        current = new KeyValuePair<TKey, TValue>(dict.entries[index].key, dict.entries[index].value);
                        index++;
                        return true;
                    }
                    index++;
                }

                index = dict.Count + 1;
                current = new KeyValuePair<TKey, TValue>();
                return false;
            }

            public void Reset()
            {
                index = 0;
                current = new KeyValuePair<TKey, TValue>();
            }

            object IEnumerator.Current
            {
                get
                {
                    if (index == 0 || index == dict.Count + 1)
                        throw new InvalidOperationException();

                    if (getEnumeratorRetType == DICT_ENTRY)
                        return new DictionaryEntry(current.Key, current.Value);
                    else
                        return new KeyValuePair<TKey, TValue>(current.Key, current.Value);

                }
            }

            public object Key 
            {
                get
                {
                    if (index == 0 || index == dict.Count + 1)
                        throw new InvalidOperationException();

                    return current.Key;
                }
            }

            public object Value
            {
                get
                {
                    if (index == 0 || index == dict.Count + 1)
                        throw new InvalidOperationException();

                    return current.Value;
                }
            }

            public DictionaryEntry Entry
            { 
                get
                {
                    if (index == 0 || index == dict.Count + 1)
                        throw new InvalidOperationException();

                    return new DictionaryEntry(current.Key, current.Value);
                }
            }

            public void Dispose() { }
        }
    }    
}

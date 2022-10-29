namespace Problem01.List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class List<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] items;
        private int count;

        public List()
            : this(DEFAULT_CAPACITY) {
        }

        public List(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            this.items = new T[capacity];
        }

        public T this[int index] { get { this.ValidateIndex(index); return this.items[index]; } set => throw new NotImplementedException(); }

        public int Count { get { return count; } private set { this.count = this.items.Length; } }

        public void Add(T item)
        {
            if (this.Count == this.items.Length)
            {
                T[] itemsNew = new T[this.items.Length * 2];

                for (int i = 0; i < this.items.Length; i++)
                {
                    itemsNew[i] = this.items[i];
                }

                this.items = itemsNew;
            }

            this.items[this.Count] = item;
            this.Count++;
        }

        public bool Contains(T item)
        {
            foreach (var element in this.items)
            {
                if (item.Equals(element))
                {
                    return true;
                }
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.items)
            {
                yield return item;
            }
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (item.Equals(this.items[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            ValidateIndex(index);

            if (this.Count == this.items.Length)
            {
                T[] itemsNew = new T[this.items.Length * 2];

                for (int i = 0; i < this.items.Length; i++)
                {
                    itemsNew[i] = this.items[i];
                }

                this.items = itemsNew;
            }

            for (int i = this.Count; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }

            this.items[index] = item;
            this.Count++;
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException("Invalid index!");
            }
        }
    }
}
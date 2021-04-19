using System;
using System.Collections;
using System.Collections.Generic;

namespace Collections
{
    public class ReadOnlyList<T> : IList<T>
    {
        private readonly IList<T> list;

        public ReadOnlyList(IList<T> list)
        {
            this.list = list;
        }

        public int Count { get; }

        public bool IsReadOnly => true;

        public T this[int index]
        {
            get => this.list[index];
            set => this.list[index] = value;
        }

        public void Add(T item)
        {
            throw new NotSupportedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotSupportedException();
        }

        public void Clear()
        {
            throw new NotSupportedException();
        }

        public bool Remove(T item)
        {
            throw new NotSupportedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        public bool Contains(T item)
        {
            return this.IndexOf(item) != -1;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            this.list.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int position = 0; position < this.Count; position++)
            {
                yield return this.list[position];
            }
        }

        public int IndexOf(T item)
        {
            return this.list.IndexOf(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}

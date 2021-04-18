using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

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
            throw new ReadOnlyListException();
        }

        public void Insert(int index, T item)
        {
            throw new ReadOnlyListException();
        }

        public void Clear()
        {
            throw new ReadOnlyListException();
        }

        public bool Remove(T item)
        {
            throw new ReadOnlyListException();
        }

        public void RemoveAt(int index)
        {
            throw new ReadOnlyListException();
        }

        public bool Contains(T item)
        {
            return this.IndexOf(item) != -1;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array", "The destination array is null");
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException("arrayIndex", "The index is less than 0.");
            }

            if (this.Count > array.Length - arrayIndex + 1)
            {
                throw new ArgumentException("There is not enough space to copy all the elements");
            }

            for (int i = 0; i < this.Count; i++)
            {
                array[arrayIndex++] = this[i];
            }
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
            for (int i = 0; i < this.Count; i++)
            {
                if (this.list[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public class ReadOnlyListException : Exception
        {
            public ReadOnlyListException()
            {
                this.ExceptionMessage = "The list is read only and the operation is not allowed.";
            }

            public string ExceptionMessage { get; }
        }
    }
}

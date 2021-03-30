using System;
using System.Collections;
using System.Collections.Generic;

namespace Collections
{
    public class List<T> : IList<T>
    {
        private const int Size = 4;
        private const int ResizeFactor = 2;
        private T[] array;

        public List()
        {
            this.array = new T[Size];
        }

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public virtual T this[int index]
        {
            get => this.array[index];
            set => this.array[index] = value;
        }

        public virtual void Add(T item)
        {
            this.ResizeArray();

            this.array[this.Count++] = item;
        }

        public bool Contains(T item)
        {
            return this.IndexOf(item) != -1;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.array[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        public virtual void Insert(int index, T item)
        {
            this.ResizeArray();
            this.Count++;

            this.ShiftElementsRight(index);

            this.array[index] = item;
        }

        public void Clear()
        {
            this.Count = 0;
        }

        public bool Remove(T item)
        {
            int index = this.IndexOf(item);

            if (index == -1)
            {
                return false;
            }

            this.RemoveAt(index);
            return true;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index > this.Count - 1)
            {
                return;
            }

            this.ShiftElementsLeft(index);

            this.Count--;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            for (int i = 0; i < this.Count; i++)
            {
                array[arrayIndex++] = this[i];
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int position = 0; position < this.Count; position++)
            {
                yield return this.array[position];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void ResizeArray()
        {
            if (this.Count == this.array.Length)
            {
                Array.Resize(ref this.array, this.array.Length * ResizeFactor);
            }
        }

        private void ShiftElementsRight(int index)
        {
            for (int i = this.Count - 1; i > index; i--)
            {
                this.array[i] = this.array[i - 1];
            }
        }

        private void ShiftElementsLeft(int index)
        {
            while (index < this.Count - 1)
            {
                this.array[index] = this.array[++index];
            }
        }
    }
}

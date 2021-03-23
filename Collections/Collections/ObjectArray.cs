using System;
using System.Collections;

namespace Collections
{
    public class ObjectArray : IEnumerable
    {
        private const int Size = 4;
        private const int ResizeFactor = 2;
        private object[] array;

        public ObjectArray()
        {
            this.array = new object[Size];
        }

        public int Count { get; private set; }

        public object this[int index]
        {
            get => this.array[index];
            set => this.array[index] = value;
        }

        public void Add(object obj)
        {
            this.ResizeArray();

            this.array[this.Count++] = obj;
        }

        public bool Contains(object obj)
        {
            return this.IndexOf(obj) != -1;
        }

        public int IndexOf(object obj)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.array[i].Equals(obj))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, object obj)
        {
            this.ResizeArray();
            this.Count++;

            this.ShiftElementsRight(index);

            this.array[index] = obj;
        }

        public void Clear()
        {
            this.Count = 0;
        }

        public void Remove(object obj)
        {
            int index = this.IndexOf(obj);

            if (index == -1)
            {
                return;
            }

            this.RemoveAt(index);
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

        public IEnumerator GetEnumerator()
        {
            return new ObjectArrayEnum(this.array, this.Count);
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

using System;

namespace Collections
{
    public class IntArray
    {
        private const int Size = 4;
        private const int ResizeFactor = 2;

        private int[] array;

        public IntArray()
        {
            this.array = new int[Size];
        }

        public int Count { get; private set; }

        public int this[int index]
        {
            get => this.array[index];
            set => this.array[index] = value;
        }

        public void Add(int element)
        {
            this.ResizeArray();

            this.array[this.Count++] = element;
        }

        public bool Contains(int element)
        {
            return this.IndexOf(element) != -1;
        }

        public int IndexOf(int element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.array[i] == element)
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, int element)
        {
            this.ResizeArray();
            this.Count++;

            this.ShiftElementsRight(index);

            this.array[index] = element;
        }

        public void Clear()
        {
            this.Count = 0;
        }

        public void Remove(int element)
        {
            int firstOccurrence = this.IndexOf(element);

            if (firstOccurrence == -1)
            {
                return;
            }

            this.RemoveAt(firstOccurrence);
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

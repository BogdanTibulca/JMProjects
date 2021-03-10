using System;

namespace Collections
{
    public class IntArray
    {
        private const int Size = 4;
        private const int ResizeFactor = 2;

        private int[] array;
        private int count = 0;

        public IntArray()
        {
            this.array = new int[Size];
        }

        public void Add(int element)
        {
            this.ResizeArray();

            this.array[this.count++] = element;
        }

        public int Count()
        {
            return this.count;
        }

        public int? Element(int index)
        {
            if (index < 0 || index > this.count - 1)
            {
                return null;
            }

            return this.array[index];
        }

        public void SetElement(int index, int element)
        {
            this.array[index] = element;
        }

        public bool Contains(int element)
        {
            return this.IndexOf(element) != -1;
        }

        public int IndexOf(int element)
        {
            for (int i = 0; i < this.count; i++)
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
            this.count++;

            this.ShiftElementsRight(index);

            this.array[index] = element;
        }

        public void Clear()
        {
            this.count = 0;
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
            if (index < 0 || index > this.count - 1)
            {
                return;
            }

            this.ShiftElementsLeft(index);

            this.count--;
        }

        private void ResizeArray()
        {
            if (this.count == this.array.Length)
            {
                Array.Resize(ref this.array, this.array.Length * ResizeFactor);
            }
        }

        private void ShiftElementsRight(int index)
        {
            for (int i = this.count - 1; i > index; i--)
            {
                this.array[i] = this.array[i - 1];
            }
        }

        private void ShiftElementsLeft(int index)
        {
            while (index < this.count - 1)
            {
                this.array[index] = this.array[++index];
            }
        }
    }
}

using System;

namespace Collections
{
    public class IntArray
    {
        private int[] array;
        private int count = 0;
        private int size = 4;

        public IntArray()
        {
            this.array = new int[this.size];
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
            for (int i = 0; i < this.count; i++)
            {
                if (this.array[i] == element)
                {
                    return true;
                }
            }

            return false;
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
            if (index < 0 || index > this.size)
            {
                Console.WriteLine("Invalid index");
                return;
            }

            this.ResizeArray();
            this.count++;

            for (int i = this.count - 1; i > index; i--)
            {
                this.array[i] = this.array[i - 1];
            }

            this.array[index] = element;
        }

        public void Clear()
        {
            this.count = 0;
            this.size = 4;
            Array.Resize(ref this.array, this.size);
        }

        public void Remove(int element)
        {
            int firstOccurrence = this.IndexOf(element);

            if (firstOccurrence == -1)
            {
                return;
            }

            for (int i = firstOccurrence; i < this.count - 1; i++)
            {
                this.array[i] = this.array[i + 1];
            }

            this.count--;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index > this.count - 1)
            {
                return;
            }

            while (index < this.count - 1)
            {
                this.array[index] = this.array[++index];
            }

            this.count--;
        }

        private void ResizeArray()
        {
            if (this.count == this.size)
            {
                this.size *= 2;
                Array.Resize(ref this.array, this.size);
            }
        }
    }
}

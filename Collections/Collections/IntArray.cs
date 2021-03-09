using System;

namespace Collections
{
    public class IntArray
    {
        private int[] array;
        private int count = 0;

        public IntArray()
        {
            this.array = new int[this.count];
        }

        public void Add(int element)
        {
            this.ResizeArrayBy(1);
            this.count++;

            this.array[this.count - 1] = element;
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
            foreach (int num in this.array)
            {
                if (num == element)
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
            if (index < 0 || index > this.count)
            {
                Console.WriteLine("Invalid index");
                return;
            }

            this.ResizeArrayBy(1);
            this.count++;

            for (int i = this.count - 1; i > index; i--)
            {
                this.array[i] = this.array[i - 1];
            }

            this.array[index] = element;
        }

        public void Clear()
        {
            this.ResizeArrayBy(-this.count);
            this.count = 0;
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

            this.ResizeArrayBy(-1);
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

            this.ResizeArrayBy(-1);
        }

        private void ResizeArrayBy(int num)
        {
            Array.Resize(ref this.array, this.count + num);
        }
    }
}

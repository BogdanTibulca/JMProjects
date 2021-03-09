using System;

namespace Collections
{
    public class IntArray
    {
        private int[] array;

        public IntArray()
        {
            this.array = new int[0];
        }

        public void Add(int element)
        {
            Array.Resize(ref this.array, this.array.Length + 1);

            this.array[this.array.Length - 1] = element;
        }

        public int Count()
        {
            return this.array.Length;
        }

        public int? Element(int index)
        {
            if (index < 0 || index > this.array.Length - 1)
            {
                return null;
            }

            return this.array[index];
        }
    }
}

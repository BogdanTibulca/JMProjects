using System;

namespace Collections
{
    public class SortedIntArray : IntArray
    {
        public override int this[int index]
        {
            set
            {
                if (this.CanSet(index, value))
                {
                    base[index] = value;
                }
            }
        }

        public override void Add(int element)
        {
            base.Add(element);
            Array.Sort(this.array, 0, this.Count);
        }

        public override void Insert(int index, int element)
        {
            if (this.CanInsert(index, element))
            {
                base.Insert(index, element);
            }
        }

        private bool CanSet(int index, int element)
        {
            if (index == 0)
            {
                return element <= this.array[1];
            }

            if (index == this.Count - 1)
            {
                return element >= this.array[index - 1];
            }

            return this.array[index - 1] <= element && element <= this.array[index + 1];
        }

        private bool CanInsert(int index, int element)
        {
            if (index == 0 && element <= this[0])
            {
                return true;
            }

            return this.array[index - 1] <= element && element <= this.array[index];
        }
    }
}

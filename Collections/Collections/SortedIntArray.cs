using System;

namespace Collections
{
    public class SortedIntArray : IntArray
    {
        public override int this[int index]
        {
            set
            {
                base[index] = value;
                this.SortArray();
            }
        }

        public override void Add(int element)
        {
            base.Add(element);
            this.SortArray();
        }

        public override void Insert(int index, int element)
        {
            base.Insert(index, element);
            this.SortArray();
        }
    }
}

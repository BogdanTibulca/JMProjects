using System;

namespace Collections
{
    public class SortedList<T> : List<T>
        where T : IComparable<T>
    {
        public override T this[int index]
        {
            set
            {
                if (this.CanSet(index, value))
                {
                    base[index] = value;
                }
            }
        }

        public override void Add(T element)
        {
            base.Add(element);
            this.SortArray();
        }

        public override void Insert(int index, T element)
        {
            if (this.CanInsert(index, element))
            {
                base.Insert(index, element);
            }
        }

        private bool CanSet(int index, T element)
        {
            if (index == 0)
            {
                return element.CompareTo(this[0]) < 1;
            }

            if (index == this.Count - 1)
            {
                return element.CompareTo(this[0]) > -1;
            }

            return element.CompareTo(this[index - 1]) > -1 &&
                this[index + 1].CompareTo(element) > -1;
        }

        private bool CanInsert(int index, T element)
        {
            if (index == 0 && element.CompareTo(this[0]) < 1)
            {
                return true;
            }

            return element.CompareTo(this[index - 1]) > -1 &&
                base[index].CompareTo(element) > -1;
        }

        private void SortArray()
        {
            for (int i = 0; i < this.Count; i++)
            {
                T num = base[i];
                var currentIndex = i;

                while (currentIndex > 0 && base[currentIndex - 1].CompareTo(num) == 1)
                {
                    base[currentIndex] = base[currentIndex - 1];
                    currentIndex--;
                }

                base[currentIndex] = num;
            }
        }
    }
}

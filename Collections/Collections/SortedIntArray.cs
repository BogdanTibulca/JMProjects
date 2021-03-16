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
            this.SortIntArray();
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
                return element <= base[1];
            }

            if (index == this.Count - 1)
            {
                return element >= base[index - 1];
            }

            return base[index - 1] <= element && element <= base[index + 1];
        }

        private bool CanInsert(int index, int element)
        {
            if (index == 0 && element <= this[0])
            {
                return true;
            }

            return base[index - 1] <= element && element <= base[index];
        }

        private void SortIntArray()
        {
            for (int i = 0; i < this.Count; i++)
            {
                int num = base[i];
                var currentIndex = i;

                while (currentIndex > 0 && base[currentIndex - 1] > num)
                {
                    base[currentIndex] = base[currentIndex - 1];
                    currentIndex--;
                }

                base[currentIndex] = num;
            }
        }
    }
}

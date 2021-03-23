using System;
using System.Collections;

namespace Collections
{
    public class ObjectArrayEnum : IEnumerator
    {
        private readonly object[] objectArr;
        private int position = -1;
        private readonly int count;

        public ObjectArrayEnum(object[] objectArr, int count)
        {
            this.objectArr = objectArr;
            this.count = count;
        }

        public object Current => this.objectArr[this.position];

        public bool MoveNext()
        {
            this.position++;

            return this.position < this.count;
        }

        public void Reset()
        {
            this.position = -1;
        }
    }
}

using System;
using System.Collections;

namespace Collections
{
    public class ObjectArrayEnum : IEnumerator
    {
        private readonly object[] objectArr;
        private int position = -1;

        public ObjectArrayEnum(object[] objectArr)
        {
            this.objectArr = objectArr;
        }

        public object Current => this.objectArr[this.position];

        public bool MoveNext()
        {
            this.position++;

            return this.position < this.objectArr.Length;
        }

        public void Reset()
        {
            this.position = -1;
        }
    }
}

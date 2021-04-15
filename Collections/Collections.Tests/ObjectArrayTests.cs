using System;
using Xunit;

namespace Collections.Tests
{
    public class ObjectArrayTests
    {
        private List<object> objArr = new List<object>();

        [Fact]
        public void Add_AddsAnObjectAtTheEndOfTheArray()
        {
            objArr.Add(1);
            objArr.Add("a string");
            objArr.Add(true);
            objArr.Add('c');

            Assert.Equal(1, objArr[0]);
            Assert.True(objArr[1].Equals("a string"));
            Assert.Equal(true, objArr[2]);
            Assert.Equal('c', objArr[3]);
        }

        [Fact]
        public void Add_ListIsReadOnly_ThrowsException()
        {
            objArr.IsReadOnly = true;

            Assert.Throws<NotSupportedException>(() => objArr.Add(32));
        }

        [Fact]
        public void Count_ReturnsTheNumberOfObjectsInTheArray()
        {
            objArr.Add(1);
            objArr.Add("a string");
            objArr.Add(true);
            objArr.Add('c');

            Assert.Equal(4, objArr.Count);
        }

        [Fact]
        public void SetElement_ChangesTheValueOfAnObjectAtAGivenIndex()
        {
            objArr.Add(1);
            objArr.Add("a string");
            objArr.Add(true);

            objArr[1] = "new string";
            objArr[2] = false;

            Assert.True(objArr[1].Equals("new string"));
            Assert.Equal(false, objArr[2]);
        }

        [Theory]
        [InlineData(123, true)]
        [InlineData(12, false)]
        [InlineData("a string", true)]
        [InlineData("not here", false)]
        [InlineData(true, true)]
        [InlineData(false, false)]
        [InlineData('c', true)]
        [InlineData('+', false)]
        public void Contains_ChecksWhetherTheObjectIsInTheArray(
            object element, bool expectedResult)
        {
            objArr.Add(123);
            objArr.Add("a string");
            objArr.Add(true);
            objArr.Add('c');

            Assert.Equal(expectedResult, objArr.Contains(element));
        }

        [Theory]
        [InlineData(123, 0)]
        [InlineData(12, -1)]
        [InlineData("a string", 1)]
        [InlineData("string", -1)]
        [InlineData(true, 2)]
        [InlineData(false, -1)]
        [InlineData('c', 3)]
        [InlineData('-', -1)]
        public void IndexOf_ReturnsTheIndexOfAGivenObject(
            object element, int expectedIndex)
        {
            objArr.Add(123);
            objArr.Add("a string");
            objArr.Add(true);
            objArr.Add('c');

            Assert.Equal(expectedIndex, objArr.IndexOf(element));
        }

        [Fact]
        public void Insert_ShouldInsertANewObjectAtAGivenIndex()
        {
            objArr.Add('a');
            objArr.Add(22);
            objArr.Add(false);

            objArr.Insert(1, "March");

            Assert.Equal('a', objArr[0]);
            Assert.True(objArr[1].Equals("March"));
            Assert.Equal(22, objArr[2]);
            Assert.Equal(false, objArr[3]);
        }

        [Fact]
        public void Insert_IndexLowerThanZero_ThrowsException()
        { 
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => objArr.Insert(-2, "invalid"));

            Assert.Equal("The index should be between 0 and the items count. (Parameter 'index')", ex.Message);
        }

        [Fact]
        public void Insert_IndexHigherThanCount_ThrowsException()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => objArr.Insert(2, "invalid"));

            Assert.Equal("The index should be between 0 and the items count. (Parameter 'index')", ex.Message);
        }

        [Fact]
        public void Clear_RemovesAllTheObjectsInTheArray()
        {
            objArr.Add(123);
            objArr.Add("a string");
            objArr.Add(true);
            objArr.Add('c');

            objArr.Clear();

            Assert.Empty(objArr);
        }

        [Fact]
        public void Clear_ListIsReadOnly_ThrowsException()
        {
            objArr.IsReadOnly = true;

            Assert.Throws<NotSupportedException>(() => objArr.Clear());
        }

        [Fact]
        public void Remove_RemovesTheFirstApperanceOfAGivenObject()
        {
            objArr.Add(123);
            objArr.Add("a string");
            objArr.Add('c');
            objArr.Add(false);

            bool removed = objArr.Remove('c');
            bool notValid = objArr.Remove(2);

            Assert.True(removed);
            Assert.False(notValid);

            Assert.Equal(123, objArr[0]);
            Assert.True(objArr[1].Equals("a string"));
            Assert.Equal(false, objArr[2]);
        }

        [Fact]
        public void Remove_ListIsReadOnly_ThrowsException()
        {
            objArr.Add(23);
            objArr.Add(24);
            objArr.IsReadOnly = true;

            Assert.Throws<NotSupportedException>(() => objArr.Remove(23));
        }

        [Fact]
        public void RemoveAt_RemovesTheObjectAtTheGivenPosition()
        {
            objArr.Add(123);
            objArr.Add("a string");
            objArr.Add('c');
            objArr.Add(false);

            objArr.RemoveAt(2);

            Assert.Equal(123, objArr[0]);
            Assert.True(objArr[1].Equals("a string"));
            Assert.Equal(false, objArr[2]);
        }

        [Fact]
        public void RemoveAt_ListIsReadOnly_ThrowsException()
        {
            objArr.Add(10);
            objArr.Add(20);
            objArr.Add(30);
            objArr.IsReadOnly = true;

            Assert.Throws<NotSupportedException>(() => objArr.RemoveAt(1));
        }

        [Fact]
        public void RemoveAt_IndexLowerThanZero_ThrowsException()
        {
            objArr.Add(1);
            objArr.Add(2);
            objArr.Add(3);
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => objArr.RemoveAt(-2));

            Assert.Equal("The index should be between 0 and the items count. (Parameter 'index')", ex.Message);
        }

        [Fact]
        public void RemoveAt_IndexHigherThanCount_ThrowsException()
        {
            objArr.Add(1);
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => objArr.RemoveAt(2));

            Assert.Equal("The index should be between 0 and the items count. (Parameter 'index')", ex.Message);
        }

        [Fact]
        public void CopyTo_CopiesTheElementsOfTheCollectionToAGivenArray()
        {
            List<int> intList = new List<int> { 1,2,3 };

            int[] newArr = new int[6];

            intList.CopyTo(newArr, 2);

            Assert.Equal(0, newArr[0]);
            Assert.Equal(0, newArr[1]);
            Assert.Equal(1, newArr[2]);
            Assert.Equal(2, newArr[3]);
            Assert.Equal(3, newArr[4]);
            Assert.Equal(0, newArr[5]);
        }

        [Fact]
        public void CopyTo_DestinationArrayIsNull_ThrowsException()
        {
            List<int> intList = new List<int> { 1, 2, 3 };

            int[] newArr = null;

            Assert.Throws<ArgumentNullException>(() => intList.CopyTo(newArr, 0));
        }

        [Fact]
        public void CopyTo_ArrayStartIndexIsLowerThanZero_ThrowsException()
        {
            List<int> intList = new List<int> { 1, 2, 3 };

            int[] newArr = new int[6];

            Assert.Throws<ArgumentOutOfRangeException>(() => intList.CopyTo(newArr, -2));
        }

        [Fact]
        public void CopyTo_InsufficientSpaceToCopyAllTheElements_ThrowsException()
        {
            List<int> intList = new List<int> { 1, 2, 3, 4, 5 };

            int[] newArr = new int[6];

            Assert.Throws<ArgumentException>(() => intList.CopyTo(newArr, 5));
        }
    }
}

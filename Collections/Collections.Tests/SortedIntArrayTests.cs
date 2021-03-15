using Xunit;

namespace Collections.Tests
{
    public class SortedIntArrayTests
    {
        private SortedIntArray sortedArray = new SortedIntArray();

        [Fact]
        public void Add_AddsAnIntegerInTheCorrectPositionInTheArray_ReturnsSortedArray()
        {
            sortedArray.Add(2);
            sortedArray.Add(1);
            sortedArray.Add(3);

            Assert.Equal(1, sortedArray[0]);
            Assert.Equal(2, sortedArray[1]);
            Assert.Equal(3, sortedArray[2]);
        }

        [Fact]
        public void Count_ReturnsTheNumberOfElementsInTheArray()
        {
            sortedArray.Add(1);
            sortedArray.Add(2);
            sortedArray.Add(3);
            int count = sortedArray.Count;

            Assert.Equal(3, count);
        }

        [Fact]
        public void SetElement_ChangesTheValueOfAnElementAtAGivenIndex_ReturnsTheArraySortedWithTheNewElements()
        {
            sortedArray.Add(5);
            sortedArray.Add(6);
            sortedArray.Add(8);

            int newValue = 10;

            sortedArray[2] = newValue;

            Assert.Equal(5, sortedArray[0]);
            Assert.Equal(6, sortedArray[1]);
            Assert.Equal(newValue, sortedArray[2]);
        }

        [Theory]
        [InlineData(2, true)]
        [InlineData(99, false)]
        public void Contains_ChecksWhetherTheElementIsInTheArray(
            int element, bool expectedResult)
        {
            sortedArray.Add(1);
            sortedArray.Add(2);
            sortedArray.Add(3);

            Assert.Equal(expectedResult, sortedArray.Contains(element));
        }

        [Theory]
        [InlineData(2, 0)]
        [InlineData(99, -1)]
        public void IndexOf_ReturnsTheIndexOfAGivenNumber(
            int number, int expectedIndex)
        {
            sortedArray.Add(3);
            sortedArray.Add(2);
            sortedArray.Add(4);

            Assert.Equal(expectedIndex, sortedArray.IndexOf(number));
        }

        [Fact]
        public void Insert_ShouldInsertANewElementAtAGivenIndex_ReturnsTheArraySorted()
        {
            sortedArray.Add(10);
            sortedArray.Add(30);
            sortedArray.Add(40);

            sortedArray.Insert(0, 8);
            sortedArray.Insert(3, 35);

            Assert.Equal(8, sortedArray[0]);
            Assert.Equal(10, sortedArray[1]);
            Assert.Equal(30, sortedArray[2]);
            Assert.Equal(35, sortedArray[3]);
            Assert.Equal(40, sortedArray[4]);
        }

        [Fact]
        public void Clear_RemovesAllTheElementsInTheArray()
        {
            sortedArray.Add(1);
            sortedArray.Add(2);
            sortedArray.Add(3);
            sortedArray.Add(4);

            sortedArray.Clear();

            Assert.Equal(0, sortedArray.Count);
        }

        [Fact]
        public void Remove_RemovesTheFirstApperanceOfAGivenElement()
        {
            sortedArray.Add(1);
            sortedArray.Add(2);
            sortedArray.Add(3);
            sortedArray.Add(4);

            sortedArray.Remove(3);

            Assert.Equal(1, sortedArray[0]);
            Assert.Equal(2, sortedArray[1]);
            Assert.Equal(4, sortedArray[2]);
        }
    }
}

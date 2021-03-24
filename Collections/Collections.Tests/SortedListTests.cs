using Xunit;

namespace Collections.Tests
{
    public class SortedListTests
    {
        [Fact]
        public void Add_AddsAnElementInTheCorrectPositionInTheArray_ReturnsSortedArray()
        {
            SortedList<int> intList = new SortedList<int>();

            intList.Add(2);
            intList.Add(1);
            intList.Add(3);

            Assert.Equal(1, intList[0]);
            Assert.Equal(2, intList[1]);
            Assert.Equal(3, intList[2]);
        }

        [Fact]
        public void Count_ReturnsTheNumberOfElementsInTheArray()
        {
            SortedList<char> charList = new SortedList<char>() { 'a', 'f', 'z'};

            int count = charList.Count;

            Assert.Equal(3, count);
        }

        [Fact]
        public void SetElement_ChangesTheValueOfAnElementAtAGivenIndex_ReturnsTheArraySortedWithTheNewElements()
        {
            SortedList<int> intList = new SortedList<int>() { 1, 4, 22};

            intList[1] = 10;

            Assert.Equal(1, intList[0]);
            Assert.Equal(10, intList[1]);
            Assert.Equal(22, intList[2]);
        }

        [Theory]
        [InlineData(22, true)]
        [InlineData(0, false)]
        public void Contains_ChecksWhetherTheElementIsInTheArray(
            int element, bool expectedResult)
        {
            SortedList<int> intList = new SortedList<int>() { 1, 4, 10, 22 };

            Assert.Equal(expectedResult, intList.Contains(element));
        }

        [Theory]
        [InlineData(4, 2)]
        [InlineData(22, -1)]
        public void IndexOf_ReturnsTheIndexOfAGivenNumber(
            int number, int expectedIndex)
        {
            SortedList<int> intList = new SortedList<int>() { 0, 2, 4, 6 };

            Assert.Equal(expectedIndex, intList.IndexOf(number));
        }

        [Fact]
        public void Insert_ShouldInsertANewElementAtAGivenIndex_ReturnsTheArraySorted()
        {
            SortedList<int> intList = new SortedList<int>() { 0, 2, 4 };

            intList.Insert(1, 1);
            intList.Insert(3, 3);

            Assert.Equal(0, intList[0]);
            Assert.Equal(1, intList[1]);
            Assert.Equal(2, intList[2]);
            Assert.Equal(3, intList[3]);
            Assert.Equal(4, intList[4]);
        }

        [Fact]
        public void Clear_RemovesAllTheElementsInTheArray()
        {
            SortedList<char> charList = new SortedList<char>() { 'b', 'f', 'g' };

            charList.Clear();

            Assert.Equal(0, charList.Count);
        }

        [Fact]
        public void Remove_RemovesTheFirstApperanceOfAGivenElement()
        {
            SortedList<char> charList = new SortedList<char>() { 'a', 'a', 'b', 'c' };

            charList.Remove('a');

            Assert.Equal('a', charList[0]);
            Assert.Equal('b', charList[1]);
            Assert.Equal('c', charList[2]);
        }
    }
}

using System;
using Xunit;

namespace Collections.Tests
{
    public class IntArrayTests
    {

        private IntArray array = new IntArray();

        [Fact]
        public void Add_AddsAnIntegerAtTheEndOfTheArray()
        {
            array.Add(1);
            array.Add(2);
            array.Add(3);

            Assert.Equal(1, array.Element(0));
            Assert.Equal(2, array.Element(1));
            Assert.Equal(3, array.Element(2));
        }

        [Fact]
        public void Count_ReturnsTheNumberOfElementsInTheArray()
        {
            array.Add(1);
            array.Add(2);
            int count = array.Count;

            Assert.Equal(2, count);
        }

        [Fact]
        public void SetElement_ChangesTheValueOfAnElementAtAGivenIndex()
        {
            array.Add(1);
            int newValue = 3;

            array.SetElement(0, newValue);

            Assert.Equal(newValue, array.Element(0));
        }

        [Theory]
        [InlineData(2, true)]
        [InlineData(99, false)]
        public void Contains_ChecksWhetherTheElementIsInTheArray(
            int element, bool expectedResult)
        {
            array.Add(1);
            array.Add(2);
            array.Add(3);

            Assert.Equal(expectedResult, array.Contains(element));
        }

        [Theory]
        [InlineData(2, 0)]
        [InlineData(99, -1)]
        public void IndexOf_ReturnsTheIndexOfAGivenNumber(
            int number, int expectedIndex)
        {
            array.Add(2);
            array.Add(3);
            array.Add(4);

            Assert.Equal(expectedIndex, array.IndexOf(number));
        }

        [Fact]
        public void Insert_ShouldInsertANewElementAtAGivenIndex()
        {
            array.Add(1);
            array.Add(3);
            array.Add(4);
            int element = 2;

            array.Insert(1, element);

            Assert.Equal(1, array.Element(0));
            Assert.Equal(2, array.Element(1));
            Assert.Equal(3, array.Element(2));
            Assert.Equal(4, array.Element(3));
        }

        [Fact]
        public void Clear_RemovesAllTheElementsInTheArray()
        {
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Add(4);

            array.Clear();

            Assert.Equal(0, array.Count);
        }

        [Fact]
        public void Remove_RemovesTheFirstApperanceOfAGivenElement()
        {
            array.Add(1);
            array.Add(44);
            array.Add(2);
            array.Add(3);

            array.Remove(44);

            Assert.Equal(1, array.Element(0));
            Assert.Equal(2, array.Element(1));
            Assert.Equal(3, array.Element(2));
        }

        [Fact]
        public void RemoveAt_RemovesTheElementAtTheGivenPosition()
        {
            array.Add(1);
            array.Add(44);
            array.Add(2);
            array.Add(3);

            array.RemoveAt(1);

            Assert.Equal(1, array.Element(0));
            Assert.Equal(2, array.Element(1));
            Assert.Equal(3, array.Element(2));
        }
    }
}

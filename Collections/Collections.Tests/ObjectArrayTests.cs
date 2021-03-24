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
        public void Clear_RemovesAllTheObjectsInTheArray()
        {
            objArr.Add(123);
            objArr.Add("a string");
            objArr.Add(true);
            objArr.Add('c');

            objArr.Clear();

            Assert.Equal(0, objArr.Count);
        }

        [Fact]
        public void Remove_RemovesTheFirstApperanceOfAGivenObject()
        {
            objArr.Add(123);
            objArr.Add("a string");
            objArr.Add('c');
            objArr.Add(false);

            objArr.Remove('c');

            Assert.Equal(123, objArr[0]);
            Assert.True(objArr[1].Equals("a string"));
            Assert.Equal(false, objArr[2]);
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
    }
}

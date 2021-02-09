using System;
using Xunit;

namespace JSONFormat.Tests
{
    public class RangeTests
    {
        readonly Range digit = new Range('a', 'f');

        [Fact]
        public void Match_TextReceivedIsNull_ShouldReturnFalse()
        {
            Assert.False(digit.Match(null).Success());
        }

        [Fact]
        public void Match_TextReceivedIsEmpty_ShouldReturnFalse()
        {
            Assert.False(digit.Match("").Success());
        }

        [Fact]
        public void Match_FirstLetterIsBetweenTheBoundaries_ShouldReturnTrue()
        {
            Assert.True(digit.Match("abc").Success());
            Assert.True(digit.Match("fab").Success());
            Assert.True(digit.Match("bcd").Success());
        }

        [Fact]
        public void Match_FirstLetterIsOutsideBoundaries_ShouldReturnFalse()
        {
            Assert.False(digit.Match("1ab").Success());
            Assert.False(digit.Match("zab").Success());
        }
    }
}

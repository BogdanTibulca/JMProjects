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
            Assert.False(digit.Match(null));
        }

        [Fact]
        public void Match_TextReceivedIsEmpty_ShouldReturnFalse()
        {
            Assert.False(digit.Match(""));
        }

        [Fact]
        public void Match_FirstLetterIsBetweenTheBoundaries_ShouldReturnTrue()
        {
            Assert.True(digit.Match("abc"));
            Assert.True(digit.Match("fab"));
            Assert.True(digit.Match("bcd"));
        }

        [Fact]
        public void Match_FirstLetterIsOutsideBoundaries_ShouldReturnFalse()
        {
            Assert.False(digit.Match("1ab"));
            Assert.False(digit.Match("zab"));
        }
    }
}

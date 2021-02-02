using System;
using Xunit;

namespace JSONFormat.Tests
{
    public class ChoiceTests
    {
        Choice diggit = new Choice(
            new Character('a'),
            new Range('1', '9')
            );

        [Theory]
        [InlineData("012", true)]
        [InlineData("12", true)]
        [InlineData("92", true)]
        [InlineData("a9", false)]
        [InlineData("", false)]
        [InlineData("null", false)]
        public void Match_BasicCharacterAndRangePatterns_ShouldValidateText(string text, bool expected)
        {
            bool result = diggit.Match(text);

            Assert.Equal(expected, result);
        }
    }
}

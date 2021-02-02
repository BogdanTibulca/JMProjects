using System;
using Xunit;

namespace JSONFormat.Tests
{
    public class ChoiceTests
    {
        readonly Choice diggit = new Choice(
            new Character('0'),
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

        [Theory]
        [InlineData("012", true)]
        [InlineData("12", true)]
        [InlineData("92", true)]
        [InlineData("a2", true)]
        [InlineData("f8", true)]
        [InlineData("A9", true)]
        [InlineData("F8", true)]
        [InlineData("g8", false)]
        [InlineData("G8", false)]
        [InlineData("", false)]
        [InlineData(null, false)]

        public void Match_ComplexPatternsOfCharactersAndRanges_ShouldValidateText(string text, bool expected)
        {
            Choice hex = new Choice(
                diggit,
                new Choice(
                    new Range('a', 'f'),
                    new Range('A', 'F'))
                );

            bool result = hex.Match(text);

            Assert.Equal(expected, result);
        }
    }
}

using Xunit;

namespace JSONFormat.Tests
{
    public class MatchTests
    {
        readonly Match simplePattern = new Match(
            new Character('a')
            );

        readonly Match complexPattern = new Match(
            new Character('a'),
            new Character('b')
            );

        [Theory]
        [InlineData("a", true)]
        [InlineData("abc", true)]
        [InlineData("bc", false)]
        [InlineData("", false)]
        [InlineData(null, false)]
        public void Success_PatternConsistingOfOneLetter_ShouldReturnTrueIfTheTextStartsWithThatLetter(string text, bool expected)
        {
            bool result = simplePattern.Success(text);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("ab", true)]
        [InlineData("abc", true)]
        [InlineData("def", false)]
        [InlineData("ax", false)]
        [InlineData("ba", false)]
        [InlineData("", false)]
        [InlineData(null, false)]
        public void Success_MoreComplexPatternReceived_ShouldReturnTrueIfTheTextFollowsThePattern(string text, bool expected)
        {

            bool result = complexPattern.Success(text);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("a", "")]
        [InlineData("abc", "bc")]
        [InlineData("bc", "bc")]
        [InlineData("", "")]
        [InlineData(null, null)]
        public void RemainingText_PatternConsistingOfOneLetter_ShouldReturnTheTextAfterThePattern(string text, string expected)
        {
            string result = simplePattern.RemainingText(text);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("ab", "")]
        [InlineData("abc", "c")]
        [InlineData("def", "def")]
        [InlineData("ax", "ax")]
        [InlineData("ba", "ba")]
        [InlineData("", "")]
        [InlineData(null, null)]
        public void RemainingText_MoreComplexPatternReceived_ShouldReturnTheTextAfterThePattern(string text, string expected)
        {
            string result = complexPattern.RemainingText(text);

            Assert.Equal(expected, result);
        }

    }
}

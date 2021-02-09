using Xunit;

namespace JSONFormat.Tests
{
    public class MatchTests
    {
        /*readonly Match characterPattern = new Match(
            new Character('a')
            );

        readonly Match rangePattern = new Match(
            new Range('0', '5')
            );

        [Theory]
        [InlineData("", false)]
        [InlineData(null, false)]
        [InlineData("a", true)]
        [InlineData("abc", true)]
        [InlineData("bc", false)]
        public void Success_CharacterPatternReceived_ShouldReturnTrueIfTheTextStartsWithThatCharacter(string text, bool expected)
        {
            bool result = characterPattern.Success(text);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("", false)]
        [InlineData(null, false)]
        [InlineData("1", true)]
        [InlineData("42", true)]
        [InlineData("61", false)]
        [InlineData("0", true)]
        [InlineData("-1", false)]
        public void Success_RangePatternReceived_ShouldReturnTrueIfTheCharacterInWithinThatRange(string text, bool expected)
        {
            bool result = rangePattern.Success(text);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("", "")]
        [InlineData(null, null)]
        [InlineData("a", "")]
        [InlineData("abc", "bc")]
        [InlineData("bc", "bc")]
        public void RemainingText_CharacterPatternReceived_ShouldReturnTheTextAfterThePattern(string text, string expected)
        {
            string result = characterPattern.RemainingText(text);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("", "")]
        [InlineData(null, null)]
        [InlineData("1", "")]
        [InlineData("12", "2")]
        [InlineData("333", "33")]
        [InlineData("-1", "-1")]
        [InlineData("78", "78")]
        public void RemainingText_RangePatternReceived_ShouldReturnTheTextAfterThePattern(string text, string expected)
        {
            string result = rangePattern.RemainingText(text);

            Assert.Equal(expected, result);
        }
*/
    }
}

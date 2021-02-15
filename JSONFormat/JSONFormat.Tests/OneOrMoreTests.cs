using Xunit;

namespace JSONFormat.Tests
{
    public class OneOrMoreTests
    {
        private readonly OneOrMore a = new OneOrMore(new Range('0', '9'));

        [Theory]
        [InlineData("", false, "")]
        [InlineData(null, false, null)]
        [InlineData("123", true, "")]
        [InlineData("1a", true, "a")]
        [InlineData("bc", false, "bc")]
        public void Match_PatternReceived_ReturnsCorrectSuccessAndRemainingTextAfterRemovingFirstOccurenciesOfThePattern(
            string text, bool expectedSuccess, string expectedRemainingText)
        {
            IMatch match = a.Match(text);

            Assert.Equal(expectedSuccess, match.Success());
            Assert.Equal(expectedRemainingText, match.RemainingText());
        }
    }
}

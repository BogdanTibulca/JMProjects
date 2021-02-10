using Xunit;

namespace JSONFormat.Tests
{
    public class ManyTests
    {
        Many a = new Many(new Character('a'));

        [Theory]
        [InlineData("", true, "")]
        [InlineData(null, true, null)]
        [InlineData("a", true, "")]
        [InlineData("abc", true, "bc")]
        [InlineData("aaaab", true, "b")]
        [InlineData("bc", true, "bc")]
        public void Match_CharacterPatternReceived_ShouldReturnSuccessAndTheRemainingTextAfterConsumingThePattern(
            string text, bool expectedSuccess, string expectedRemainingText)
        {
            IMatch match = a.Match(text);

            Assert.Equal(expectedSuccess, match.Success());
            Assert.Equal(expectedRemainingText, match.RemainingText());
        }

        Many diggits = new Many(new Range('0', '9'));

        [Theory]
        [InlineData("ab", true, "ab")]
        [InlineData("12345ab123", true, "ab123")]
        public void Match_RangePatternReceived_ShouldReturnSuccessAndTheRemainingTextAfterConsumingThePattern(
            string text, bool expectedSuccess, string expectedRemainingText)
        {
            IMatch match = diggits.Match(text);

            Assert.Equal(expectedSuccess, match.Success());
            Assert.Equal(expectedRemainingText, match.RemainingText());
        }
    }
}

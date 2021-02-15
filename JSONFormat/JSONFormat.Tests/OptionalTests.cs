using Xunit;

namespace JSONFormat.Tests
{
    public class OptionalTests
    {
        private readonly Optional a = new Optional(new Character('a'));

        [Theory]
        [InlineData("", true, "")]
        [InlineData(null, true, null)]
        [InlineData("abc" , true, "bc")]
        [InlineData("aabc", true, "abc")]
        [InlineData("bc", true, "bc")]
        public void Match_AppliesCharacterPattern_ShouldReturnSuccessAndTheRemainingText(
            string text, bool expectedSuccess, string expectedRemainingText)
        {
            IMatch match = a.Match(text);

            Assert.Equal(expectedRemainingText, match.RemainingText());
            Assert.True(expectedSuccess);
        }

        private readonly Optional sign = new Optional(new Character('-'));
        
        [Theory]
        [InlineData("-123", true, "123")]
        [InlineData("123", true, "123")]
        public void Match_SignCharacterPattern_ShouldReturnSuccessAndTheRemainingText(
            string text, bool expectedSuccess, string expectedRemainingText)
        {
            IMatch match = sign.Match(text);

            Assert.Equal(expectedRemainingText, match.RemainingText());
            Assert.True(expectedSuccess);
        }
    }
}

using System;
using Xunit;

namespace JSONFormat.Tests
{
    public class AnyTests
    {
        private readonly Any e = new Any("eE");

        [Theory]
        [InlineData("", false, "")]
        [InlineData(null, false, null)]
        [InlineData("ea", true, "a")]
        [InlineData("Ea", true, "a")]
        [InlineData("eE", true, "E")]
        [InlineData("a", false, "a")]
        public void Match_TheTextBeginsWithAValidLetter_ShouldReturnCorrectSuccessAndRemainingTextValues(
            string text, bool expectedSuccess, string expectedRemainingText)
        {
            IMatch match = e.Match(text);

            Assert.Equal(expectedSuccess, match.Success());
            Assert.Equal(expectedRemainingText, match.RemainingText());
        }

        private readonly Any sign = new Any("+-");

        [Theory]
        [InlineData("", false, "")]
        [InlineData(null, false, null)]
        [InlineData("+2", true, "2")]
        [InlineData("-1", true, "1")]
        [InlineData("2", false, "2")]
        [InlineData("+-", true, "-")]
        public void Match_TheTextBeginsWithAValidCharacter_ShouldReturnCorrectSuccessAndRemainingTextValues(
            string text, bool expectedSuccess, string expectedRemainingText)
        {
            IMatch match = sign.Match(text);

            Assert.Equal(expectedSuccess, match.Success());
            Assert.Equal(expectedRemainingText, match.RemainingText());
        }
    }
}

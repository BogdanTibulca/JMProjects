using Xunit;

namespace JSONFormat.Tests
{
    public class StringTests
    {
        private readonly String s = new String();

        [Theory]
        [InlineData("", false, "")]
        [InlineData(null, false, null)]
        public void Match_TheTextIsNotNullOrEmpty_ShouldReturnFalse(
            string text, bool expectedSuccess, string expectedRemainingText)
        {

            IMatch match = s.Match(text);

            Assert.Equal(expectedSuccess, match.Success());
            Assert.Equal(expectedRemainingText, match.RemainingText());
        }

        [Theory]
        [InlineData(@"""text""", true, "")]
        [InlineData(@"text""", false, @"text""")]
        [InlineData(@"""text", false, @"""text")]
        public void Match_TheTextIsAlwaysWrappedInDoubleQuotes_ReturnsCorrectSuccessAndRemainingTextValues(
            string text, bool expectedSuccess, string expectedRemainingText)
        {
            IMatch match = s.Match(text);

            Assert.Equal(expectedSuccess, match.Success());
            Assert.Equal(expectedRemainingText, match.RemainingText());
        }

        [Theory]
        [InlineData(@"""text\""", false, @"""text\""")]
        public void Match_TheTextDoesNotEndWithReverseSolidus_ReturnsCorrectSuccessAndRemainingTextValues(
            string text, bool expectedSuccess, string expectedRemainingText)
        {
            IMatch match = s.Match(text);

            Assert.Equal(expectedSuccess, match.Success());
            Assert.Equal(expectedRemainingText, match.RemainingText());
        }

        [Theory]
        [InlineData(@"""text\\""", true, "")]
        public void Match_TheTextCanEndWithEscapedReverseSolidus_ReturnsCorrectSuccessAndRemainingTextValues(
            string text, bool expectedSuccess, string expectedRemainingText)
        {
            IMatch match = s.Match(text);

            Assert.Equal(expectedSuccess, match.Success());
            Assert.Equal(expectedRemainingText, match.RemainingText());
        }

        [Theory]
        [InlineData("\r", false, "\r")]
        [InlineData("\f", false, "\f")]
        [InlineData("\n", false, "\n")]
        [InlineData("\t", false, "\t")]
        [InlineData("\b", false, "\b")]
        public void Match_ControlCharacterAreNotAllowed_ReturnsCorrectSuccessAndRemainingTextValues(
            string text, bool expectedSuccess, string expectedRemainingText)
        {
            IMatch match = s.Match(text);

            Assert.Equal(expectedSuccess, match.Success());
            Assert.Equal(expectedRemainingText, match.RemainingText());
        }

        [Theory]
        [InlineData(@"""a\rb""", true, "")]
        [InlineData(@"""a\fb""", true, "")]
        [InlineData(@"""a\nb""", true, "")]
        [InlineData(@"""a\tb""", true, "")]
        [InlineData(@"""a\bb""", true, "")]
        public void Match_EscapedControlCharacterAreAllowed_ReturnsCorrectSuccessAndRemainingTextValues(
            string text, bool expectedSuccess, string expectedRemainingText)
        {
            IMatch match = s.Match(text);

            Assert.Equal(expectedSuccess, match.Success());
            Assert.Equal(expectedRemainingText, match.RemainingText());
        }

        [Theory]
        [InlineData(@"""\u25CF""", true, "")]
        [InlineData(@"""\u25C""", false, @"""\u25C""")]
        [InlineData(@"""\u""", false, @"""\u""")]
        public void Match_TheTextCanContainValidEscapedUnicode_ReturnsCorrectSuccessAndRemainingTextValues(
            string text, bool expectedSuccess, string expectedRemainingText)
        {
            IMatch match = s.Match(text);

            Assert.Equal(expectedSuccess, match.Success());
            Assert.Equal(expectedRemainingText, match.RemainingText());
        }
    }
}

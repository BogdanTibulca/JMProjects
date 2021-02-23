using Xunit;

namespace JSONFormat.Tests
{
    public class NumberTests
    {
        private readonly Number num = new Number();

        [Theory]
        [InlineData("", false, "")]
        [InlineData(null, false, null)]
        public void Match_EmptyStringOrNullReceived_ShouldReturnFalseAndTheInput(
            string text, bool expectedSuccess, string expectedRemainingText)
        {
            IMatch match = num.Match(text);

            Assert.Equal(expectedSuccess, match.Success());
            Assert.Equal(expectedRemainingText, match.RemainingText());
        }

        [Theory]
        [InlineData("0", true, "")]
        [InlineData("987", true, "")]
        [InlineData("45", true, "")]
        public void Match_Integer_ShouldReturnSuccessAndTheRemainingText(
            string text, bool expectedSuccess, string expectedRemainingText)
        {
            IMatch match = num.Match(text);

            Assert.Equal(expectedSuccess, match.Success());
            Assert.Equal(expectedRemainingText, match.RemainingText());
        }

        [Theory]
        [InlineData("1.24", true, "")]
        [InlineData("0.77", true, "")]
        public void Match_DecimalNumbers_ShouldReturnSuccessAndTheRemainingText(
            string text, bool expectedSuccess, string expectedRemainingText)
        {
            IMatch match = num.Match(text);

            Assert.Equal(expectedSuccess, match.Success());
            Assert.Equal(expectedRemainingText, match.RemainingText());
        }

        [Theory]
        [InlineData("12e2", true, "")]
        [InlineData("1E3", true, "")]
        public void Match_NumbersWithExponents_ShouldReturnSuccessAndTheRemainingText(
            string text, bool expectedSuccess, string expectedRemainingText)
        {
            IMatch match = num.Match(text);

            Assert.Equal(expectedSuccess, match.Success());
            Assert.Equal(expectedRemainingText, match.RemainingText());
        }

        [Theory]
        [InlineData("-23", true, "")]
        [InlineData("-1.5", true, "")]
        [InlineData("-2e3", true, "")]
        [InlineData("-5E2", true, "")]
        public void Match_NegativeNumbers_ShouldReturnSuccessAndTheRemainingText(
            string text, bool expectedSuccess, string expectedRemainingText)
        {
            IMatch match = num.Match(text);

            Assert.Equal(expectedSuccess, match.Success());
            Assert.Equal(expectedRemainingText, match.RemainingText());
        }

        [Theory]
        [InlineData("-2.e3", true, "")]
        [InlineData("0.44e-3", true, "")]
        [InlineData("5.E2", true, "")]
        [InlineData("6.E-3", true, "")]
        public void Match_FractionalNumbersWithExponent_ShouldReturnSuccessAndTheRemainingText(
            string text, bool expectedSuccess, string expectedRemainingText)
        {
            IMatch match = num.Match(text);

            Assert.Equal(expectedSuccess, match.Success());
            Assert.Equal(expectedRemainingText, match.RemainingText());
        }
    }
}

using Xunit;

namespace JSONFormat.Tests
{
    public class DateTimeTests
    {
        private readonly DateTime dt = new DateTime();

        [Theory]
        [InlineData("1994-11-05T08:15:30-05:00", true, "")]
        [InlineData("1997-07-16T19:20:30+01:00", true, "")]
        [InlineData("1997-07-16T19:20:30.45+01:00", true, "")]
        [InlineData("1994-11-05T13:15:30Z", true, "")]
        public void Match_ValidFormatISODateAndTime_ShouldReturnTrueAndTheRemainingText(
            string text, bool expectedSuccess, string expectedRemainingText)
        {
            IMatch match = dt.Match(text);

            Assert.Equal(expectedSuccess, match.Success());
            Assert.Equal(expectedRemainingText, match.RemainingText());
        }

        [Theory]
        [InlineData("1999-12-11", false, "1999-12-11")]
        [InlineData("12:30:22", false, "12:30:22")]
        [InlineData("1994+11-05T08:15:30-05:00", false, "1994+11-05T08:15:30-05:00")]
        [InlineData("1994-11+05T08:15:30-05:00", false, "1994-11+05T08:15:30-05:00")]
        [InlineData("1994-11-05T08+15:30-05:00", false, "1994-11-05T08+15:30-05:00")]
        [InlineData("1994-11-05T08:15:30.05:00", false, "1994-11-05T08:15:30.05:00")]
        [InlineData("1997.07-16T19:20:30+01:00", false, "1997.07-16T19:20:30+01:00")]
        [InlineData("1997-07.16T19:20:30.45+01:00", false, "1997-07.16T19:20:30.45+01:00")]
        [InlineData("1994-11-05F13:15:30Z", false, "1994-11-05F13:15:30Z")]
        [InlineData("1994-11-05T13:15:30G", false, "1994-11-05T13:15:30G")]
        public void Match_InalidFormatISODateAndTime_ShouldReturnFalseAndTheRemainingText(
            string text, bool expectedSuccess, string expectedRemainingText)
        {
            IMatch match = dt.Match(text);

            Assert.Equal(expectedSuccess, match.Success());
            Assert.Equal(expectedRemainingText, match.RemainingText());
        }
    }
}

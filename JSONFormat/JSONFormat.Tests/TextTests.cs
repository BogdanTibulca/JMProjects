using Xunit;
namespace JSONFormat.Tests
{
    public class TextTests
    {
        Text trueVal = new Text("true");
        
        [Theory]
        [InlineData("", false, "")]
        [InlineData(null, false, null)]
        [InlineData("true", true, "")]
        [InlineData("trueX", true, "X")]
        [InlineData("Xtrue", false, "Xtrue")]
        [InlineData("false", false, "false")]
        public void Match_IfTheTextHasTheGivenPrefix_ShouldReturnCorrectSuccessAndRemainingTextValues(
            string text, bool expectedSuccess, string expectedRemainingText)
        {
            IMatch match = trueVal.Match(text);

            Assert.Equal(expectedSuccess, match.Success());
            Assert.Equal(expectedRemainingText, match.RemainingText());
        }

        Text empty = new Text("");

        [Theory]
        [InlineData("true", true, "true")]
        [InlineData("false", true, "false")]
        [InlineData(null, false, null)]
        public void Match_NoPrefixIsGiven_ShouldReturnCorrectSuccessAndTheTextReceived(
            string text, bool expectedSuccess, string expectedRemainingText)
        {
            IMatch match = empty.Match(text);

            Assert.Equal(expectedSuccess, match.Success());
            Assert.Equal(expectedRemainingText, match.RemainingText());
        }
    }
}

using Xunit;

namespace JSONFormat.Tests
{
    public class ValueTests
    {
        private readonly Value value = new Value();

        [Fact]
        public void Match_TheValueIsNull_ShouldReturnSuccessAndTheRemaininText()
        {
            IMatch match = value.Match("null");

            Assert.True(match.Success());
            Assert.Equal("", match.RemainingText());
        }

        [Fact]
        public void Match_TheValueIsTrue_ShouldReturnSuccessAndTheRemaininText()
        {
            IMatch match = value.Match("true");

            Assert.True(match.Success());
            Assert.Equal("", match.RemainingText());
        }

        [Fact]
        public void Match_TheValueIsFalse_ShouldReturnSuccessAndTheRemaininText()
        {
            IMatch match = value.Match("false");

            Assert.True(match.Success());
            Assert.Equal("", match.RemainingText());
        }

        [Theory]
        [InlineData("0", true, "")]
        [InlineData("-15", true, "")]
        [InlineData("22.51", true, "")]
        [InlineData("1.2E6", true, "")]
        public void Match_TheValueIsANumber_ShouldReturnSuccessAndTheRemaininText(
            string number, bool expectedSuccess, string expectedRemainingText)
        {
            IMatch match = value.Match(number);

            Assert.Equal(expectedSuccess, match.Success());
            Assert.Equal(expectedRemainingText, match.RemainingText());
        }

        [Fact]
        public void Match_TheValueIsAString_ShouldReturnSuccessAndTheRemaininText()
        {
            IMatch match = value.Match("\"I am a string\"");

            Assert.True(match.Success());
            Assert.Equal("", match.RemainingText());
        }

        [Theory]
        [InlineData("[]", true, "")]
        [InlineData("[1]", true, "")]
        [InlineData("[1,2,3]", true, "")]
        [InlineData("[\"a\",\"b\",\"c\"]", true, "")]
        public void Match_TheValueIsAnArray_ShouldReturnSuccessAndTheRemaininText(
            string array, bool expectedSuccess, string expectedRemainingText)
        {
            IMatch match = value.Match(array);

            Assert.Equal(expectedSuccess, match.Success());
            Assert.Equal(expectedRemainingText, match.RemainingText());
        }

        [Theory]
        [InlineData("{}", true, "")]
        [InlineData("{\"age\": 23}", true, "")]
        [InlineData("{\"age\": 23, \"name\": \"Dan\"}", true, "")]
        public void Match_TheValueIsAnObject_ShouldReturnSuccessAndTheRemaininText(
            string obj, bool expectedSuccess, string expectedRemainingText)
        {
            IMatch match = value.Match(obj);

            Assert.Equal(expectedSuccess, match.Success());
            Assert.Equal(expectedRemainingText, match.RemainingText());
        }

        [Theory]
        [InlineData("23", true, "")]
        [InlineData(" 23 ", true, "")]
        [InlineData(" 23", true, "")]
        [InlineData("23 ", true, "")]
        [InlineData("23\t ", true, "")]
        [InlineData("\t23", true, "")]
        [InlineData("\t23\t", true, "")]
        [InlineData("23\r ", true, "")]
        [InlineData("\r23", true, "")]
        [InlineData("\r23\r", true, "")]
        [InlineData("23\n ", true, "")]
        [InlineData("\n23", true, "")]
        [InlineData("\n23\n", true, "")]
        public void Match_TheValueHasWhitespacesAtTheBeginningAndAtTheEnd_ShouldReturnSuccessAndTheRemainingText(
            string val, bool expectedSuccess, string expectedRemainingText)
        {
            IMatch match = value.Match(val);

            Assert.Equal(expectedSuccess, match.Success());
            Assert.Equal(expectedRemainingText, match.RemainingText());
        }
    }
}

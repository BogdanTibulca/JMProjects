using Xunit;

namespace JSONFormat.Tests
{
    public class ListTests
    {
        private readonly List a = new List(
            new Range('0', '9'),
            new Character(',')
            );

        [Theory]
        [InlineData("", true, "")]
        [InlineData(null, true, null)]
        [InlineData("1,2,3", true, "")]
        [InlineData("1,2,3,", true, ",")]
        [InlineData("1a", true, "a")]
        [InlineData("abc", true, "abc")]
        public void Match_SimpleElementAndSeparatorReceived_ShouldReturnSuccessAndTheRemaininTextAfterApplyingThePattern(
            string text, bool expectedSuccess, string expectedRemainingText)
        {
            IMatch match = a.Match(text);

            Assert.Equal(expectedSuccess, match.Success());
            Assert.Equal(expectedRemainingText, match.RemainingText());
        }

        [Theory]
        [InlineData("1; 22  ;\n 333 \t; 22", true, "")]
        [InlineData("1 \n;", true, " \n;")]
        [InlineData("abc", true, "abc")]
        public void Match_ComplexSeparatorReceived_ShouldReturnSuccessAndTheRemaininTextAfterApplyingThePattern(
            string text, bool expectedSuccess, string expectedRemainingText)
        {
            OneOrMore digits = new OneOrMore(new Range('0', '9'));
            Many whitespace = new Many(new Any(" \r\n\t"));
            Sequence separator = new Sequence(whitespace, new Character(';'), whitespace);
            List list = new List(digits, separator);

            IMatch match = list.Match(text);

            Assert.Equal(expectedSuccess, match.Success());
            Assert.Equal(expectedRemainingText, match.RemainingText());
        }
    }
}

using Xunit;

namespace JSONFormat.Tests
{
    public class SequenceTests
    {
        Sequence ab = new Sequence(
            new Character('a'),
            new Character('b')
            );

        [Theory]
        [InlineData("", false, "")]
        [InlineData(null, false, null)]
        [InlineData("abcd", true, "cd")]
        [InlineData("ax", false, "ax")]
        [InlineData("def", false, "def")]
        public void Match_SimplePatternReceived_ShouldReturnCorrectSuccessAndRemainingTextValues(
                            string text, bool expectedSuccess, string expectedRemainingText)
        {
            IMatch result = ab.Match(text);

            Assert.Equal(expectedSuccess, result.Success());
            Assert.Equal(expectedRemainingText, result.RemainingText());
        }

        Sequence abc = new Sequence(
            ab,
            new Character('c')
            );

        [Theory]
        [InlineData("", false, "")]
        [InlineData(null, false, null)]
        [InlineData("abc", true, "")]
        [InlineData("abcd", true, "d")]
        [InlineData("abx", false, "abx")]
        [InlineData("def", false, "def")]
        public void Match_MoreComplexPatternReceived_ShouldReturnCorrectSuccessAndRemainingTextValues(
                    string text, bool expectedSuccess, string expectedRemainingText)
        {
            IMatch result = abc.Match(text);

            Assert.Equal(expectedSuccess, result.Success());
            Assert.Equal(expectedRemainingText, result.RemainingText());
        }

        Choice hex = new Choice(
            new Range('0', '9'),
            new Range('a', 'f'),
            new Range('A', 'F')
            );

        Sequence hexSeq = new Sequence(
            new Character('u'),
            new Sequence(
                hex,
                hex,
                hex,
                hex
                )
            );

        [Theory]
        [InlineData("", false, "")]
        [InlineData(null, false, null)]
        [InlineData("u1234", true, "")]
        [InlineData("uabcdef", true, "ef")]
        [InlineData("uB005 ab", true, " ab")]
        [InlineData("abc", false, "abc")]
        public void Match_PatternsOfDifferentTypesReceived_ShouldReturnCorrectSuccessAndRemainingTextValues(
                    string text, bool expectedSuccess, string expectedRemainingText)
        {
            IMatch result = abc.Match(text);

            Assert.Equal(expectedSuccess, result.Success());
            Assert.Equal(expectedRemainingText, result.RemainingText());
        }
    }
}

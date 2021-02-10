namespace JSONFormat
{
    public class PrefixedText : IPattern
    {
        private readonly string prefix;

        public PrefixedText(string prefix)
        {
            this.prefix = prefix;
        }

        public IMatch Match(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new Match(false, text);
            }

            return text.IndexOf(prefix) == 0 ?
                new Match(true, text.Substring(prefix.Length)) :
                new Match(false, text);
        }
    }
}

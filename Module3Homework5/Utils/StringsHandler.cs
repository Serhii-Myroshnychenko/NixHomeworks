namespace Module3Homework5.Utils
{
    public static class StringsHandler
    {
        public static async Task<string> ConcatTwoStrings(Func<Task<string>> getHelloFromFile, Func<Task<string>> getWorldFromFile)
        {
            var arrayOfResultStrings = await Task.WhenAll(getHelloFromFile(), getWorldFromFile());
            var resultString = string.Empty;
            foreach (var str in arrayOfResultStrings)
            {
                resultString += str;
            }

            return resultString;
        }
    }
}

namespace Module3Homework2.Utils
{
    public static class WordsHandler
    {
        public static bool IsEnglishWord(string word)
        {
            var wordInLowerCase = word.ToLower();
            if (wordInLowerCase[0] >= 'a' && wordInLowerCase[0] <= 'z')
            {
                return true;
            }

            return false;
        }

        public static bool IsFirstLetterInWordDigit(string word)
        {
            return char.IsDigit(char.Parse(word[0].ToString()));
        }
    }
}

using System;
namespace FPOW.Droid
{
    public enum Locales
    {
        English,
        Russian,
        Spain
    }
    public static class GameHelper
    {
        public static string[] GetAlphabet(Locales locale)
        {
            switch (locale)
            {
                case Locales.English:
                    return new[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L",
                                   "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
                case Locales.Russian:
                    return new[] { "А", "Б", "В", "Г", "Д", "Е", "Ж", "З", "И", "Й", "К", "Л",
                                   "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц", "Ч", "Ш", "Щ",
                                   "Ъ", "Ы", "Ь", "Э", "Ю", "Я"};
                case Locales.Spain:
                    return new[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L",
                                   "M", "N", "Ñ", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
                default:
                    return new[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L",
                                   "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
            }
        }

        public static char[] GetLettersString(string word, Locales locale)
        {
            var tempStr = word;
            var rand = new Random();
            var alphabet = GetAlphabet(locale);

            for (var i = 0; i < (16 - word.Length); i++)
            {
                var letter = alphabet[rand.Next(0, alphabet.Length)];
                tempStr += letter;
            }

            var result = tempStr.ToCharArray();

            for (var i = result.Length-1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);
                // обменять значения result[j] и result[i]
                var temp = result[j];
                result[j] = result[i];
                result[i] = temp;
            }

            return result;
        }
    }
}
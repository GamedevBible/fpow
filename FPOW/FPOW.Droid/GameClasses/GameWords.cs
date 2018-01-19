namespace FPOW.Droid.GameClasses
{
    internal static class GameWords
    {
        public static string GetEnglishWord(int level)
        {
            switch (level)
            {
                case 1:
                    return "Hello";
                case 2:
                    return "Buy";
                default:
                    return string.Empty;
            }
        }

        public static string GetRussianWord(int level)
        {
            switch (level)
            {
                case 1:
                    return "Привет";
                case 2:
                    return "Пока";
                default:
                    return string.Empty;
            }
        }

        public static string GetSpanishWord(int level)
        {
            switch (level)
            {
                case 1:
                    return "Hola";
                case 2:
                    return "Buybuy";
                default:
                    return string.Empty;
            }
        }
    }
}
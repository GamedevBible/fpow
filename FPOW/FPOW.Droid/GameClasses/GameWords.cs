namespace FPOW.Droid.GameClasses
{
    internal static class GameWords
    {
        public static string GetEnglishWord(int level)
        {
            switch (level)
            {
                case 1:
                    return "First";
                case 2:
                    return "Second";
                case 3:
                    return "Third";
                case 4:
                    return "Fourth";
                default:
                    return string.Empty;
            }
        }

        public static string GetRussianWord(int level)
        {
            switch (level)
            {
                case 1:
                    return "�����";
                case 2:
                    return "�������";
                case 3:
                    return "���";
                case 4:
                    return "�����";
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
                case 3:
                    return "Treee";
                case 4:
                    return "Rewwq";
                default:
                    return string.Empty;
            }
        }
    }
}
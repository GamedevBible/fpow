namespace FPOW.Droid.GameClasses
{
    internal static class GameWords
    {
        private static string[] _russianWordsAfter100 =>
            new[] {
            "Храм",
            "Огонь",
            "Мошки",
            "Вера",
            "Девора",
            "Израиль",
            "Зерно",
            "Валаам",
            "Савл",
            "Отец",
            "Плевелы",
            "Сестры",
            "Сила",
            "Захария",
            "Авигея",
            "Жара",
            "Елисей",
            "Смерть",
            "Сарра",
            "Пшеница",
            "Фамарь",
            "Крылья",
            "Иеффрай",
            "Народ",
            "Каиафа",
            "Кровь",
            "Авимелех",
            "Борьба",
            "Мария",
            "Суббота",
            "Марфа",
            "Встреча",
            "Голиаф",
            "Лаван",
            "Венец",
            "Гедеон",
            "Пророк",
            "Слава",
            "Самуил",
            "Евреи",
            "Вирсавия",
            "Гора",
            "Левиафан",
            "Новый",
            "Ровоам",
            "Жабы",
            "Братья",
            "Лот",
            "Надежда",
            "Лия",
            "Иезавель"
        };

        private static string[] _englishWordsAfter100 =>
            new[] {
            "Church",
            "Fire",
            "Midges",
            "Faith",
            "Deborah",
            "Israel",
            "Corn",
            "Balaam",
            "Saul",
            "Father",
            "Plants",
            "Sisters",
            "Force",
            "Zechariah",
            "Abigail",
            "Heat",
            "Elisha",
            "Death",
            "Sarah",
            "Wheat",
            "Tamar",
            "Wings",
            "Jephthah",
            "People",
            "Caiaphas",
            "Blood",
            "Abimelech",
            "Struggle",
            "Mary",
            "Saturday",
            "Martha",
            "Greeting",
            "Goliath",
            "Laban",
            "Crown",
            "Gideon",
            "Prophet",
            "Fame",
            "Samuel",
            "Hebrews",
            "Beersheba",
            "Mountain",
            "Leviathan",
            "New",
            "Rehoboam",
            "Toads",
            "Brothers",
            "Lot",
            "Hope",
            "Leah",
            "Jezebel"
        };

        private static string[] _spanishWordsAfter100 =>
            new[] {
            "Templo",
            "Fuego",
            "Mosquitos",
            "Fe",
            "Debora",
            "Israel",
            "Grano",
            "Balaam",
            "Saulo",
            "Padre",
            "Cizana",
            "Hermanas",
            "Poder",
            "Zacharias",
            "Abigail",
            "Calentar",
            "Eliseo",
            "Muerte",
            "Sara",
            "Trigo",
            "Thamar",
            "Alas",
            "Jephté",
            "Gente",
            "Caifás",
            "Sangre",
            "Abimelech",
            "Pelea",
            "María",
            "Sabado",
            "Marta",
            "Reunion",
            "Goliath",
            "Labán",
            "Corona",
            "Gedeón",
            "Profeta",
            "Fama",
            "Samuel",
            "Hebreos)",
            "Beerseba",
            "Montana",
            "leviathán",
            "Nuevo",
            "Roboam",
            "Sapos",
            "Hermanos",
            "Lot",
            "Esperanza",
            "Lea",
            "Jezabel"
        };

        public static string GetEnglishWord(int level)
        {
            if (level > 100 && _englishWordsAfter100.Length > level - 101)
                return _englishWordsAfter100[level - 101];

            switch (level)
            {
                case 1:
                    return "Water";
                case 2:
                    return "Flowers";
                case 3:
                    return "White";
                case 4:
                    return "Sleep";
                case 5:
                    return "Candle";
                case 6:
                    return "Fish";
                case 7:
                    return "Morning";
                case 8:
                    return "Part";
                case 9:
                    return "Height";
                case 10:
                    return "Night";
                case 11:
                    return "Tail";
                case 12:
                    return "Genesis";
                case 13:
                    return "Day";
                case 14:
                    return "Light";
                case 15:
                    return "Abel";
                case 16:
                    return "Rain";
                case 17:
                    return "Flood";
                case 18:
                    return "Forgive";
                case 19:
                    return "Animals";
                case 20:
                    return "David";
                case 21:
                    return "Eve";
                case 22:
                    return "Sky";
                case 23:
                    return "Clothes";
                case 24:
                    return "Talent";
                case 25:
                    return "Jonah";
                case 26:
                    return "Cry";
                case 27:
                    return "Esau";
                case 28:
                    return "Mud";
                case 29:
                    return "Chiton";
                case 30:
                    return "Fisher";
                case 31:
                    return "Past";
                case 32:
                    return "Rainbow";
                case 33:
                    return "Anger";
                case 34:
                    return "Service";
                case 35:
                    return "Pharisees";
                case 36:
                    return "Purple";
                case 37:
                    return "Pilate";
                case 38:
                    return "Joy";
                case 39:
                    return "Tempt";
                case 40:
                    return "Heavy";
                case 41:
                    return "Generous";
                case 42:
                    return "Music";
                case 43:
                    return "Sand";
                case 44:
                    return "Nineveh";
                case 45:
                    return "Birds";
                case 46:
                    return "Priest";
                case 47:
                    return "Hunting";
                case 48:
                    return "Parable";
                case 49:
                    return "Season";
                case 50:
                    return "Easter";
                case 51:
                    return "Teach";
                case 52:
                    return "Ark";
                case 53:
                    return "Cross";
                case 54:
                    return "Soup";
                case 55:
                    return "Herbs";
                case 56:
                    return "Rachel";
                case 57:
                    return "Hagar";
                case 58:
                    return "Salvation";
                case 59:
                    return "Throng";
                case 60:
                    return "Fall";
                case 61:
                    return "Esther";
                case 62:
                    return "Singing";
                case 63:
                    return "Miracle";
                case 64:
                    return "Ruth";
                case 65:
                    return "Evening";
                case 66:
                    return "Wealth";
                case 67:
                    return "Egypt";
                case 68:
                    return "Future";
                case 69:
                    return "Bethlehem";
                case 70:
                    return "Adam";
                case 71:
                    return "Samson";
                case 72:
                    return "Орехи";
                case 73:
                    return "Nuts";
                case 74:
                    return "Light";
                case 75:
                    return "Jacob";
                case 76:
                    return "Feast";
                case 77:
                    return "Peter";
                case 78:
                    return "Island";
                case 79:
                    return "Solomon";
                case 80:
                    return "Jordan";
                case 81:
                    return "Judas";
                case 82:
                    return "Catching";
                case 83:
                    return "Shrine";
                case 84:
                    return "Exodus";
                case 85:
                    return "Collect";
                case 86:
                    return "John";
                case 87:
                    return "Zacchaeus";
                case 88:
                    return "Sodom";
                case 89:
                    return "Joseph";
                case 90:
                    return "Covenant";
                case 91:
                    return "Trees";
                case 92:
                    return "Moses";
                case 93:
                    return "Jerusalem";
                case 94:
                    return "Paul";
                case 95:
                    return "Gift";
                case 96:
                    return "Law";
                case 97:
                    return "Daniel";
                case 98:
                    return "Lucifer";
                case 99:
                    return "Saul";
                case 100:
                    return "Love";
                default:
                    return string.Empty;
            }
        }

        public static string GetRussianWord(int level)
        {
            if (level > 100 && _russianWordsAfter100.Length > level - 101)
                return _russianWordsAfter100[level - 101];
            
            switch (level)
            {
                case 1:
                    return "Вода";
                case 2:
                    return "Цветы";
                case 3:
                    return "Белый";
                case 4:
                    return "Сон";
                case 5:
                    return "Свеча";
                case 6:
                    return "Рыбы";
                case 7:
                    return "Утро";
                case 8:
                    return "Часть";
                case 9:
                    return "Высота";
                case 10:
                    return "Ночь";
                case 11:
                    return "Хвост";
                case 12:
                    return "Бытие";
                case 13:
                    return "День";
                case 14:
                    return "Свет";
                case 15:
                    return "Авель";
                case 16:
                    return "Дождь";
                case 17:
                    return "Потоп";
                case 18:
                    return "Прощение";
                case 19:
                    return "Животные";
                case 20:
                    return "Давид";
                case 21:
                    return "Ева";
                case 22:
                    return "Небо";
                case 23:
                    return "Одежда";
                case 24:
                    return "Таланты";
                case 25:
                    return "Иона";
                case 26:
                    return "Плач";
                case 27:
                    return "Исав";
                case 28:
                    return "Грязь";
                case 29:
                    return "Хитон";
                case 30:
                    return "Рыбаки";
                case 31:
                    return "Прошлое";
                case 32:
                    return "Радуга";
                case 33:
                    return "Гнев";
                case 34:
                    return "Служение";
                case 35:
                    return "Фарисеи";
                case 36:
                    return "Пурпур";
                case 37:
                    return "Пилат";
                case 38:
                    return "Радость";
                case 39:
                    return "Искушение";
                case 40:
                    return "Тяжелый";
                case 41:
                    return "Щедрость";
                case 42:
                    return "Музыка";
                case 43:
                    return "Песок";
                case 44:
                    return "Ниневия";
                case 45:
                    return "Птицы";
                case 46:
                    return "Священник";
                case 47:
                    return "Охота";
                case 48:
                    return "Притча";
                case 49:
                    return "Сезон";
                case 50:
                    return "Пасха";
                case 51:
                    return "Учить";
                case 52:
                    return "Ковчег";
                case 53:
                    return "Крест";
                case 54:
                    return "Похлебка";
                case 55:
                    return "Травы";
                case 56:
                    return "Рахиль";
                case 57:
                    return "Агарь";
                case 58:
                    return "Спасение";
                case 59:
                    return "Толпа";
                case 60:
                    return "Падение";
                case 61:
                    return "Есфирь";
                case 62:
                    return "Пение";
                case 63:
                    return "Чудо";
                case 64:
                    return "Руфь";
                case 65:
                    return "Вечер";
                case 66:
                    return "Богатство";
                case 67:
                    return "Египет";
                case 68:
                    return "Будущее";
                case 69:
                    return "Вифлеем";
                case 70:
                    return "Адам";
                case 71:
                    return "Самсон";
                case 72:
                    return "Орехи";
                case 73:
                    return "Илия";
                case 74:
                    return "Легкий";
                case 75:
                    return "Иаков";
                case 76:
                    return "Пир";
                case 77:
                    return "Петр";
                case 78:
                    return "Остров";
                case 79:
                    return "Соломон";
                case 80:
                    return "Иордан";
                case 81:
                    return "Иуда";
                case 82:
                    return "Ловля";
                case 83:
                    return "Святыня";
                case 84:
                    return "Исход";
                case 85:
                    return "Собирать";
                case 86:
                    return "Иоанн";
                case 87:
                    return "Закхей";
                case 88:
                    return "Содом";
                case 89:
                    return "Иосиф";
                case 90:
                    return "Завет";
                case 91:
                    return "Деревья";
                case 92:
                    return "Моисей";
                case 93:
                    return "Иерусалим";
                case 94:
                    return "Павел";
                case 95:
                    return "Подарок";
                case 96:
                    return "Закон";
                case 97:
                    return "Даниил";
                case 98:
                    return "Люцифер";
                case 99:
                    return "Саул";
                case 100:
                    return "Любовь";
                default:
                    return string.Empty;
            }
        }

        public static string GetSpanishWord(int level)
        {
            if (level > 100 && _spanishWordsAfter100.Length > level - 101)
                return _spanishWordsAfter100[level - 101];

            switch (level)
            {
                case 1:
                    return "Agua";
                case 2:
                    return "Flores";
                case 3:
                    return "Blanco";
                case 4:
                    return "Sueño";
                case 5:
                    return "Vela";
                case 6:
                    return "Pescado";
                case 7:
                    return "Mañana";
                case 8:
                    return "Parte";
                case 9:
                    return "Altura";
                case 10:
                    return "Noche";
                case 11:
                    return "Cola";
                case 12:
                    return "Génesis";
                case 13:
                    return "Día";
                case 14:
                    return "Luz";
                case 15:
                    return "Abel";
                case 16:
                    return "Lluvia";
                case 17:
                    return "Diluvio";
                case 18:
                    return "Perdón";
                case 19:
                    return "Animales";
                case 20:
                    return "David";
                case 21:
                    return "Eva";
                case 22:
                    return "Cielo";
                case 23:
                    return "Ropa";
                case 24:
                    return "Talentos";
                case 25:
                    return "Jonás";
                case 26:
                    return "Llorando";
                case 27:
                    return "Esaú";
                case 28:
                    return "Barro";
                case 29:
                    return "Heaton";
                case 30:
                    return "Pescador";
                case 31:
                    return "Pasado";
                case 32:
                    return "Rainbow";
                case 33:
                    return "Ira";
                case 34:
                    return "Servicio";
                case 35:
                    return "Fariseos";
                case 36:
                    return "Púrpura";
                case 37:
                    return "Pilato";
                case 38:
                    return "Alegría";
                case 39:
                    return "Tentación";
                case 40:
                    return "Pesado";
                case 41:
                    return "Generoso";
                case 42:
                    return "Música";
                case 43:
                    return "Arena";
                case 44:
                    return "Nínive";
                case 45:
                    return "Aves";
                case 46:
                    return "Sacerdote";
                case 47:
                    return "Caza";
                case 48:
                    return "Parábola";
                case 49:
                    return "Temporada";
                case 50:
                    return "Pascua";
                case 51:
                    return "Aprende";
                case 52:
                    return "Arca";
                case 53:
                    return "Cruz";
                case 54:
                    return "Chowder";
                case 55:
                    return "Hierbas";
                case 56:
                    return "Rachel";
                case 57:
                    return "Agar";
                case 58:
                    return "Salvación";
                case 59:
                    return "Multitud";
                case 60:
                    return "Cayendo";
                case 61:
                    return "Esther";
                case 62:
                    return "Cantando";
                case 63:
                    return "Milagro";
                case 64:
                    return "Ruth";
                case 65:
                    return "Noche";
                case 66:
                    return "Riqueza";
                case 67:
                    return "Egipto";
                case 68:
                    return "Futuro";
                case 69:
                    return "Belén";
                case 70:
                    return "Adam";
                case 71:
                    return "Samson";
                case 72:
                    return "Nueces";
                case 73:
                    return "Elijah";
                case 74:
                    return "Ligero";
                case 75:
                    return "Jacob";
                case 76:
                    return "Fiesta";
                case 77:
                    return "Peter";
                case 78:
                    return "Isla";
                case 79:
                    return "Solomon";
                case 80:
                    return "Jordania";
                case 81:
                    return "Judá";
                case 82:
                    return "Atrapando";
                case 83:
                    return "Santuario";
                case 84:
                    return "Resultado";
                case 85:
                    return "Recoge";
                case 86:
                    return "John";
                case 87:
                    return "Zaqueo";
                case 88:
                    return "Sodoma";
                case 89:
                    return "Joseph";
                case 90:
                    return "Pacto";
                case 91:
                    return "Árboles";
                case 92:
                    return "Moisés";
                case 93:
                    return "Jerusalem";
                case 94:
                    return "Paul";
                case 95:
                    return "Regalo";
                case 96:
                    return "Ley";
                case 97:
                    return "Daniel";
                case 98:
                    return "Lucifer";
                case 99:
                    return "Saúl";
                case 100:
                    return "Amor";
                default:
                    return string.Empty;
            }
        }
    }
}
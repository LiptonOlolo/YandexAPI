namespace YandexAPI.SpeechKitCloud.ASR
{
    /// <summary>
    /// Формат аудио данных
    /// </summary>
    public class AudioFormat
    {
        private AudioFormat(string format) => this.format = format;

        /// <summary>
        /// Формат аудон.
        /// </summary>
        public readonly string format;

        /// <summary>
        /// Медиаконтейнер WAV может содержать аудио данные любого формата, например PCM.
        /// </summary>
        public static AudioFormat WAV = new AudioFormat("audio/x-wav");

        /// <summary>
        /// MPEG-1 Audio Layer 3 (MP3).
        /// </summary>
        public static AudioFormat MP3 = new AudioFormat("audio/x-mpeg-3");

        /// <summary>
        /// Speex.
        /// </summary>
        public static AudioFormat OGG = new AudioFormat("audio/x-speex");

        /// <summary>
        /// Opus.
        /// </summary>
        public static AudioFormat OGGOpus = new AudioFormat("audio/ogg;codecs=opus");

        /// <summary>
        /// Opus.
        /// </summary>
        public static AudioFormat WebM = new AudioFormat("audio/webm;codecs=opus");

        /// <summary>
        /// Linear PCM c частотой дискретизации 16000 Гц и разрядностью квантования 16 бит.
        /// </summary>
        public static AudioFormat PCM16Bit16kRate = new AudioFormat("audio/x-pcm;bit=16;rate=16000");

        /// <summary>
        /// Linear PCM c частотой дискретизации 8000 Гц и разрядностью квантования 16 бит.
        /// </summary>
        public static AudioFormat PCM16Bit8kRate = new AudioFormat("audio/x-pcm;bit=16;rate=8000");

        /// <summary>
        /// PCM на основе A-law. Частота дискретизации 8000 Гц, разрядность квантования 13 бит.
        /// </summary>
        public static AudioFormat PCM13Bit8kRate = new AudioFormat("audio/x-alaw;bit=13;rate=8000");
    }

    /// <summary>
    /// Языковая модель.
    /// </summary>
    public class Topic
    {
        private Topic(string model) => this.model = model;

        /// <summary>
        /// Языковая модель.
        /// </summary>
        public readonly string model;

        /// <summary>
        /// Короткие запросы — фразы (3—5 слов) на различные темы, в том числе запросы в поисковых системах (на сайтах).
        /// Например:
        /// [покажи следующий поворот]
        /// [соединить с отделом продаж]
        /// [еще чашку кофе и две мягких французских булочки]
        /// [какая погода во владивостоке]
        /// [напомни купить овощей и фруктов по дороге домой]
        /// </summary>
        public static Topic Queries = new Topic("queries");

        /// <summary>
        /// Адреса (maps) — адреса, названия организаций и географических объектов.
        /// Например:
        /// [поехали на улицу кирпичные выемки пять]
        /// [сколько ехать от льва толстого до новой земли]
        /// [покажи маршрут до музея маяковского]
        /// </summary>
        public static Topic Maps = new Topic("maps");

        /// <summary>
        /// Даты (dates) — названия месяцев, порядковые и количественные числительные.
        /// Например:
        /// [второго ноль седьмого две тысячи первого]
        /// [двадцать седьмое апреля тысяча девятьсот девятнадцатого года]
        /// </summary>
        public static Topic Dates = new Topic("dates");

        /// <summary>
        /// Имена (names) — имена и фамилии, просьбы соединить по телефону. Например:
        /// [щукин платон]
        /// [соедините с людчиком]
        /// [переговорить с васей васиным]
        /// </summary>
        public static Topic Names = new Topic("names");

        /// <summary>
        /// Числа (numbers) — количественные числительные от 1 до 999 и разделители — точка, запятая, тире. Модель подходит для диктовки номеров телефонов, счетов, документов.
        /// Например:
        /// [два двенадцать восемьдесят пять ноль шесть]
        /// [сто пятьдесят семь запятая пятнадцать сорок три]
        /// </summary>
        public static Topic Numbers = new Topic("numbers");

        /// <summary>
        /// Музыка (music) — названия музыкальных произведений и исполнителей. Модель не предназначена для распознавания музыкальных фрагментов. Подходит только для распознавания названий, имен авторов и исполнителей песен.
        /// Например:
        /// [третий концерт рахманинова для фортепиано с оркестром]
        /// [алла пугачева любовь похожая на сон]
        /// </summary>
        public static Topic Music = new Topic("music");

        /// <summary>
        /// Заказы (buying) — фразы, связанные с оформлением заказов в интернет-магазинах (подтверждение заказа и форма доставки).
        /// Например:
        /// [верно хочу купить]
        /// </summary>
        public static Topic Buying = new Topic("buying");
    }
}

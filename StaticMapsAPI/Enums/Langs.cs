namespace YandexAPI.StaticMapsAPI.Enums
{
    /// <summary>
    /// Язык карты.
    /// </summary>
    public sealed class Langs
    {
        private Langs(string lang) => Lang = lang;

        /// <summary>
        /// Язык карты.
        /// </summary>
        public string Lang { get; }

        /// <summary>
        /// RuRu.
        /// </summary>
        public static Langs RuRu = new Langs("ru_RU");

        /// <summary>
        /// EnUs.
        /// </summary>
        public static Langs EnUs = new Langs("en_US");

        /// <summary>
        /// EnRu.
        /// </summary>
        public static Langs EnRu = new Langs("en_RU");

        /// <summary>
        /// RuUa.
        /// </summary>
        public static Langs RuUa = new Langs("ru_UA");

        /// <summary>
        /// UkUa.
        /// </summary>
        public static Langs UkUa = new Langs("uk_UA");

        /// <summary>
        /// TrTr.
        /// </summary>
        public static Langs TrTr = new Langs("tr_TR");
    }
}

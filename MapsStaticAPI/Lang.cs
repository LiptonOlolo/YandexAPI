namespace YandexAPI.MapsStaticAPI
{
    /// <summary>
    /// Язык карты.
    /// </summary>
    public sealed class Lang
    {
        private Lang(string lang) => this.lang = lang;

        /// <summary>
        /// Язык карты.
        /// </summary>
        public readonly string lang;

        /// <summary>
        /// RuRu.
        /// </summary>
        public static Lang RuRu = new Lang("ru-RU");

        /// <summary>
        /// EnUs.
        /// </summary>
        public static Lang EnUs = new Lang("en_US");

        /// <summary>
        /// EnRu.
        /// </summary>
        public static Lang EnRu = new Lang("en_RU");

        /// <summary>
        /// RuUa.
        /// </summary>
        public static Lang RuUa = new Lang("ru_UA");

        /// <summary>
        /// UkUa.
        /// </summary>
        public static Lang UkUa = new Lang("uk_UA");

        /// <summary>
        /// TrTr.
        /// </summary>
        public static Lang TrTr = new Lang("tr_TR");
    }
}

namespace YandexAPI.SpeechKitCloud
{
    /// <summary>
    /// Язык, для которого будет выполнено распознавание.
    /// </summary>
    public class Lang
    {
        private Lang(string lang) => this.lang = lang;

        /// <summary>
        /// Язык синтеза речи.
        /// </summary>
        public readonly string lang;

        /// <summary>
        /// Русский язык.
        /// </summary>
        public static Lang Ru = new Lang("ru-RU");

        /// <summary>
        /// Английский язык.
        /// </summary>
        public static Lang En = new Lang("en-US");

        /// <summary>
        /// Украинский язык.
        /// </summary>
        public static Lang Uk = new Lang("uk-UK");

        /// <summary>
        /// Турецкий язык.
        /// </summary>
        public static Lang Tr = new Lang("tr-TR");
    }
}

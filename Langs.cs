namespace YandexAPI
{
    /// <summary>
    /// Язык.
    /// </summary>
    public sealed class Langs
    {
        private Langs(string lang) => Lang = lang;

        /// <summary>
        /// Выбранный язык.
        /// </summary>
        public string Lang { get; }

        /// <summary>
        /// Русский язык.
        /// </summary>
        public static Langs Ru = new Langs("ru-RU");

        /// <summary>
        /// Английский язык.
        /// </summary>
        public static Langs En = new Langs("en-US");

        /// <summary>
        /// Украинский язык.
        /// </summary>
        public static Langs Uk = new Langs("uk-UK");

        /// <summary>
        /// Туреций язык.
        /// </summary>
        public static Langs Tr = new Langs("tr-TR");
    }
}

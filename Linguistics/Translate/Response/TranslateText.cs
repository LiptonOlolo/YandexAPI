namespace YandexAPI.Linguistics.Translate.Response
{
    public class TranslateText
    {
        /// <summary>
        /// Код ответа.
        /// </summary>
        public short code;

        /// <summary>
        /// Язык перевода. Либо пара языков.
        /// </summary>
        public string lang;

        /// <summary>
        /// Переведенный текст.
        /// </summary>
        public string[] text;
    }
}

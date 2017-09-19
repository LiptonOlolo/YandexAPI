using Newtonsoft.Json;

namespace YandexAPI.Linguistics.Translate.Responses
{
    /// <summary>
    /// Результат перевода текста.
    /// </summary>
    public sealed class TranslateText : Error
    {
        /// <summary>
        /// Язык с которого переведен текст (Пример: en-ru, значит, что текст переведен с Английского языка на Русский).
        /// </summary>
        [JsonProperty("lang")]
        public string Lang { get; private set; }

        /// <summary>
        /// Переведенный текст.
        /// </summary>
        [JsonProperty("text")]
        public string[] Text { get; private set; }
    }
}

using Newtonsoft.Json;

namespace YandexAPI.Linguistics.Translate.Responses
{
    /// <summary>
    /// Определение языка.
    /// </summary>
    public sealed class DetectLang : Error
    {
        /// <summary>
        /// Язык, на котором был написан текст.
        /// </summary>
        [JsonProperty("lang")]
        public string Lang { get; private set; }
    }
}

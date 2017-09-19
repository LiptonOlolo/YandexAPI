using Newtonsoft.Json;

namespace YandexAPI
{
    /// <summary>
    /// Информация об ошибке запроса.
    /// </summary>
    public class Error
    {
        /// <summary>
        /// Код ответа.
        /// </summary>
        [JsonProperty("code")]
        public short Code { get; private set; }

        /// <summary>
        /// Текст ошибки.
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; private set; }
    }
}

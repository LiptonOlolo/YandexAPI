using Newtonsoft.Json;

namespace YandexAPI.Linguistics.Speller.Responses
{
    /// <summary>
    /// Проверка текста на ошибки.
    /// </summary>
    public sealed class CheckText : Error
    {
        /// <summary>
        /// Позиция слова с ошибкой (отсчет от 0).
        /// </summary>
        [JsonProperty("pos")]
        public short Pos { get; private set; }

        /// <summary>
        /// Номер строки (отсчет от 0).
        /// </summary>
        [JsonProperty("row")]
        public short Row { get; private set; }

        /// <summary>
        /// Номер столбца (отсчет от 0).
        /// </summary>
        [JsonProperty("col")]
        public short Col { get; private set; }

        /// <summary>
        /// Длина слова с ошибкой.
        /// </summary>
        [JsonProperty("len")]
        public short Len { get; private set; }

        /// <summary>
        /// Исходное слово.
        /// </summary>
        [JsonProperty("word")]
        public string Word { get; private set; }

        /// <summary>
        /// Подсказка (может быть несколько или могут отсутствовать).
        /// </summary>
        [JsonProperty("s")]
        public string[] S { get; private set; }
    }
}

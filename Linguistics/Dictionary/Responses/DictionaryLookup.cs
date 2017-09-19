using Newtonsoft.Json;

namespace YandexAPI.Linguistics.Dictionary.Responses
{
    /// <summary>
    /// Автоматически сформированная словарная статья.
    /// </summary>
    public sealed class DictionaryLookup : Error
    {
        /// <summary>
        /// Массив словарных статей. В атрибуте ts может указываться транскрипция искомого слова.
        /// </summary>
        [JsonProperty("def")]
        public Def[] Def { get; set; }

        /// <summary>
        /// Заголовок результата (не используется).
        /// </summary>
        [JsonProperty("head")]
        public Head Head { get; set; }
    }

    /// <summary>
    /// Массив словарных статей. В атрибуте ts может указываться транскрипция искомого слова.
    /// </summary>
    public sealed class Def
    {
        /// <summary>
        /// Текст статьи, перевода или синонима (обязательный).
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// Часть речи (может отсутствовать).
        /// </summary>
        [JsonProperty("pos")]
        public string Pos { get; set; }

        /// <summary>
        /// Массив переводов.
        /// </summary>
        [JsonProperty("tr")]
        public Tr[] Tr { get; set; }
    }

    /// <summary>
    /// Массив переводов.
    /// </summary>
    public sealed class Tr
    {
        /// <summary>
        /// Массив значений.
        /// </summary>
        [JsonProperty("mean")]
        public Mean[] Mean { get; set; }

        /// <summary>
        /// Массив синонимов.
        /// </summary>
        [JsonProperty("syn")]
        public Mean[] Syn { get; set; }

        /// <summary>
        /// Массив примеров.
        /// </summary>
        [JsonProperty("ex")]
        public Ex[] Ex { get; set; }

        /// <summary>
        /// Часть речи (может отсутствовать).
        /// </summary>
        [JsonProperty("pos")]
        public string Pos { get; set; }

        /// <summary>
        /// Текст статьи, перевода или синонима (обязательный).
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }
    }

    /// <summary>
    /// Массив значений.
    /// </summary>
    public sealed class Mean
    {
        /// <summary>
        /// Текст статьи, перевода или синонима (обязательный).
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }
    }

    /// <summary>
    /// Массив примеров.
    /// </summary>
    public sealed class Ex
    {
        /// <summary>
        /// Текст статьи, перевода или синонима (обязательный).
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// Массив переводов.
        /// </summary>
        [JsonProperty("tr")]
        public Mean[] Tr { get; set; }
    }

    /// <summary>
    /// Заголовок результата (не используется).
    /// </summary>
    public sealed class Head
    {
    }
}

using Newtonsoft.Json;
using System.Collections.Generic;

namespace YandexAPI.Linguistics.Translate.Responses
{
    /// <summary>
    /// Получение списка языков для перевода.
    /// </summary>
    public sealed class GetLangs : Error
    {
        /// <summary>
        /// Возможные направления перевода.
        /// </summary>
        [JsonProperty("dirs")]
        public string[] Dirs { get; private set; }

        /// <summary>
        /// Список всех языков, которые поддерживаются переводчиком.
        /// </summary>
        [JsonProperty("langs")]
        public Dictionary<string, string> Langs { get; private set; }
    }
}

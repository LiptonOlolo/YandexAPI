using System.Collections.Generic;

namespace YandexAPI.Linguistics.Translate.Response
{
    public class GetLangs
    {
        /// <summary>
        /// Возможные направления перевода.
        /// </summary>
        public string[] dirs;

        /// <summary>
        /// Список всех языков, которые поддериживаются переводчиком.
        /// </summary>
        public Dictionary<string, string> langs;
    }
}

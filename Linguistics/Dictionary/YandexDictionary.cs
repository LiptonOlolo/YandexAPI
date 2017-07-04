using System.Collections.Specialized;
using System.Threading.Tasks;
using YandexAPI.Linguistics.Dictionary.Response;

namespace YandexAPI.Linguistics.Dictionary
{
    /// <summary>
    /// API Yandex Словаря.
    /// </summary>
    public sealed class YandexDictionary
    {
        const string API_GetLangs = Const.DictionaryAPI + "getLangs";
        const string API_lookup = Const.DictionaryAPI + "lookup";

        public YandexDictionary(string apiKey) => ApiKey = apiKey;

        /// <summary>
        /// Api ключ для словаря, начинается с 'dict'.
        /// </summary>
        public string ApiKey { get; private set; }

        /// <summary>
        /// Асинхронно возвращает список направлений перевода, поддерживаемых сервисом.
        /// </summary>
        /// <returns></returns>
        public async Task<string[]> GetLangsAsync() => await Task.Run(() => GetLangs());

        /// <summary>
        /// Осуществляет асинхронный поиск слова или фразы в словаре и возвращает автоматически сформированную словарную статью.
        /// </summary>
        /// <param name="lang">
        /// Направление перевода (например, "en-ru"). Задается в виде пары кодов языков, перечисленных через дефис. 
        /// Например, "en-ru" задает перевод с английского на русский.</param>
        /// <param name="text">Слово или фраза, которые требуется найти в словаре.</param>
        /// <returns></returns>
        public async Task<Lookup> LookupAsync(string lang, string text) => await Task.Run(() => Lookup(lang, text));

        /// <summary>
        /// Возвращает список направлений перевода, поддерживаемых сервисом.
        /// </summary>
        /// <returns></returns>
        public string[] GetLangs() => Web.Get<string[]>(API_GetLangs, new NameValueCollection(), ApiKey);

        /// <summary>
        /// Осуществляет поиск слова или фразы в словаре и возвращает автоматически сформированную словарную статью.
        /// </summary>
        /// <param name="lang">
        /// Направление перевода (например, "en-ru"). Задается в виде пары кодов языков, перечисленных через дефис. 
        /// Например, "en-ru" задает перевод с английского на русский.</param>
        /// <param name="text">Слово или фраза, которые требуется найти в словаре.</param>
        /// <returns></returns>
        public Lookup Lookup(string lang, string text) => Web.Get<Lookup>(API_lookup, new NameValueCollection
        {
            ["lang"] = lang,
            ["text"] = text
        }, ApiKey);
    }
}

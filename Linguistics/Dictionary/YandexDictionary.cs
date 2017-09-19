using System.Collections.Specialized;
using System.Threading.Tasks;
using YandexAPI.Linguistics.Dictionary.Responses;
using YandexAPI.WebHelper;

namespace YandexAPI.Linguistics.Dictionary
{
    /// <summary>
    /// API Yandex Словаря.
    /// </summary>
    public sealed class YandexDictionary
    {
        const string API_GetLangs = Consts.DictionaryAPI + "getLangs";
        const string API_lookup = Consts.DictionaryAPI + "lookup";

        /// <summary>
        /// API ключ переводчика.
        /// </summary>
        public string ApiKey { get; }

        /// <summary>
        /// Конструктор класса YandexDictionary.
        /// </summary>
        /// <param name="apiKey">API ключ переводчика.</param>
        public YandexDictionary(string apiKey) => ApiKey = apiKey;

        /// <summary>
        /// Возвращает список направлений перевода, поддерживаемых сервисом.
        /// </summary>
        /// <exception cref="YandexException">Ошибка запроса.</exception>
        /// <returns></returns>
        public string[] GetLangs() => Web.Get<string[]>(API_GetLangs, new NameValueCollection(), ApiKey);

        /// <summary>
        /// Асинхронно возвращает список направлений перевода, поддерживаемых сервисом.
        /// </summary>
        /// <exception cref="YandexException">Ошибка запроса.</exception>
        /// <returns></returns>
        public async Task<string[]> GetLangsAsync() => await Task.Run(() => GetLangs());

        /// <summary>
        /// Осуществляет поиск слова или фразы в словаре и возвращает автоматически сформированную словарную статью.
        /// </summary>
        /// <param name="lang">
        /// Направление перевода (например, "en-ru"). Задается в виде пары кодов языков, перечисленных через дефис. 
        /// Например, "en-ru" задает перевод с английского на русский.
        /// </param>
        /// <param name="text">Слово или фраза, которые требуется найти в словаре.</param>
        /// <param name="ui">
        /// Язык интерфейса пользователя, на котором будут отображаться названия частей речи в словарной статье.
        /// </param>
        /// <param name="flags">Опции поиска (битовая маска флагов).</param>
        /// <exception cref="YandexException">Ошибка запроса.</exception>
        /// <returns></returns>
        public DictionaryLookup GetDictionary(Langs lang, string text, string ui, DictionaryFlags flags = DictionaryFlags.None) => Web.Get<DictionaryLookup>(API_lookup, new NameValueCollection
        {
            ["lang"] = lang.Lang,
            ["text"] = text,
            ["ui"] = ui,
            ["flags"] = ((int)flags).ToString()
        }, ApiKey);

        /// <summary>
        /// Асинхронно осуществляет поиск слова или фразы в словаре и возвращает автоматически сформированную словарную статью.
        /// </summary>
        /// <param name="lang">
        /// Направление перевода (например, "en-ru"). Задается в виде пары кодов языков, перечисленных через дефис. 
        /// Например, "en-ru" задает перевод с английского на русский.
        /// </param>
        /// <param name="text">Слово или фраза, которые требуется найти в словаре.</param>
        /// <param name="ui">
        /// Язык интерфейса пользователя, на котором будут отображаться названия частей речи в словарной статье.
        /// </param>
        /// <param name="flags">Опции поиска (битовая маска флагов).</param>
        /// <exception cref="YandexException">Ошибка запроса.</exception>
        /// <returns></returns>
        public async Task<DictionaryLookup> GetDictionaryAsync(Langs lang, string text, string ui, DictionaryFlags flags = DictionaryFlags.None) =>
            await Task.Run(() => GetDictionary(lang, text, ui, flags));
    }
}

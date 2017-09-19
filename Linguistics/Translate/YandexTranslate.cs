using System.Collections.Specialized;
using System.Threading.Tasks;
using YandexAPI.Linguistics.Translate.Responses;
using YandexAPI.WebHelper;

namespace YandexAPI.Linguistics.Translate
{
    /// <summary>
    /// API Yandex Переводчика.
    /// </summary>
    public sealed class YandexTranslate
    {
        const string API_GetLangs = Consts.TranslateAPI + "getLangs";
        const string API_DetectLang = Consts.TranslateAPI + "detect";
        const string API_Translate = Consts.TranslateAPI + "translate";

        /// <summary>
        /// API ключ переводчика.
        /// </summary>
        public string ApiKey { get; }

        /// <summary>
        /// Конструктор класса YandexTranslate.
        /// </summary>
        /// <param name="apiKey">API ключ переводчика.</param>
        public YandexTranslate(string apiKey) => ApiKey = apiKey;

        /// <summary>
        /// Асинхронный перевод текста на заданный язык.
        /// </summary>
        /// <param name="text">Текст, который необходимо перевести.</param>
        /// <param name="lang">
        /// Направление перевода. Может задаваться одним из следующих способов:
        ///     1) В виде пары кодов языков («с какого»-«на какой»), разделенных дефисом. 
        ///         Например, en-ru обозначает перевод с английского на русский.
        ///     2) В виде кода конечного языка (например ru). 
        ///         В этом случае сервис пытается определить исходный язык автоматически.
        /// </param>
        /// <exception cref="YandexException">Ошибка запроса.</exception>
        /// <returns></returns>
        public async Task<TranslateText> TranslateAsync(string text, string lang) => await Task.Run(() => Translate(text, lang));

        /// <summary>
        /// Перевод текста на заданный язык.
        /// </summary>
        /// <param name="text">Текст, который необходимо перевести.</param>
        /// <param name="lang">
        /// Направление перевода. Может задаваться одним из следующих способов:
        ///     1) В виде пары кодов языков («с какого»-«на какой»), разделенных дефисом. 
        ///         Например, en-ru обозначает перевод с английского на русский.
        ///     2) В виде кода конечного языка (например ru). 
        ///         В этом случае сервис пытается определить исходный язык автоматически.
        /// </param>
        /// <exception cref="YandexException">Ошибка запроса.</exception>
        /// <returns></returns>
        public TranslateText Translate(string text, string lang) => Web.Get<TranslateText>(API_Translate, new NameValueCollection
        {
            ["text"] = text,
            ["lang"] = lang
        }, ApiKey);

        /// <summary>
        /// Асинхронное получение списка всех поддерживаемых языков.
        /// </summary>
        /// <param name="ui">Названия языков будут выведены на языке, код которого соответствует этому параметру.</param>
        /// <exception cref="YandexException">Ошибка запроса.</exception>
        /// <returns></returns>
        public async Task<GetLangs> GetLangsAsync(string ui = "ru") => await Task.Run(() => GetLangs(ui));

        /// <summary>
        /// Получение списка всех поддерживаемых языков.
        /// </summary>
        /// <param name="ui">Названия языков будут выведены на языке, код которого соответствует этому параметру.</param>
        /// <exception cref="YandexException">Ошибка запроса.</exception>
        /// <returns></returns>
        public GetLangs GetLangs(string ui = "ru") => Web.Get<GetLangs>(API_GetLangs, new NameValueCollection { ["ui"] = ui }, ApiKey);

        /// <summary>
        /// Асинхронное определение языка, на котором написан заданный текст.
        /// </summary>
        /// <param name="text">Текст, язык которого требуется определить.</param>
        /// <exception cref="YandexException">Ошибка запроса.</exception>
        /// <returns></returns>
        public async Task<DetectLang> DetectLangAsync(string text) => await Task.Run(() => DetectLang(text));

        /// <summary>
        /// Определение языка, на котором написан заданный текст.
        /// </summary>
        /// <param name="text">Текст, язык которого требуется определить.</param>
        /// <exception cref="YandexException">Ошибка запроса.</exception>
        /// <returns></returns>
        public DetectLang DetectLang(string text) => Web.Get<DetectLang>(API_DetectLang, new NameValueCollection
        {
            ["text"] = text
        }, ApiKey);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using YandexAPI.Linguistics.Translate.Response;

namespace YandexAPI.Linguistics.Translate
{
    /// <summary>
    /// API Yandex Переводчика.
    /// </summary>
    public sealed class YandexTranslate
    {
        const string API_GetLangs = Const.TranslateAPI + "getLangs";
        const string API_DetectLang = Const.TranslateAPI + "detect";
        const string API_Translate = Const.TranslateAPI + "translate";

        public YandexTranslate()
        {
        }
        public YandexTranslate(string apiKey) => ApiKey = apiKey;

        /// <summary>
        /// Api ключ для переводчика, начинается с 'trnsl'.
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// Асинхронное определение языка, на котором написан заданный текст.
        /// </summary>
        /// <param name="text">Текст, язык которого требуется определить.</param>
        /// <returns></returns>
        public async Task<DetectLang> DetectLangAsync(string text) => await Task.Run(() => DetectLang(text));

        /// <summary>
        /// Асинхронное получение списка всех поддерживаемых языков.
        /// </summary>
        /// <param name="ui">Названия языков будут выведены на языке, код которого соответствует этому параметру.</param>
        /// <returns></returns>
        public async Task<GetLangs> GetLangsAsync(string ui = "ru") => await Task.Run(() => GetLangs(ui));

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
        /// <returns></returns>
        public TranslateText Translate(string text, string lang) => Web.Get<TranslateText>(API_Translate, new Dictionary<string, string>()
        {
            ["text"] = text,
            ["lang"] = lang
        }, ApiKey);

        /// <summary>
        /// Получение списка всех поддерживаемых языков.
        /// </summary>
        /// <param name="ui">Названия языков будут выведены на языке, код которого соответствует этому параметру.</param>
        /// <returns></returns>
        public GetLangs GetLangs(string ui = "ru") => Web.Get<GetLangs>(API_GetLangs, new Dictionary<string, string>()
        {
            ["ui"] = ui
        }, ApiKey);

        /// <summary>
        /// Определение языка, на котором написан заданный текст.
        /// </summary>
        /// <param name="text">Текст, язык которого требуется определить.</param>
        /// <returns></returns>
        public DetectLang DetectLang(string text) => Web.Get<DetectLang>(API_DetectLang, new Dictionary<string, string>()
        {
            ["text"] = text
        }, ApiKey);
    }
}

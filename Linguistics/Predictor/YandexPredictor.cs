using System.Collections.Specialized;
using System.Threading.Tasks;
using YandexAPI.Linguistics.Predictor.Responses;
using YandexAPI.WebHelper;

namespace YandexAPI.Linguistics.Predictor
{
    /// <summary>
    /// API Yandex Предиктора.
    /// </summary>
    public sealed class YandexPredictor
    {
        const string API_GetLangs = Consts.PredictorAPI + "getLangs";
        const string API_Complete = Consts.PredictorAPI + "complete";

        /// <summary>
        /// API ключ переводчика.
        /// </summary>
        public string ApiKey { get; }

        /// <summary>
        /// Конструктор класса YandexPredictor.
        /// </summary>
        /// <param name="apiKey">API ключ переводчика.</param>
        public YandexPredictor(string apiKey) => ApiKey = apiKey;

        /// <summary>
        /// Возвращает список языков, поддерживаемых сервисом.
        /// </summary>
        /// <exception cref="YandexException">Ошибка запроса.</exception>
        /// <returns></returns>
        public string[] GetLangs() => Web.Get<string[]>(API_GetLangs, new NameValueCollection(), ApiKey);

        /// <summary>
        /// Асинхронно возвращает список языков, поддерживаемых сервисом.
        /// </summary>
        /// <exception cref="YandexException">Ошибка запроса.</exception>
        /// <returns></returns>
        public async Task<string[]> GetLangsAsync() => await Task.Run(() => GetLangs());

        /// <summary>
        /// Возвращает наиболее вероятное продолжение текста, а также признак конца слова.
        /// </summary>
        /// <param name="lang">Язык текста (например, "en"). Список языков можно получить с помощью метода GetLangs.</param>
        /// <param name="q">
        /// Текст, на который указывает курсор пользователя.
        /// При подборе подсказки учитывается слово, на которое указывает курсор и 2 слова слева от него, поэтому не требуется передавать текст длиннее трех-четырех слов.
        /// </param>
        /// <param name="limit">Максимальное количество возвращаемых строк (по умолчанию 1).</param>
        /// <returns></returns>
        public PredictorComplete Complete(string lang, string q, ushort limit = 1) => Web.Get<PredictorComplete>(API_Complete, new NameValueCollection
        {
            ["lang"] = lang,
            ["q"] = q,
            ["limit"] = limit.ToString()
        }, ApiKey);

        /// <summary>
        /// Асинхронно возвращает наиболее вероятное продолжение текста, а также признак конца слова.
        /// </summary>
        /// <param name="lang">Язык текста (например, "en"). Список языков можно получить с помощью метода GetLangs.</param>
        /// <param name="q">
        /// Текст, на который указывает курсор пользователя.
        /// При подборе подсказки учитывается слово, на которое указывает курсор и 2 слова слева от него, поэтому не требуется передавать текст длиннее трех-четырех слов.
        /// </param>
        /// <param name="limit">Максимальное количество возвращаемых строк (по умолчанию 1).</param>
        /// <returns></returns>
        public async Task<PredictorComplete> CompleteAsync(string lang, string q, ushort limit = 1) => await Task.Run(() => Complete(lang, q, limit));
    }
}

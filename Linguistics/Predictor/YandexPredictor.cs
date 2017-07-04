using System.Collections.Specialized;
using System.Threading.Tasks;
using YandexAPI.Linguistics.Predictor.Response;

namespace YandexAPI.Linguistics.Predictor
{
    /// <summary>
    /// API Yandex Предиктора.
    /// </summary>
    public sealed class YandexPredictor
    {
        const string API_GetLangs = Const.PredictorAPI + "getLangs";
        const string API_Complete = Const.PredictorAPI + "complete";

        public YandexPredictor(string apiKey) => ApiKey = apiKey;

        /// <summary>
        /// Api ключ для предиктора, начинается с 'pdct'.
        /// </summary>
        public string ApiKey { get; private set; }

        /// <summary>
        /// Асинхронно возвращает список языков, поддерживаемых сервисом.
        /// </summary>
        /// <returns></returns>
        public async Task<string[]> GetLangsAsync() => await Task.Run(() => GetLangs());

        /// <summary>
        /// Асинхронно возвращает наиболее вероятное продолжение текста, а также признак конца слова.
        /// </summary>
        /// <param name="lang">Язык текста (например, "en"). Список языков можно получить с помощью метода GetLangs.</param>
        /// <param name="q">Текст, на который указывает курсор пользователя.</param>
        /// <param name="limit">Максимальное количество возвращаемых строк (по умолчанию 1).</param>
        /// <returns></returns>
        public async Task<Complete> CompleteAsync(string lang, string q, ushort limit = 1) => await Task.Run(() => Complete(lang, q, limit));

        /// <summary>
        /// Возвращает список языков, поддерживаемых сервисом.
        /// </summary>
        /// <returns></returns>
        public string[] GetLangs() => Web.Get<string[]>(API_GetLangs, new NameValueCollection(), ApiKey);

        /// <summary>
        /// Возвращает наиболее вероятное продолжение текста, а также признак конца слова.
        /// </summary>
        /// <param name="lang">Язык текста (например, "en"). Список языков можно получить с помощью метода GetLangs.</param>
        /// <param name="q">Текст, на который указывает курсор пользователя.</param>
        /// <param name="limit">Максимальное количество возвращаемых строк (по умолчанию 1).</param>
        /// <returns></returns>
        public Complete Complete(string lang, string q, ushort limit = 1) => Web.Get<Complete>(API_Complete, new NameValueCollection
        {
            ["lang"] = lang,
            ["q"] = q,
            ["limit"] = limit.ToString()
        }, ApiKey);
    }
}

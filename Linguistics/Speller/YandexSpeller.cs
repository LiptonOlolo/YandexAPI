using Newtonsoft.Json;
using System.Collections.Specialized;
using System.Threading.Tasks;
using YandexAPI.Linguistics.Speller.Response;

namespace YandexAPI.Linguistics.Speller
{
    /// <summary>
    /// API Yandex Спеллера.
    /// </summary>
    public sealed class YandexSpeller
    {
        const string API_CheckText = Const.SpellerAPI + "checkText";

        /// <summary>
        /// Асинхронно проверяет орфографию в указанном отрывке текста.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public async Task<CheckText> CheckTextAsync(string text) => await Task.Run(() => CheckText(text));

        /// <summary>
        /// Проверяет орфографию в указанном отрывке текста.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public CheckText CheckText(string text) => JsonConvert.DeserializeObject<CheckText>(Web.Get<string[]>(API_CheckText, new NameValueCollection
        {
            ["text"] = text
        }, null)[0]);
    }
}

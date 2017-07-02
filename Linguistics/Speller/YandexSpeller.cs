using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
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
        public CheckText CheckText(string text) => JsonConvert.DeserializeObject<CheckText>(Web.GetJsonArray(API_CheckText, new Dictionary<string, string>()
        {
            ["text"] = text
        }, null).ToArray()[0]);
    }
}

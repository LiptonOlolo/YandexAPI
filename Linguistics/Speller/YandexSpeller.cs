using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading.Tasks;
using YandexAPI.Linguistics.Speller.Responses;
using YandexAPI.WebHelper;

namespace YandexAPI.Linguistics.Speller
{
    /// <summary>
    /// API Yandex Спеллера.
    /// </summary>
    public sealed class YandexSpeller
    {
        const string API_CheckText = Consts.SpellerAPI + "checkText";
        const string API_CheckTexts = Consts.SpellerAPI + "checkTexts";

        /// <summary>
        /// Асинхронно проверяет орфографию в указанном отрывке текста.
        /// </summary>
        /// <param name="texts">Строки текста для проверки.</param>
        /// <returns></returns>
        public async Task<List<CheckText[]>> CheckTextsAsync(string[] texts) => await Task.Run(() => CheckTexts(texts));

        /// <summary>
        /// Асинхронно проверяет орфографию в указанном отрывке текста.
        /// </summary>
        /// <param name="text">Строка текста для проверки.</param>
        /// <returns></returns>
        public async Task<CheckText[]> CheckTextAsync(string text) => await Task.Run(() => CheckText(text));

        /// <summary>
        /// Проверяет орфографию в указанном отрывке текста.
        /// </summary>
        /// <param name="texts">Строки текста для проверки.</param>
        /// <returns></returns>
        public List<CheckText[]> CheckTexts(string[] texts)
        {
            NameValueCollection get = new NameValueCollection();

            foreach (var item in texts)
                get.Add("text", item);

            return Web.Get<List<CheckText[]>>(API_CheckTexts, get, null);
        }

        /// <summary>
        /// Проверяет орфографию в указанном отрывке текста.
        /// </summary>
        /// <param name="text">Строка текста для проверки.</param>
        /// <returns></returns>
        public CheckText[] CheckText(string text) => Web.Get<CheckText[]>(API_CheckText, new NameValueCollection
        {
            ["text"] = text
        }, null);
    }
}

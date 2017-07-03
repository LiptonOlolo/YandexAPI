using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Xml;

namespace YandexAPI.SpeechKitCloud.ASR
{
    /// <summary>
    /// Распознавание речи.
    /// </summary>
    public sealed class YandexASR
    {
        public YandexASR(string apiKey) => ApiKey = apiKey;

        /// <summary>
        /// Api ключ для распознования речи.
        /// </summary>
        public string ApiKey { get; private set; }

        /// <summary>
        /// Уникальный идентификатор пользователя (Universally Unique Identifier) — это последовательность из 32-х шестнадцатеричных цифр (0—9, A—F).
        /// </summary>
        public string UUId { get; set; } = "b49f98a0c1b116b6c3be7a7000f00e6b";

        /// <summary>
        /// Асинхронное распознавание речи.
        /// </summary>
        /// <param name="voice">Двоичное содержимое аудио файла.</param>
        /// <param name="topic">
        /// Языковая модель, которую следует использовать при распознавании.
        /// Примечание: чем точнее выбрана модель, тем лучше результат распознавания.
        /// </param>
        /// <param name="lang">Язык, для которого будет выполнено распознавание.</param>
        /// <param name="audioFormat">Формат аудио, должен совпадать с форматом двоичных данных аудио файла (voice).</param>
        /// <returns></returns>
        public async Task<AsrResponse> VoiceToTextAsync(byte[] voice, Topic topic, Lang lang, AudioFormat audioFormat) =>
            await Task.Run(() => VoiceToText(voice, topic, lang, audioFormat));

        /// <summary>
        /// Распознавание речи.
        /// </summary>
        /// <param name="voice">Двоичное содержимое аудио файла.</param>
        /// <param name="topic">
        /// Языковая модель, которую следует использовать при распознавании.
        /// Примечание: чем точнее выбрана модель, тем лучше результат распознавания.
        /// </param>
        /// <param name="lang">Язык, для которого будет выполнено распознавание.</param>
        /// <param name="audioFormat">Формат аудио, должен совпадать с форматом двоичных данных аудио файла (voice).</param>
        /// <returns></returns>
        public AsrResponse VoiceToText(byte[] voice, Topic topic, Lang lang, AudioFormat audioFormat)
        {
            Dictionary<string, string> get = new Dictionary<string, string>()
            {
                ["uuid"] = UUId,
                ["key"] = ApiKey,
                ["topic"] = topic.model,
                ["lang"] = lang.lang
            };

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(Web.GetUri(Const.ARSAPI, get));
            req.Proxy = new WebProxy();
            req.Method = "POST";

            req.Host = "asr.yandex.net";
            req.ContentType = audioFormat.format;
            req.SendChunked = true;

            req.GetRequestStream().Write(voice, 0, voice.Length);

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(new StreamReader(req.GetResponse().GetResponseStream()).ReadToEnd());

            string jsonText = JsonConvert.SerializeXmlNode(doc).Replace("?", "").Replace("@", "").Replace("#", "");

            AsrResponse response = new AsrResponse();

            dynamic des = JsonConvert.DeserializeObject(jsonText);

            response.Success = des["recognitionResults"]["success"].ToString();

            if (des["recognitionResults"]["variant"].Count == null)
                response.Variants.Add(new Variant(des["recognitionResults"]["variant"]["confidence"].ToString(),
                                                 des["recognitionResults"]["variant"]["text"].ToString()));
            else
            {
                int count = des["recognitionResults"]["variant"].Count;

                for (int i = 0; i < count; i++)
                    response.Variants.Add(new Variant(des["recognitionResults"]["variant"][i]["confidence"].ToString(),
                                 des["recognitionResults"]["variant"][i]["text"].ToString()));
            }

            return response;
        } //Спасибо Yandex за убогий вывод данных.
    }
}

using System.IO;
using System.Net;
using YandexAPI.SpeechKitCloud.ASR.Enums;
using YandexAPI.SpeechKitCloud.ASR.Responses;
using YandexAPI.WebHelper;
using Newtonsoft.Json;
using System.Xml;
using Newtonsoft.Json.Linq;

namespace YandexAPI.SpeechKitCloud.ASR
{
    /// <summary>
    /// API Yandex Распознования голоса.
    /// </summary>
    public sealed class YandexASR
    {
        /// <summary>
        /// Уникальный идентификатор пользователя (Universally Unique Identifier) — это последовательность из 32-х шестнадцатеричных цифр (0—9, A—F).
        /// </summary>
        public string UUId { get; set; } = "b49f98a0c1b116b6c3be7a7000f00e6b";

        /// <summary>
        /// API ключ переводчика.
        /// </summary>
        public string ApiKey { get; }

        /// <summary>
        /// Конструктор класса YandexASR.
        /// </summary>
        /// <param name="apiKey">API ключ переводчика.</param>
        public YandexASR(string apiKey) => ApiKey = apiKey;

        /// <summary>
        /// Распознавание речи.
        /// </summary>
        /// <param name="voice">Двоичное содержимое аудио файла.</param>
        /// <param name="topic">
        /// Языковая модель, которую следует использовать при распознавании.
        /// Примечание: чем точнее выбрана модель, тем лучше результат распознавания.
        /// </param>
        /// <param name="lang">Язык, для которого будет выполнено распознавание.</param>
        /// <param name="format">Формат аудио, должен совпадать с форматом двоичных данных аудио файла (voice).</param>
        /// <returns></returns>
        public AsrResponse VoiceToText(byte[] voice, Topic topic, Langs lang, AudioFormat format)
        {
            var req = (HttpWebRequest)WebRequest.Create($"{Consts.ARSAPI}?uuid={UUId}&topic={topic.Model}&lang={lang.Lang}&key={ApiKey}");
            req.Method = "POST";

            req.Host = "asr.yandex.net";
            req.ContentType = format.Format;
            req.SendChunked = true;

            using (var writer = req.GetRequestStream())
                writer.Write(voice, 0, voice.Length);

            string xml = string.Empty;

            using (var reader = new StreamReader(req.GetResponse().GetResponseStream()))
                xml = reader.ReadToEnd();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            var json = JsonConvert.SerializeXmlNode(doc).Replace("?", "").Replace("@", "").Replace("#", ""); ;
            dynamic des = JsonConvert.DeserializeObject(json);

            AsrResponse response = new AsrResponse();

            response.Success = des["recognitionResults"]["success"].ToString().Equals("1");

            if (!response.Success)
                return response;

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
        } //Спасибо Yandex'y за убогий вывод данных.
    }
}

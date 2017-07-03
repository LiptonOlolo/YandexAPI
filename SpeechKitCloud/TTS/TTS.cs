using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace YandexAPI.SpeechKitCloud.TTS
{
    /// <summary>
    /// Синтез речи.
    /// </summary>
    public sealed class YandexTTS
    {
        public YandexTTS(string apiKey) => ApiKey = apiKey;

        /// <summary>
        /// Api ключ для синтеза речи.
        /// </summary>
        public string ApiKey { get; private set; }

        /// <summary>
        /// Асинхронный синтез текста в речь (Text to Speech (TTS)).
        /// </summary>
        /// <param name="text">
        /// Текст, который нужно озвучить. Для передачи слов-омографов используйте + перед ударной гласной. Например, гот+ов или def+ect.
        /// Ограничение на длину строки: 2000 байт.
        /// </param>
        /// <param name="lang">Язык.</param>
        /// <param name="format">Расширение синтезируемого файла (его формат).</param>
        /// <param name="quality">
        /// Частота дискретизации и битрейт синтезируемого PCM-аудио (медиаконтейнер WAV).
        /// Обратите внимание, параметр quality влияет на характеристики аудио только если format=wav.
        /// </param>
        /// <param name="speaker">Голос синтезированной речи.</param>
        /// <param name="speed">
        /// Скорость (темп) синтезированной речи. 
        /// Скорость речи задается дробным числом в диапазоне от 0.1 до 3.0.
        /// </param>
        /// <param name="emotion">Эмоциональная окраска голоса.</param>
        /// <returns></returns>
        public async Task<byte[]> GetVoiceAsync(string text, Lang lang,
            Format format = Format.MP3, Quality quality = Quality.Lo,
            Speaker speaker = Speaker.Omazh, float speed = 1.0f,
            Emotion emotion = Emotion.Neutral) => await Task.Run(() => GetVoice(text, lang, format, quality, speaker, speed, emotion));

        /// <summary>
        /// Синтез текста в речь (Text to Speech (TTS)).
        /// </summary>
        /// <param name="text">
        /// Текст, который нужно озвучить. Для передачи слов-омографов используйте + перед ударной гласной. Например, гот+ов или def+ect.
        /// Ограничение на длину строки: 2000 байт.
        /// </param>
        /// <param name="lang">Язык.</param>
        /// <param name="format">Расширение синтезируемого файла (его формат).</param>
        /// <param name="quality">
        /// Частота дискретизации и битрейт синтезируемого PCM-аудио (медиаконтейнер WAV).
        /// Обратите внимание, параметр quality влияет на характеристики аудио только если format=wav.
        /// </param>
        /// <param name="speaker">Голос синтезированной речи.</param>
        /// <param name="speed">
        /// Скорость (темп) синтезированной речи. 
        /// Скорость речи задается дробным числом в диапазоне от 0.1 до 3.0.
        /// </param>
        /// <param name="emotion">Эмоциональная окраска голоса.</param>
        /// <returns></returns>
        public byte[] GetVoice(string text, Lang lang, Format format = Format.MP3, Quality quality = Quality.Lo, Speaker speaker = Speaker.Omazh, float speed = 1.0f, Emotion emotion = Emotion.Neutral)
        {
            if (speed < 0.1f || speed > 3.0f)
                throw new ArgumentException("speed");

            Dictionary<string, string> get = new Dictionary<string, string>()
            {
                ["key"] = ApiKey,
                ["text"] = text,
                ["format"] = format.ToString().ToLower(),
                ["lang"] = lang.lang,
                ["speaker"] = speaker.ToString().ToLower(),
                ["speed"] = speed.ToString(),
                ["emotion"] = emotion.ToString().ToLower()
            };

            using (WebClient client = new WebClient { Proxy = new WebProxy() })
            using (MemoryStream ms = new MemoryStream())
            {
                client.OpenRead(Web.GetUri(Const.TTSAPI, get)).CopyTo(ms);
                return ms.ToArray();
            }
        }

        /// <summary>
        /// Сохранить аудио в файл.
        /// </summary>
        /// <param name="data">Аудио.</param>
        /// <param name="name">Имя файла (без расширения).</param>
        /// <param name="path">Путь, куда будет сохранен файл.</param>
        /// <param name="format">Формат аудио.</param>
        public void SaveAudio(byte[] data, string name, string path, Format format) =>
            File.WriteAllBytes(Path.Combine(path, $"{name}.{format.ToString().ToLower()}"), data);
    }
}

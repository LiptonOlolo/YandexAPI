using System;
using System.Collections.Specialized;
using System.Net;
using System.Threading.Tasks;
using YandexAPI.SpeechKitCloud.TTS.Enums;
using YandexAPI.SpeechKitCloud.TTS.Responses;
using YandexAPI.WebHelper;

namespace YandexAPI.SpeechKitCloud.TTS
{
    /// <summary>
    /// API Yandex Синтеза речи.
    /// </summary>
    public sealed class YandexTTS
    {
        /// <summary>
        /// API ключ переводчика.
        /// </summary>
        public string ApiKey { get; }

        /// <summary>
        /// Конструктор класса YandexTTS.
        /// </summary>
        /// <param name="apiKey">API ключ переводчика.</param>
        public YandexTTS(string apiKey) => ApiKey = apiKey;

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
        /// <exception cref="WebException">Ошибка запроса.</exception>
        /// <returns></returns>
        public TTSResponse GetVoice(string text, Langs lang, Format format = Format.MP3, Quality quality = Quality.Hi, Speaker speaker = Speaker.Omazh,
            float speed = 1.0f, Emotion emotion = Emotion.Neutral)
        {
            if (speed < 0.1f || speed > 3.0f)
                throw new ArgumentException("speed");

            return new TTSResponse(Web.GetData(Consts.TTSAPI, new NameValueCollection
            {
                ["key"] = ApiKey,
                ["text"] = text,
                ["format"] = format.ToString().ToLower(),
                ["lang"] = lang.Lang,
                ["speaker"] = speaker.ToString().ToLower(),
                ["speed"] = speed.ToString(),
                ["emotion"] = emotion.ToString().ToLower()
            }), format, quality, speaker, speed, emotion);
        }

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
        /// <exception cref="WebException">Ошибка запроса.</exception>
        /// <returns></returns>
        public async Task<TTSResponse> GetVoiceAsync(string text, Langs lang, Format format = Format.MP3, Quality quality = Quality.Hi, Speaker speaker = Speaker.Omazh,
            float speed = 1.0f, Emotion emotion = Emotion.Neutral) => await Task.Run(() => GetVoice(text, lang, format, quality, speaker, speed, emotion));
    }
}

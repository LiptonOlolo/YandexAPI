using System.IO;
using YandexAPI.SpeechKitCloud.TTS.Enums;

namespace YandexAPI.SpeechKitCloud.TTS.Responses
{
    /// <summary>
    /// Результат синтеза текста в речь.
    /// </summary>
    public sealed class TTSResponse
    {
        internal TTSResponse(byte[] source, Format format, Quality quality, Speaker speaker, float speed, Emotion emotion)
        {
            Source = source;
            AudioFormat = format;
            Quality = quality;
            Speaker = speaker;
            Speed = speed;
            Emotion = emotion;
        }

        /// <summary>
        /// Эмоциональная окраска голоса.
        /// </summary>
        public Emotion Emotion { get; private set; }

        /// <summary>
        /// Скорость речи (от 1.0 до 3.0).
        /// </summary>
        public float Speed { get; private set; }

        /// <summary>
        /// Голос синтезированной речи.
        /// </summary>
        public Speaker Speaker { get; private set; }

        /// <summary>
        /// Частота дискретизации и битрейт синтезируемого PCM-аудио (медиаконтейнер WAV).
        /// </summary>
        public Quality Quality { get; private set; }

        /// <summary>
        /// Формат синтезированного текста.
        /// </summary>
        public Format AudioFormat { get; private set; }

        /// <summary>
        /// Синтезированный текст.
        /// </summary>
        public byte[] Source { get; private set; }

        /// <summary>
        /// Сохранить синтезированный текст в файл.
        /// </summary>
        /// <param name="name">Путь и имя для сохранения без указания формата файла.</param>
        public void SaveAudio(string name) => File.WriteAllBytes($"{name}.{AudioFormat.ToString().ToLower()}", Source);
    }
}

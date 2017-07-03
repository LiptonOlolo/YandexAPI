namespace YandexAPI.SpeechKitCloud.TTS
{
    /// <summary>
    /// Расширение синтезируемого файла (его формат).
    /// </summary>
    public enum Format
    {
        /// <summary>
        /// Аудио в формате MPEG, медиаконтейнер MPEG-1 Audio Layer 3.
        /// </summary>
        MP3,

        /// <summary>
        /// Аудио в формате PCM 16 бит, медиаконтейнер WAV
        /// </summary>
        WAV,

        /// <summary>
        /// Аудио в формате Opus, в качестве контейнера используется OGG.
        /// </summary>
        Opus
    }

    /// <summary>
    /// Частота дискретизации и битрейт синтезируемого PCM-аудио (медиаконтейнер WAV).
    /// Обратите внимание, параметр quality влияет на характеристики аудио только если format=wav.
    /// </summary>
    public enum Quality
    {
        /// <summary>
        /// Частота дискретизации 48 кГц и битрейт 768 кб/c.
        /// </summary>
        Hi,

        /// <summary>
        /// Частота дискретизации 8 кГц и битрейт 128 кб/c.
        /// </summary>
        Lo
    }

    /// <summary>
    /// Голос синтезированной речи.
    /// </summary>
    public enum Speaker
    {
        /// <summary>
        /// Женщина.
        /// </summary>
        Jane,

        /// <summary>
        /// Женщина.
        /// </summary>
        Oksana,

        /// <summary>
        /// Женщина.
        /// </summary>
        Alyss,

        /// <summary>
        /// Женщина.
        /// </summary>
        Omazh,

        /// <summary>
        /// Мужчина.
        /// </summary>
        Zahar,

        /// <summary>
        /// Мужчина.
        /// </summary>
        Ermil
    }

    /// <summary>
    /// Эмоциональная окраска голоса.
    /// </summary>
    public enum Emotion
    {
        /// <summary>
        /// Радостный, доброжелательный.
        /// </summary>
        Good,

        /// <summary>
        /// Раздраженный.
        /// </summary>
        Evil,

        /// <summary>
        /// Нейтральный.
        /// </summary>
        Neutral
    }
}

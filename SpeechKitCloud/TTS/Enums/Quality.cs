namespace YandexAPI.SpeechKitCloud.TTS.Enums
{
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
}

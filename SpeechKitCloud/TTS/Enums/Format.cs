namespace YandexAPI.SpeechKitCloud.TTS.Enums
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
}

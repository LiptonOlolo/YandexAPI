namespace YandexAPI.SpeechKitCloud.ASR.Enums
{
    /// <summary>
    /// Формат аудио данных.
    /// </summary>
    public sealed class AudioFormat
    {
        private AudioFormat(string format) => Format = format;

        /// <summary>
        /// Формат аудио.
        /// </summary>
        public string Format { get; }

        /// <summary>
        /// Медиаконтейнер WAV может содержать аудио данные любого формата, например PCM.
        /// </summary>
        public static AudioFormat WAV = new AudioFormat("audio/x-wav");

        /// <summary>
        /// MPEG-1 Audio Layer 3 (MP3).
        /// </summary>
        public static AudioFormat MP3 = new AudioFormat("audio/x-mpeg-3");

        /// <summary>
        /// Speex.
        /// </summary>
        public static AudioFormat OGG = new AudioFormat("audio/x-speex");

        /// <summary>
        /// Opus.
        /// </summary>
        public static AudioFormat OGGOpus = new AudioFormat("audio/ogg;codecs=opus");

        /// <summary>
        /// Opus.
        /// </summary>
        public static AudioFormat WebM = new AudioFormat("audio/webm;codecs=opus");

        /// <summary>
        /// Linear PCM c частотой дискретизации 16000 Гц и разрядностью квантования 16 бит.
        /// </summary>
        public static AudioFormat PCM16Bit16kRate = new AudioFormat("audio/x-pcm;bit=16;rate=16000");

        /// <summary>
        /// Linear PCM c частотой дискретизации 8000 Гц и разрядностью квантования 16 бит.
        /// </summary>
        public static AudioFormat PCM16Bit8kRate = new AudioFormat("audio/x-pcm;bit=16;rate=8000");

        /// <summary>
        /// PCM на основе A-law. Частота дискретизации 8000 Гц, разрядность квантования 13 бит.
        /// </summary>
        public static AudioFormat PCM13Bit8kRate = new AudioFormat("audio/x-alaw;bit=13;rate=8000");
    }
}

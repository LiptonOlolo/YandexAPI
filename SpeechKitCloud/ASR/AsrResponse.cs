using System.Collections.Generic;

namespace YandexAPI.SpeechKitCloud.ASR
{
    public class AsrResponse
    {
        public string success;
        public readonly List<Variant> variant = new List<Variant>();
    }

    public class Variant
    {
        public Variant(string con, string t)
        {
            confidence = con;
            text = t;
        }

        public readonly string confidence;
        public readonly string text;
    }
}

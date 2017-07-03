using System.Collections.Generic;

namespace YandexAPI.SpeechKitCloud.ASR
{
    public class AsrResponse
    {
        public string Success;
        public readonly List<Variant> Variants = new List<Variant>();
    }

    public class Variant
    {
        public Variant(string confidence, string text)
        {
            Confidence = confidence;
            Text = text;
        }

        public readonly string Confidence;
        public readonly string Text;
    }
}

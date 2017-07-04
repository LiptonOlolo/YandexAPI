using System.Collections.Generic;

namespace YandexAPI.SpeechKitCloud.ASR
{
    public class AsrResponse
    {
        public bool Success;
        public readonly List<Variant> Variants = new List<Variant>();
    }

    public class Variant
    {
        public Variant(string confidence, string text)
        {
            Confidence = float.Parse(confidence.Replace('.', ','));
            Text = text;
        }

        public readonly float Confidence;
        public readonly string Text;
    }
}

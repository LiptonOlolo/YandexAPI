namespace YandexAPI.StaticMapsAPI.Enums
{
    static class FloatHelper
    {
        public static string FloatToString(float value) => value.ToString().Replace(',', '.');
        public static string FloatToString(float? value) => value.HasValue ? FloatToString(value.Value) : "0.0";
    }
}

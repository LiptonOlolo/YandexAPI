namespace YandexAPI.MapsStaticAPI
{
    /// <summary>
    /// Маркер 'flag'.
    /// Без размера и контента.
    /// </summary>
    public sealed class Marker_Flag
    {
        /// <summary>
        /// Флаг.
        /// </summary>
        public static Marker Flag => new Marker("flag", "", false, false);
    }
}

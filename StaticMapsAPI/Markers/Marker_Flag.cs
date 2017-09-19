namespace YandexAPI.StaticMapsAPI.Markers
{
    /// <summary>
    /// Маркер 'flag'.
    /// Без размера и контента.
    /// </summary>
    public sealed class Marker_Flag
    {
        private Marker_Flag() { }

        static Marker_Flag instance = null;
        internal static Marker_Flag GetInstance() => instance ?? (instance = new Marker_Flag());

        /// <summary>
        /// Флаг.
        /// </summary>
        public Marker Flag => new Marker("flag", "", false, false);
    }
}

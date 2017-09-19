namespace YandexAPI.StaticMapsAPI.Markers
{
    /// <summary>
    /// Векторные маркеры.
    /// Без размера и контента.
    /// </summary>
    public sealed class Marker_Vector
    {
        private Marker_Vector() { }

        static Marker_Vector instance = null;
        internal static Marker_Vector GetInstance() => instance ?? (instance = new Marker_Vector());

        /// <summary>
        /// Голубая метка с хвостиком
        /// </summary>
        public Marker Org => new Marker("org", "", false, false);

        /// <summary>
        /// Голубая метка с кругом в центре.
        /// </summary>
        public Marker Comma => new Marker("comma", "", false, false);

        /// <summary>
        /// Голубая метка с в виде круга
        /// </summary>
        public Marker Round => new Marker("round", "", false, false);

        /// <summary>
        /// Значок дома.
        /// </summary>
        public Marker Home => new Marker("home", "", false, false);

        /// <summary>
        /// Значок работы.
        /// </summary>
        public Marker Work => new Marker("work", "", false, false);

        /// <summary>
        /// Значок с логотипом Яндекса.
        /// </summary>
        public Marker Yandex => new Marker("ya_ru", "", false, false);
    }
}

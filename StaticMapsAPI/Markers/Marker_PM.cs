namespace YandexAPI.StaticMapsAPI.Markers
{
    /// <summary>
    /// Маркер 'pm'.
    /// Размер: любой.
    /// Контент:
    /// для размеров s и m — число от 1 до 99,
    /// для размера l — число от 1 до 100.
    /// </summary>
    public sealed class Marker_PM
    {
        private Marker_PM() { }

        static Marker_PM instance = null;
        internal static Marker_PM GetInstance() => instance ?? (instance = new Marker_PM());

        const string style = "pm";

        /// <summary>
        /// Белый.
        /// </summary>
        public Marker Wt => new Marker(style, "wt");

        /// <summary>
        /// Темно-оранжевый.
        /// </summary>
        public Marker Do => new Marker(style, "do");

        /// <summary>
        /// Темно-синий.
        /// </summary>
        public Marker Db => new Marker(style, "db");

        /// <summary>
        /// Синий.
        /// </summary>
        public Marker Bl => new Marker(style, "bl");

        /// <summary>
        /// Зеленый.
        /// </summary>
        public Marker Gn => new Marker(style, "gn");

        /// <summary>
        /// Серый.
        /// </summary>
        public Marker Gr => new Marker(style, "gr");

        /// <summary>
        /// Светло-синий.
        /// </summary>
        public Marker Lb => new Marker(style, "lb");

        /// <summary>
        /// Темная ночь.
        /// </summary>
        public Marker Nt => new Marker(style, "nt");

        /// <summary>
        /// Оранжевый.
        /// </summary>
        public Marker Or => new Marker(style, "or");

        /// <summary>
        /// Розовый.
        /// </summary>
        public Marker Pn => new Marker(style, "pn");

        /// <summary>
        /// Красный.
        /// </summary>
        public Marker Rd => new Marker(style, "rd");

        /// <summary>
        /// Фиолетовый.
        /// </summary>
        public Marker Vv => new Marker(style, "vv");

        /// <summary>
        /// Желтый.
        /// </summary>
        public Marker Yw => new Marker(style, "yw");

        /// <summary>
        /// С буквой 'А'.
        /// </summary>
        public Marker A => new Marker(style, "a", false, false);

        /// <summary>
        /// С буквой 'Б'.
        /// </summary>
        public Marker B => new Marker(style, "b", false, false);
    }
}

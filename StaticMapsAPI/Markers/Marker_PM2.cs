namespace YandexAPI.StaticMapsAPI.Markers
{
    /// <summary>
    /// Маркер 'pm2'.
    /// Размер: M, L.
    /// Контент:
    /// число от 1 до 99.
    /// </summary>
    public sealed class Marker_PM2
    {
        private Marker_PM2() { }

        static Marker_PM2 instance = null;
        internal static Marker_PM2 GetInstance() => instance ?? (instance = new Marker_PM2());

        const string style = "pm2";

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
        /// Зеленый
        /// </summary>
        public Marker Gn => new Marker(style, "gn");

        /// <summary>
        /// Темно-зеленый.
        /// </summary>
        public Marker Dg => new Marker(style, "dg");

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
        /// Красный
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
        /// С буквой "А" (без указания контента).
        /// </summary>
        public Marker A => new Marker(style, "wt", true, false);

        /// <summary>
        /// С буквой "Б" (без указания контента).
        /// </summary>
        public Marker B => new Marker(style, "wt", true, false);

        /// <summary>
        /// Голубой (без указания контента).
        /// </summary>
        public Marker Org => new Marker(style, "wt", true, false);

        /// <summary>
        /// Фиолетовый (без указания контента).
        /// </summary>
        public Marker Dir => new Marker(style, "wt", true, false);

        /// <summary>
        /// Голубой с жёлтой точкой.
        /// </summary>
        public Marker Blyw => new Marker(style, "wt");
    }
}

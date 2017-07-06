namespace YandexAPI.MapsStaticAPI
{
    /// <summary>
    /// Маркер для карты.
    /// </summary>
    public class Marker
    {
        internal Marker(string style, string color, bool changeSize = true, bool changeContent = true)
        {
            ChangeSize = changeSize;
            ChangeContent = changeContent;
            Color = color;
            Style = style;
        }

        /// <summary>
        /// Стиль маркера.
        /// </summary>
        public string Style { get; private set; }

        /// <summary>
        /// Получает значение, указывающее на то, можно ли изменять размер маркера или нет.
        /// </summary>
        public bool ChangeSize { get; private set; }

        /// <summary>
        /// Получает значение, указывающее на то, можно ли изменять контент маркера или нет.
        /// </summary>
        public bool ChangeContent { get; private set; }

        /// <summary>
        /// Позиция маркера.
        /// </summary>
        public MapPoint Point { get; set; }

        /// <summary>
        /// Цвет маркера.
        /// </summary>
        public string Color { get; private set; }

        /// <summary>
        /// Размер маркера.
        /// </summary>
        public MarkerSize? Size
        {
            get => size;
            set
            {
                if (ChangeSize)
                    size = value;
            }
        }

        MarkerSize? size = null;

        /// <summary>
        /// Текст маркера.
        /// </summary>
        public int? Content
        {
            get => content; set
            {
                if (ChangeContent)
                    content = value;
            }
        }

        int? content = null;
    }

    /// <summary>
    /// Размер маркера.
    /// </summary>
    public enum MarkerSize
    {
        /// <summary>
        /// Маленький.
        /// </summary>
        S,

        /// <summary>
        /// Средний
        /// </summary>
        M,

        /// <summary>
        /// Большой.
        /// </summary>
        L
    }
}

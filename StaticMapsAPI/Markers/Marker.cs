using YandexAPI.StaticMapsAPI.Enums;

namespace YandexAPI.StaticMapsAPI.Markers
{
    /// <summary>
    /// Маркер для карты.
    /// </summary>
    public sealed class Marker
    {
        internal Marker(string style, string color, bool changeSize = true, bool changeContent = true)
        {
            CanResize = changeSize;
            CanChangeContent = changeContent;
            Color = color;
            Style = style;
        }

        /// <summary>
        /// Установить текст маркера.
        /// </summary>
        /// <param name="content">текст.</param>
        /// <returns></returns>
        public Marker SetContent(int? content)
        {
            Content = content;
            return this;
        }

        /// <summary>
        /// Точка расположения маркера.
        /// </summary>
        /// <param name="point">Точка расположения.</param>
        /// <returns></returns>
        public Marker SetPoint(MapPoint point)
        {
            Point = point;
            return this;
        }

        /// <summary>
        /// Установить размер маркера.
        /// </summary>
        /// <param name="size">Размер.</param>
        /// <returns></returns>
        public Marker SetMarkerSize(MarkerSize? size)
        {
            Size = size;
            return this;
        }

        /// <summary>
        /// Размер маркера.
        /// </summary>
        public MarkerSize? Size
        {
            get => size;
            set
            {
                if (CanResize)
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
                if (CanChangeContent)
                    content = value;
            }
        }

        int? content = null;

        /// <summary>
        /// Стиль маркера.
        /// </summary>
        public string Style { get; }

        /// <summary>
        /// Получает значение, указывающее на то, можно ли изменять размер маркера или нет.
        /// </summary>
        public bool CanResize { get; }

        /// <summary>
        /// Получает значение, указывающее на то, можно ли изменять контент маркера или нет.
        /// </summary>
        public bool CanChangeContent { get; }

        /// <summary>
        /// Позиция маркера.
        /// </summary>
        public MapPoint Point { get; set; }

        /// <summary>
        /// Цвет маркера.
        /// </summary>
        public string Color { get; }

        /// <summary>
        /// Маркер Флага.
        /// </summary>
        public static Marker_Flag Flag => Marker_Flag.GetInstance();

        /// <summary>
        /// Маркер со стилем 'PM'.
        /// </summary>
        public static Marker_PM PM => Marker_PM.GetInstance();

        /// <summary>
        /// Маркер со стилем 'PM2'.
        /// </summary>
        public static Marker_PM2 PM2 => Marker_PM2.GetInstance();

        /// <summary>
        /// Векторные маркеры.
        /// </summary>
        public static Marker_Vector Vector => Marker_Vector.GetInstance();

        /// <summary>
        /// Маркер со стилем 'vk' (кнопка).
        /// </summary>
        public static Marker_VK VK => Marker_VK.GetInstance();
    }
}

using System.Drawing;

namespace YandexAPI.MapsStaticAPI
{
    /// <summary>
    /// Линия на карте.
    /// </summary>
    public class Line
    {
        /// <summary>
        /// Конструктор класса Line.
        /// </summary>
        /// <param name="thickness">Толщина линии (пикселы).</param>
        /// <param name="lineColor">Цвет линии.</param>
        /// <param name="points">Точки линии.</param>
        public Line(byte thickness, Color lineColor, MapPoint[] points)
        {
            Thickness = thickness;
            LineColor = lineColor;
            Points = points;
        }

        /// <summary>
        /// Толщина линии (пикселы).
        /// </summary>
        public byte Thickness { get; private set; }

        /// <summary>
        /// Цвет линии.
        /// </summary>
        public Color LineColor { get; private set; }

        /// <summary>
        /// Точки линии.
        /// </summary>
        public MapPoint[] Points { get; private set; }

        /// <summary>
        /// Получить строку цвета в HEX формате.
        /// Формат: {красный}{зеленый}{синий}{альфа(прозрачность)}.
        /// </summary>
        /// <param name="c">Цвет.</param>
        /// <returns></returns>
        protected string GetHexColor(Color c) => $"{c.R.ToString("X2")}{c.G.ToString("X2")}{c.B.ToString("X2")}{c.A.ToString("X2")}".ToLower();

        /// <summary>
        /// Получить сформированную строку для линии.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"c:{GetHexColor(LineColor)},w:{Thickness},{string.Join<MapPoint>(",", Points)}";
    }
}

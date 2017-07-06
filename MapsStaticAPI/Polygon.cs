using System.Drawing;

namespace YandexAPI.MapsStaticAPI
{
    /// <summary>
    /// Многоугольник на карте.
    /// </summary>
    public sealed class Polygon : Line
    {
        /// <summary>
        /// Конструктор класса Polygon.
        /// </summary>
        /// <param name="thickness">Толщина линии (пикселы).</param>
        /// <param name="lineColor">Цвет линий.</param>
        /// <param name="backColor">Цвет заливки.</param>
        /// <param name="points">Точки линий.</param>
        public Polygon(byte thickness, Color lineColor, Color backColor, MapPoint[] points)
            : base(thickness, lineColor, points)
        {
            BackColor = backColor;
        }

        /// <summary>
        /// Цвет заливки многоугольника.
        /// </summary>
        public Color BackColor { get; private set; }

        /// <summary>
        /// Получить сформированную строку для многоугольника.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"c:{GetHexColor(LineColor)},f:{GetHexColor(BackColor)},w:{Thickness},{string.Join<MapPoint>(",", Points)}";
    }
}

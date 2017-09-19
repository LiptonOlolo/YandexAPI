namespace YandexAPI.StaticMapsAPI
{
    /// <summary>
    /// В параметре Bbox задаются географические координаты углов прямоугольника, ограничивающего область просмотра.
    /// Указываются координаты левого нижнего и правого верхнего углов.
    /// Примечание: при одновременном задании Bbox и LL+Spn параметр Bbox является более приоритетным.
    /// </summary>
    public sealed class Bbox
    {
        /// <summary>
        /// Конструктор класса Bbox.
        /// </summary>
        /// <param name="LowerLeftPoint">Координаты левого нижнего угла.</param>
        /// <param name="RightTopPoint">Координаты правого верхнего угла.</param>
        public Bbox(MapPoint LowerLeftPoint, MapPoint RightTopPoint)
        {
            this.LowerLeftPoint = LowerLeftPoint;
            this.RightTopPoint = RightTopPoint;
        }

        /// <summary>
        /// Координаты левого нижнего угла.
        /// </summary>
        public MapPoint LowerLeftPoint { get; private set; }

        /// <summary>
        /// Координаты правого верхнего угла.
        /// </summary>
        public MapPoint RightTopPoint { get; private set; }

        /// <summary>
        /// Получить точки в формате {левый нижний угол}~{правый верхний угол}.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"{LowerLeftPoint.ToString()}~{RightTopPoint.ToString()}";
    }
}

using System;
using TheProject.Model.Geometry;

namespace TheProject.Model.Geometry
{
    /// <summary>
    /// Фабрика для генерации прямоугольников со случайными характеристиками.
    /// </summary>
    public static class RectangleFactory
    {
        /// <summary>
        /// Генерирует прямоугольник со случайными параметрами в пределах указанной области.
        /// </summary>
        /// <param name="panelWidth">Максимальная доступная ширина (должна быть > 0)</param>
        /// <param name="panelHeight">Максимальная доступная высота (должна быть > 0)</param>
        /// <returns>Новый прямоугольник со случайными размерами и позицией</returns>
        /// <remarks>
        /// Гарантирует, что весь прямоугольник будет находиться в пределах заданной области.
        /// Размеры генерируются в диапазоне от 10px до 1/4 от размера соответствующей стороны панели.
        /// </remarks>
        public static Rectangle Randomize(int panelWidth, int panelHeight)
        {
            Random random = new Random();

            // Базовые ограничения размеров
            const int minSize = 10; // Минимальный размер стороны
            const int maxSizeFactor = 4; // Максимальный размер как доля от панели

            // Генерация случайных размеров с учетом ограничений
            int newWidth = random.Next(minSize, Math.Max(minSize, panelWidth / maxSizeFactor));
            int newLength = random.Next(minSize, Math.Max(minSize, panelHeight / maxSizeFactor));

            // Расчет позиции центра с учетом границ панели
            int centerX = random.Next(newWidth / 2, panelWidth - newWidth / 2);
            int centerY = random.Next(newLength / 2, panelHeight - newLength / 2);

            return new Rectangle(newLength, newWidth, "White", new Point2D(centerX, centerY));
        }
    }
}
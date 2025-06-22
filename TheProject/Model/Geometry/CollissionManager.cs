using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheProject.Model.Geometry;

namespace TheProject.Model.Geometry
{
    public static class CollisionManager
    {
        /// <summary>
        /// Проверяет, пересекаются ли два заданных прямоугольника. 
        /// </summary>
        public static bool IsCollision(Rectangle rectangle1, Rectangle rectangle2)
        {
            // Расстояние между центрами по осям X и Y
            double dX = Math.Abs(rectangle1.Center.X - rectangle2.Center.X);
            double dY = Math.Abs(rectangle1.Center.Y - rectangle2.Center.Y);

            // Сумма половинных размеров прямоугольников по осям
            double halfWidthsSum = (rectangle1.Width / 2) + (rectangle2.Width / 2);
            double halfHeightsSum = (rectangle1.Length / 2) + (rectangle2.Length / 2);

            // Пересечение происходит при перекрытии по обеим осям
            return dX < halfWidthsSum && dY < halfHeightsSum;
        }

        /// <summary>
        /// Проверяет, пересекаются ли два заданных круга. 
        /// </summary>
        public static bool IsCollision(Ring ring1, Ring ring2)
        {
            // Разность координат центров по осям
            double dX = Math.Abs(ring1.Center.X - ring2.Center.X);
            double dY = Math.Abs(ring1.Center.Y - ring2.Center.Y);

            // Евклидово расстояние между центрами
            double centerDistance = Math.Sqrt(dX * dX + dY * dY);

            // Сравнение расстояния с суммой радиусов
            return centerDistance < (ring1.OuterRadius + ring2.OuterRadius);
        }
    }
}
using System;
using TheProject.Model;

namespace TheProject.Model.Geometry
{
    /// <summary>
    /// Геометрическая фигура кольца (область между двумя концентрическими окружностями).
    /// </summary>
    public class Ring
    {
        private Point2D _center;
        private double _innerRadius;
        private double _outerRadius;

        /// <summary>
        /// Центр кольца в двумерном пространстве.
        /// </summary>
        public Point2D Center
        {
            get => _center;
            set => _center = value;
        }

        /// <summary>
        /// Радиус внутренней окружности кольца.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Возникает при:
        /// - отрицательном значении
        /// - значении, превышающем внешний радиус
        /// </exception>
        public double InnerRadius
        {
            get => _innerRadius;
            set
            {
                Validator.AssertOnPositiveValue(value, nameof(InnerRadius));
                if (value >= OuterRadius)
                    throw new ArgumentException($"Внутренний радиус должен быть меньше внешнего. Получено: {value}, текущий внешний: {OuterRadius}");
                _innerRadius = value;
            }
        }

        /// <summary>
        /// Радиус внешней окружности кольца.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Возникает при:
        /// - отрицательном значении
        /// - значении, меньшем внутреннего радиуса
        /// </exception>
        public double OuterRadius
        {
            get => _outerRadius;
            set
            {
                Validator.AssertOnPositiveValue(value, nameof(OuterRadius));
                if (value <= InnerRadius)
                    throw new ArgumentException($"Внешний радиус должен быть больше внутреннего. Получено: {value}, текущий внутренний: {InnerRadius}");
                _outerRadius = value;
            }
        }

        /// <summary>
        /// Инициализирует новое кольцо с указанными параметрами.
        /// </summary>
        /// <param name="center">Центр кольца</param>
        /// <param name="innerRadius">Радиус внутренней окружности (должен быть > 0 и < outerRadius)</param>
        /// <param name="outerRadius">Радиус внешней окружности (должен быть > 0 и > innerRadius)</param>
        /// <remarks>
        /// Внешний радиус устанавливается перед внутренним для корректной валидации.
        /// </remarks>
        public Ring(Point2D center, double innerRadius, double outerRadius)
        {
            Center = center;
            _outerRadius = outerRadius; // Прямое присвоение для обхода валидации
            InnerRadius = innerRadius;   // С проверкой через свойство
        }

        /// <summary>
        /// Вычисляет площадь кольца как разность площадей внешнего и внутреннего кругов.
        /// </summary>
        public double Area => Math.PI * (Math.Pow(OuterRadius, 2) - Math.Pow(InnerRadius, 2));
    }
}
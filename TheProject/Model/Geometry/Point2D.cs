using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheProject.Model;

namespace TheProject.Model.Geometry
{
    /// <summary>
    /// Представляет точку в двумерном пространстве с координатами X и Y.
    /// </summary>
    public class Point2D
    {
        /// <summary>
        /// Координата точки по оси абсцисс (X).
        /// </summary>
        private double _x;

        /// <summary>
        /// Получает или устанавливает координату X точки.
        /// </summary>
        /// <value>
        /// Положительное число, представляющее координату по горизонтальной оси.
        /// </value>
        /// <exception cref="ArgumentException">
        /// Выбрасывается при попытке установить отрицательное значение.
        /// </exception>
        public double X
        {
            get { return _x; }
            set
            {
                Validator.AssertOnPositiveValue(value, nameof(X));
                _x = value;
            }
        }

        /// <summary>
        /// Координата точки по оси ординат (Y).
        /// </summary>
        private double _y;

        /// <summary>
        /// Получает или устанавливает координату Y точки.
        /// </summary>
        /// <value>
        /// Положительное число, представляющее координату по вертикальной оси.
        /// </value>
        /// <exception cref="ArgumentException">
        /// Выбрасывается при попытке установить отрицательное значение.
        /// </exception>
        public double Y
        {
            get { return _y; }
            set
            {
                Validator.AssertOnPositiveValue(value, nameof(Y));
                _y = value;
            }
        }

        /// <summary>
        /// Инициализирует новый экземпляр точки с указанными координатами.
        /// </summary>
        /// <param name="x">Координата X (по умолчанию 0).</param>
        /// <param name="y">Координата Y (по умолчанию 0).</param>
        public Point2D(double x = 0, double y = 0)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Инициализирует новый экземпляр точки в начале координат (0, 0).
        /// </summary>
        public Point2D() : this(0, 0) { }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheProject.Model.Geometry
{
    /// <summary>
    /// Геометрическая фигура прямоугольника с заданными параметрами и местоположением.
    /// </summary>
    public class Rectangle
    {
        /// <summary>
        /// Счетчик для генерации уникальных идентификаторов экземпляров.
        /// </summary>
        private static int _nextId = 1;

        private int _id;
        /// <summary>
        /// Уникальный числовой идентификатор экземпляра прямоугольника.
        /// </summary>
        public int Id
        {
            get { return _id; }
            private set { _id = value; }
        }

        private double _length;
        /// <summary>
        /// Вертикальный размер прямоугольника (высота).
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Возникает при попытке установить неположительное значение.
        /// </exception>
        public double Length
        {
            get { return _length; }
            set
            {
                Validator.AssertOnPositiveValue(value, nameof(Length));
                _length = value;
            }
        }

        private double _width;
        /// <summary>
        /// Горизонтальный размер прямоугольника (ширина).
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Возникает при попытке установить неположительное значение.
        /// </exception>
        public double Width
        {
            get { return _width; }
            set
            {
                Validator.AssertOnPositiveValue(value, nameof(Width));
                _width = value;
            }
        }

        private string _colour;
        /// <summary>
        /// Цвет заливки прямоугольника в строковом формате.
        /// </summary>
        public string Colour
        {
            get { return _colour; }
            set { _colour = value; }
        }

        /// <summary>
        /// Точка центра прямоугольника в системе координат.
        /// </summary>
        public Point2D Center { get; set; }

        /// <summary>
        /// Флаг, указывающий на пересечение с другими объектами.
        /// </summary>
        public bool IsColliding { get; set; } = false;

        /// <summary>
        /// Создает новый прямоугольник с указанными параметрами.
        /// </summary>
        /// <param name="length">Высота прямоугольника (должна быть > 0)</param>
        /// <param name="width">Ширина прямоугольника (должна быть > 0)</param>
        /// <param name="colour">Цвет в формате строки</param>
        /// <param name="center">Координаты центра</param>
        public Rectangle(double length, double width, string colour, Point2D center)
        {
            _id = _nextId++;
            Length = length;
            Width = width;
            Colour = colour;
            Center = center;
        }
    }
}
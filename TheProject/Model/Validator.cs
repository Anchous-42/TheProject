using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheProject.Model
{
    /// <summary>
    /// Содержит методы проверки корректности значений.
    /// </summary>
    internal class Validator
    {
        /// <summary>
        /// Проверяет, что вещественное число неотрицательное.
        /// </summary>
        /// <param name="value">Проверяемое число</param>
        /// <param name="propertyName">Название проверяемого свойства</param>
        /// <exception cref="ArgumentException">Возникает при отрицательном значении</exception>
        public static void AssertOnPositiveValue(double value, string propertyName)
        {
            if (value < 0)
            {
                throw new ArgumentException($"Значение '{propertyName}' должно быть больше или равно 0. Вы ввели: {value}.");
            }
        }

        /// <summary>
        /// Проверяет, что целое число неотрицательное.
        /// </summary>
        /// <param name="value">Проверяемое число</param>
        /// <param name="propertyName">Название проверяемого свойства</param>
        /// <exception cref="ArgumentException">Возникает при отрицательном значении</exception>
        public static void AssertOnPositiveValue(int value, string propertyName)
        {
            if (value < 0)
            {
                throw new ArgumentException($"Значение '{propertyName}' должно быть больше или равно 0. Вы ввели: {value}.");
            }
        }

        /// <summary>
        /// Проверяет, что число находится в заданных границах.
        /// </summary>
        /// <param name="value">Проверяемое число</param>
        /// <param name="min">Нижняя граница диапазона (включительно)</param>
        /// <param name="max">Верхняя граница диапазона (включительно)</param>
        /// <param name="propertyName">Название проверяемого свойства</param>
        /// <exception cref="ArgumentException">Возникает при выходе за границы диапазона</exception>
        public static void AssertValueInRange(int value, int min, int max, string propertyName)
        {
            if (value < min)
            {
                throw new ArgumentException($"Значение '{propertyName}' должно находиться в допустимом диапазоне. Вы ввели: {value}, тогда как минимальное значение: {min}.");
            }

            if (value > max)
            {
                throw new ArgumentException($"Значение '{propertyName}' должно находиться в допустимом диапазоне. Вы ввели: {value}, тогда как максимальное значение: {max}.");
            }
        }
    }
}
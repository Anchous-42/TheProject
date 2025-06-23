using Lab8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    /// <summary>
    /// Класс с вспомогательными утилитами
    /// </summary>
    internal static class Utils
    {
        /// <summary>
        /// Выполняет указанное действие для каждого элемента коллекции с передачей индекса
        /// </summary>
        /// <typeparam name="T">Тип элементов коллекции</typeparam>
        /// <param name="ie">Коллекция элементов</param>
        /// <param name="action">Действие, выполняемое для каждого элемента.
        /// Первый параметр - элемент коллекции, второй - его индекс.</param>
        /// <remarks>
        /// Этот метод является extension-методом для IEnumerable<T>.
        /// Аналог ForEach, но с передачей индекса элемента.
        /// </remarks>
        public static void Each<T>(this IEnumerable<T> ie, Action<T, int> action)
        {
            var i = 0; // Счетчик индексов
            foreach (var e in ie)
            {
                // Вызываем переданное действие для каждого элемента,
                // передавая сам элемент и его индекс
                action(e, i++);
            }
        }
    }
}
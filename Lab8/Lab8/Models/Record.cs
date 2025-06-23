using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8.Models
{
    /// <summary>
    /// Класс записи с динамическим поведением
    /// </summary>
    /// <typeparam name="T">Тип хранимых данных</typeparam>
    /// <remarks>
    /// Наследует DynamicObject для поддержки динамических операций.
    /// Представляет запись с идентификатором и данными.
    /// </remarks>
    internal class Record<T> : DynamicObject
    {
        /// <summary>
        /// Уникальный идентификатор записи
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Данные записи
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Создает новую запись
        /// </summary>
        /// <param name="id">Идентификатор записи</param>
        /// <param name="data">Данные для хранения</param>
        /// <exception cref="ArgumentNullException">Если данные не указаны</exception>
        public Record(int id, T data)
        {
            Id = id;
            Data = data ?? throw new ArgumentNullException(nameof(data));
        }

        /// <summary>
        /// Возвращает строковое представление данных записи
        /// </summary>
        /// <returns>Строковое представление данных</returns>
        public override string ToString()
        {
            return Data?.ToString() ?? string.Empty;
        }
    }
}
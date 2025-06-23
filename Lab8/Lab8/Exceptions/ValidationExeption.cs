using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8.Exceptions
{
    /// <summary>
    /// Исключение, возникающее при ошибках валидации данных
    /// </summary>
    /// <remarks>
    /// Наследуется от стандартного класса Exception.
    /// Используется для обработки ошибок валидации в бизнес-логике приложения.
    /// </remarks>
    internal class ValidationException : Exception
    {
        /// <summary>
        /// Инициализирует новый экземпляр исключения ValidationException с указанным сообщением
        /// </summary>
        /// <param name="message">Сообщение об ошибке, описывающее причину исключения</param>
        /// <remarks>
        /// Сообщение должно четко указывать на причину ошибки валидации.
        /// Рекомендуется использовать понятные пользователю формулировки.
        /// </remarks>
        public ValidationException(string? message) : base(message)
        {
        }

    }
}
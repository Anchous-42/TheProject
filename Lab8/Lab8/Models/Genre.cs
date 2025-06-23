using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8.Models
{
    /// <summary>
    /// Перечисление жанров книг
    /// </summary>
    /// <remarks>
    /// Используется для классификации книг по жанровой принадлежности.
    /// Может быть расширено добавлением новых жанров при необходимости.
    /// </remarks>
    internal enum Genre
    {
        Horror,
        Fantasy,
        Thriller,
        Drama,
        Comedy
    }
}
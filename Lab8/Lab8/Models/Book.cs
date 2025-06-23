using Lab8.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8.Models
{
    /// <summary>
    /// Класс, представляющий книгу
    /// </summary>
    /// <remarks>
    /// Содержит информацию о книге и выполняет валидацию данных при установке значений.
    /// </remarks>
    internal class Book
    {
        private string _title;

        /// <summary>
        /// Название книги
        /// </summary>
        /// <exception cref="ValidationException">
        /// Выбрасывается при попытке установить пустое название или длиной более 100 символов
        /// </exception>
        public string Title
        {
            get => _title;
            set
            {
                if (value.Length <= 100 && value.Length > 0)
                {
                    _title = value;
                    return;
                }
                throw new ValidationException("Длина названия должна быть от 1 до 100 символов");
            }
        }

        private int _releaseYear;

        /// <summary>
        /// Год выпуска книги
        /// </summary>
        /// <exception cref="ValidationException">
        /// Выбрасывается при попытке установить год выпуска больше текущего
        /// </exception>
        public int ReleaseYear
        {
            get => _releaseYear;
            set
            {
                if (value <= DateTime.Now.Year)
                {
                    _releaseYear = value;
                    return;
                }
                throw new ValidationException($"Максимальный год выпуска: {DateTime.Now.Year}");
            }
        }

        private string _author;

        /// <summary>
        /// Автор книги
        /// </summary>
        public string Author
        {
            get => _author;
            set => _author = value;
        }

        private int _pages;

        /// <summary>
        /// Количество страниц в книге
        /// </summary>
        /// <exception cref="ValidationException">
        /// Выбрасывается при попытке установить количество страниц ≤ 0
        /// </exception>
        public int Pages
        {
            get => _pages;
            set
            {
                if (value > 0)
                {
                    _pages = value;
                    return;
                }
                throw new ValidationException("Количество страниц должно быть больше 0");
            }
        }

        private Genre _genre;

        /// <summary>
        /// Жанр книги
        /// </summary>
        public Genre Genre
        {
            get => _genre;
            set => _genre = value;
        }

        /// <summary>
        /// Создает новый экземпляр книги
        /// </summary>
        /// <param name="title">Название книги</param>
        /// <param name="releaseYear">Год выпуска</param>
        /// <param name="author">Автор</param>
        /// <param name="pages">Количество страниц</param>
        /// <param name="genre">Жанр</param>
        /// <exception cref="ValidationException">
        /// Может быть выброшено при невалидных значениях параметров
        /// </exception>
        public Book(
            string title,
            int releaseYear,
            string author,
            int pages,
            Genre genre
        )
        {
            Genre = genre;
            Title = title;
            Author = author;
            Pages = pages;
            ReleaseYear = releaseYear;
        }

        /// <summary>
        /// Возвращает строковое представление книги (название)
        /// </summary>
        /// <returns>Название книги</returns>
        public override string ToString()
        {
            return Title;
        }
    }
}



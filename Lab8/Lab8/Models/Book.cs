using Lab8.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8.Models
{
    internal class Book
    {
        private string _title;
        public string Title
        {
            get => _title; set
            {
                if (value.Length <= 100 && value.Length > 0)
                {
                    _title = value;
                    return;
                }
                throw new ValidationException("Title length must be <100 and >0");
            }
        }

        private int _releaseYear;
        public int ReleaseYear
        {
            get => _releaseYear; set
            {
                if (value <= DateTime.Now.Year)
                {
                    _releaseYear = value;
                    return;
                }

                throw new ValidationException($"Maximum release year is {DateTime.Now.Year}");
            }
        }

        private string _author;
        public string Author { get => _author; set => _author = value; }
        private int _pages;
        public int Pages
        {
            get => _pages; set {
                if (value > 0) { 
                    _pages = value;
                    return;
                }
                throw new ValidationException("Minimum page count is 1");
            }
        }
        private Genre _genre;
        public Genre Genre { get => _genre; set => _genre = value; }

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

        public override string ToString()
        {
            return Title;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheProject.Model
{
    /// <summary>
    /// Определяет категории кинематографических жанров.
    /// </summary>
    internal class Genre
    {
        /// <summary>
        /// Основные направления киножанров.
        /// </summary>
        public enum FilmGenre
        {
            Comedy,
            Drama,
            Thriller,
            Action,
            Horror,
            Blockbuster
        }
    }
}
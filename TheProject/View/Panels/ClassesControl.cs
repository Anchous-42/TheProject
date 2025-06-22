using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheProject.Model;
using TheProject.Model.Geometry;

namespace TheProject.View.Panels
{
    /// <summary>
    /// Пользовательский элемент управления для работы с геометрическими фигурами и фильмами
    /// </summary>
    public partial class ClassesControl : UserControl
    {
        // Коллекция прямоугольников
        private List<TheProject.Model.Geometry.Rectangle> _rectangles;
        // Текущий выбранный прямоугольник
        private TheProject.Model.Geometry.Rectangle _currentRectangle;
        // Массив фильмов
        private TheProject.Model.Film[] _films;
        // Текущий выбранный фильм
        private TheProject.Model.Film _currentFilm;

        /// <summary>
        /// Инициализирует элемент управления, создавая тестовые данные
        /// </summary>
        public ClassesControl()
        {
            Random random = new Random();
            InitializeComponent();

            // Настройка обработчиков событий
            listBoxFilms.SelectedIndexChanged += listBoxFilms_SelectedIndexChanged;
            listClassesChoice.SelectedIndexChanged += listClassesChoice_SelectedIndexChanged;

            // Инициализация коллекции прямоугольников
            _rectangles = new List<TheProject.Model.Geometry.Rectangle>();

            // Генерация случайных прямоугольников
            string[] colors = { "Red", "Blue", "Green", "Yellow", "Purple" };
            for (int i = 0; i < 5; i++)
            {
                double length = random.Next(10, 101);
                double width = random.Next(10, 101);
                string color = colors[random.Next(colors.Length)];
                Point2D center = new Point2D(random.Next(0, 501), random.Next(0, 501));

                var rect = new TheProject.Model.Geometry.Rectangle(length, width, color, center);
                _rectangles.Add(rect);
                listClassesChoice.Items.Add($"Rectangle {rect.Id}");
            }

            // Генерация тестовых фильмов
            _films = new TheProject.Model.Film[5];
            string[] filmNames = { "Фильм 1", "Фильм 2", "Фильм 3", "Фильм 4", "Фильм 5" };
            string[] genres = { "Комедия", "Драма", "Боевик", "Фантастика", "Мультфильм" };

            for (int i = 0; i < _films.Length; i++)
            {
                _films[i] = new TheProject.Model.Film(
                    filmNames[i],
                    random.Next(60, 181),
                    random.Next(1990, DateTime.Now.Year + 1),
                    genres[random.Next(genres.Length)],
                    random.Next(1, 11));

                listBoxFilms.Items.Add(filmNames[i]);
            }
        }

        /// <summary>
        /// Находит прямоугольник с максимальной шириной
        /// </summary>
        /// <returns>Индекс прямоугольника или -1 если коллекция пуста</returns>
        private int FindRectangleWithMaxWidth(List<TheProject.Model.Geometry.Rectangle> rectangles)
        {
            if (rectangles == null || rectangles.Count == 0)
                return -1;

            int maxIndex = 0;
            double maxWidth = rectangles[0].Width;

            for (int i = 1; i < rectangles.Count; i++)
            {
                if (rectangles[i].Width > maxWidth)
                {
                    maxWidth = rectangles[i].Width;
                    maxIndex = i;
                }
            }
            return maxIndex;
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки поиска прямоугольника
        /// </summary>
        private void buttonFindRect_Click(object sender, EventArgs e)
        {
            int index = FindRectangleWithMaxWidth(_rectangles);

            if (index != -1)
                listClassesChoice.SelectedIndex = index;
            else
                MessageBox.Show("Нет прямоугольников для поиска", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Обновляет интерфейс при выборе прямоугольника
        /// </summary>
        private void listClassesChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listClassesChoice.SelectedIndex >= 0 && listClassesChoice.SelectedIndex < _rectangles.Count)
            {
                _currentRectangle = _rectangles[listClassesChoice.SelectedIndex];
                UpdateRectangleInfo();
            }
            else
            {
                ClearRectangleInfo();
            }
        }

        /// <summary>
        /// Отображает информацию о выбранном прямоугольнике
        /// </summary>
        private void UpdateRectangleInfo()
        {
            if (_currentRectangle != null)
            {
                textBoxId.Text = _currentRectangle.Id.ToString();
                textBoxLength.Text = _currentRectangle.Length.ToString();
                textBoxWidth.Text = _currentRectangle.Width.ToString();
                textBoxColour.Text = _currentRectangle.Colour;
                textBoxCenterX.Text = _currentRectangle.Center.X.ToString();
                textBoxCenterY.Text = _currentRectangle.Center.Y.ToString();
            }
            else
            {
                ClearRectangleInfo();
            }
        }

        /// <summary>
        /// Очищает информацию о прямоугольнике
        /// </summary>
        private void ClearRectangleInfo()
        {
            textBoxId.Text = "";
            textBoxLength.Text = "";
            textBoxWidth.Text = "";
            textBoxColour.Text = "";
            textBoxCenterX.Text = "";
            textBoxCenterY.Text = "";
        }

        /// <summary>
        /// Обновляет интерфейс при выборе фильма
        /// </summary>
        private void listBoxFilms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxFilms.SelectedIndex >= 0 && listBoxFilms.SelectedIndex < _films.Length)
            {
                _currentFilm = _films[listBoxFilms.SelectedIndex];
                UpdateFilmInfo();
            }
        }

        /// <summary>
        /// Отображает информацию о выбранном фильме
        /// </summary>
        private void UpdateFilmInfo()
        {
            if (_currentFilm != null)
            {
                textBoxFilmName.Text = _currentFilm.NameFilm;
                textBoxFilmDuration.Text = _currentFilm.DurationFilm.ToString();
                textBoxFilmYear.Text = _currentFilm.YearOfFilm.ToString();
                textBoxFilmGenre.Text = _currentFilm.GenreFilm;
                textBoxFilmRating.Text = _currentFilm.RatingFilm.ToString();
            }
            else
            {
                ClearFilmInfo();
            }
        }

        /// <summary>
        /// Очищает информацию о фильме
        /// </summary>
        private void ClearFilmInfo()
        {
            textBoxFilmName.Text = "";
            textBoxFilmDuration.Text = "";
            textBoxFilmYear.Text = "";
            textBoxFilmGenre.Text = "";
            textBoxFilmRating.Text = "";
        }

        /// <summary>
        /// Обрабатывает изменение названия фильма
        /// </summary>
        private void textBoxFilmName_TextChanged(object sender, EventArgs e)
        {
            if (_currentFilm != null)
                _currentFilm.NameFilm = textBoxFilmName.Text;
        }

        /// <summary>
        /// Валидирует и обновляет продолжительность фильма
        /// </summary>
        private void textBoxFilmDuration_TextChanged(object sender, EventArgs e)
        {
            if (_currentFilm != null)
            {
                try
                {
                    _currentFilm.DurationFilm = ValidateNumberInput(
                        textBoxFilmDuration.Text,
                        textBoxFilmDuration,
                        0,
                        int.MaxValue,
                        "Продолжительность фильма");
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxFilmDuration.Text = _currentFilm.DurationFilm.ToString();
                }
            }
        }

        /// <summary>
        /// Валидирует и обновляет год выпуска фильма
        /// </summary>
        private void textBoxFilmYear_TextChanged(object sender, EventArgs e)
        {
            if (_currentFilm != null)
            {
                try
                {
                    _currentFilm.YearOfFilm = ValidateNumberInput(
                        textBoxFilmYear.Text,
                        textBoxFilmYear,
                        0,
                        9999,
                        "Год фильма");
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxFilmYear.Text = _currentFilm.YearOfFilm.ToString();
                }
            }
        }

        /// <summary>
        /// Обрабатывает изменение жанра фильма
        /// </summary>
        private void textBoxFilmGenre_TextChanged(object sender, EventArgs e)
        {
            if (_currentFilm != null)
                _currentFilm.GenreFilm = textBoxFilmGenre.Text;
        }

        /// <summary>
        /// Валидирует и обновляет рейтинг фильма
        /// </summary>
        private void textBoxFilmRating_TextChanged(object sender, EventArgs e)
        {
            if (_currentFilm != null)
            {
                try
                {
                    _currentFilm.RatingFilm = ValidateNumberInput(
                        textBoxFilmRating.Text,
                        textBoxFilmRating,
                        0,
                        10,
                        "Рейтинг фильма");
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxFilmRating.Text = _currentFilm.RatingFilm.ToString();
                }
            }
        }

        /// <summary>
        /// Валидирует числовой ввод и устанавливает цвет фона
        /// </summary>
        private int ValidateNumberInput(string text, TextBox textBox, int min, int max, string fieldName)
        {
            try
            {
                if (string.IsNullOrEmpty(text))
                {
                    textBox.BackColor = AppColors.ValidInputColor;
                    return 0;
                }

                int value = int.Parse(text);
                Validator.AssertValueInRange(value, min, max, fieldName);
                textBox.BackColor = AppColors.ValidInputColor;
                return value;
            }
            catch (FormatException)
            {
                textBox.BackColor = AppColors.ValidationErrorColor;
                throw new ArgumentException($"Некорректное значение для '{fieldName}'. Введите целое число.");
            }
            catch (ArgumentException ex)
            {
                textBox.BackColor = AppColors.ValidationErrorColor;
                throw new ArgumentException($"Ошибка валидации: {ex.Message}");
            }
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки поиска фильма
        /// </summary>
        private void buttonFindFilm_Click(object sender, EventArgs e)
        {
            int index = FindHighestRatedFilm(_films);

            if (index != -1)
                listBoxFilms.SelectedIndex = index;
            else
                MessageBox.Show("Нет фильмов для поиска", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Находит фильм с наивысшим рейтингом
        /// </summary>
        /// <returns>Индекс фильма или -1 если коллекция пуста</returns>
        private int FindHighestRatedFilm(TheProject.Model.Film[] films)
        {
            if (films == null || films.Length == 0)
                return -1;

            int maxIndex = 0;
            int maxRating = films[0].RatingFilm;

            for (int i = 1; i < films.Length; i++)
            {
                if (films[i].RatingFilm > maxRating)
                {
                    maxRating = films[i].RatingFilm;
                    maxIndex = i;
                }
            }
            return maxIndex;
        }
    }
}
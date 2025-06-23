using Lab8.Models;

namespace Lab8
{
    /// <summary>
    /// Главная форма приложения для управления записями о книгах
    /// </summary>
    public partial class MainForm : Form
    {
        // Флаг для предотвращения рекурсивных обновлений при изменении элементов управления
        private bool _isUpdatingView = false;

        // Репозиторий для работы с записями о книгах
        private RecordsRepository<Book> _bookRepository;

        /// <summary>
        /// Инициализирует главную форму
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик события закрытия формы для сохранения данных
        /// </summary>
        private void MainForm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            _bookRepository.SaveToFile();
        }

        /// <summary>
        /// Обработчик события загрузки формы для инициализации данных и интерфейса
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Инициализация выпадающего списка жанров значениями из перечисления
            GenreComboBox.DataSource = Enum.GetValues(typeof(Genre));

            // Настройка пути для сохранения данных о книгах
            string saveFileName = "BooksDB.json";
            string saveDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string savePath = Path.Combine(saveDir, saveFileName);

            // Инициализация репозитория
            _bookRepository = new RecordsRepository<Book>(savePath);

            // Загрузка и отображение книг, отсортированных по названию
            _bookRepository.GetRecords()
                .OrderBy((x) => x.Data.Title)
                .Each((book, i) =>
                {
                    BooksList.Items.Add(book);
                });

            UpdateBooksList();
        }

        /// <summary>
        /// Обновляет отображение списка книг
        /// </summary>
        private void UpdateBooksList()
        {
            // Запоминаем текущее выделение, чтобы восстановить после обновления
            var currentSelection = BooksList.SelectedItem;

            // Начинаем обновление списка (блокируем перерисовку)
            BooksList.BeginUpdate();
            try
            {
                BooksList.DataSource = null;
                // Устанавливаем новый источник данных (отсортированный список книг)
                BooksList.DataSource = _bookRepository.GetRecords()
                    .OrderBy(x => x.Data.Title)
                    .ToList();
                BooksList.DisplayMember = "Data.Title";

                // Восстанавливаем выделенный элемент, если он был
                if (currentSelection != null)
                    BooksList.SelectedItem = currentSelection;
            }
            finally
            {
                // Завершаем обновление списка (разрешаем перерисовку)
                BooksList.EndUpdate();
            }

            // Активируем/деактивируем элементы управления в зависимости от наличия выделения
            SetControlsEnable(BooksList.SelectedItem != null);
        }

        /// <summary>
        /// Устанавливает текущую выделенную книгу по ID
        /// </summary>
        /// <param name="id">ID книги для выделения</param>
        private void SetCurrentBookSelectedById(int id)
        {
            // Поиск книги с указанным ID в списке
            foreach (Record<Book> rec in BooksList.Items)
            {
                if (rec.Id == id)
                {
                    BooksList.SelectedItem = rec;
                    break;
                }
            }

            // Обновляем отображение выбранной книги
            UpdateView((Record<Book>)BooksList.SelectedItem);
        }

        /// <summary>
        /// Устанавливает текущую книгу по индексу
        /// </summary>
        /// <param name="i">Индекс книги в списке</param>
        private void SetCurrentBookIndex(int i)
        {
            // Проверка на выход за границы списка
            if (i < 0 || i >= BooksList.Items.Count) return;

            BooksList.SelectedIndex = i;
            UpdateView((Record<Book>)BooksList.SelectedItem);
        }

        /// <summary>
        /// Обновляет отображение информации о выбранной книге
        /// </summary>
        /// <param name="bookRecord">Запись о книге для отображения</param>
        private void UpdateView(Record<Book> bookRecord)
        {
            // Если книга не выбрана - деактивируем элементы управления
            if (bookRecord == null)
            {
                SetControlsEnable(false);
                return;
            }

            var currentBook = bookRecord.Data;

            // Обновляем элементы управления, не вызывая их события изменения
            _isUpdatingView = true;
            try
            {
                AuthorTextBox.Text = currentBook.Author;
                TitleTextBox.Text = currentBook.Title;
                GenreComboBox.SelectedItem = currentBook.Genre;
                ReleaseYearTextBox.Text = currentBook.ReleaseYear.ToString();
                PagesCountTextBox.Text = currentBook.Pages.ToString();
            }
            finally
            {
                _isUpdatingView = false;
            }

            SetControlsEnable(true);
        }

        /// <summary>
        /// Устанавливает доступность элементов управления
        /// </summary>
        /// <param name="enabled">Флаг доступности</param>
        private void SetControlsEnable(bool enabled)
        {
            AuthorTextBox.Enabled = enabled;
            TitleTextBox.Enabled = enabled;
            ReleaseYearTextBox.Enabled = enabled;
            GenreComboBox.Enabled = enabled;
            PagesCountTextBox.Enabled = enabled;
            DeleteButton.Enabled = enabled;
        }

        /// <summary>
        /// Обработчик нажатия кнопки добавления новой книги
        /// </summary>
        private void AddButton_Click(object sender, EventArgs e)
        {
            // Добавляем новую книгу с начальными значениями
            int recId = _bookRepository.Add(new Book(
                title: $"Неизвестная книга ({_bookRepository.GetIdCounter()})",
                genre: Genre.Horror,
                author: "Неизвестный автор",
                releaseYear: 2000,
                pages: 1
            ));

            // Обновляем список и выделяем новую книгу
            UpdateBooksList();
            SetCurrentBookSelectedById(recId);
        }

        /// <summary>
        /// Обработчик изменения выбранного элемента в списке книг
        /// </summary>
        private void BooksList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Игнорируем событие, если идет обновление представления или нет выделения
            if (_isUpdatingView || BooksList.SelectedItem == null) return;

            try
            {
                _isUpdatingView = true;
                var selectedBook = (Record<Book>)BooksList.SelectedItem;
                UpdateView(selectedBook);
            }
            finally
            {
                _isUpdatingView = false;
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки удаления книги
        /// </summary>
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            // Удаляем книгу по ID и обновляем список
            _bookRepository.RemoveById(((Record<Book>)BooksList.SelectedItem).Id);
            UpdateBooksList();
        }

        /// <summary>
        /// Обработчик изменения текста в поле года выпуска
        /// </summary>
        private void ReleaseYearTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_isUpdatingView || BooksList.SelectedItem == null) return;
            try
            {
                _isUpdatingView = true;
                Record<Book> rec = (Record<Book>)BooksList.SelectedItem;
                rec.Data.ReleaseYear = int.Parse(ReleaseYearTextBox.Text);
                _bookRepository.UpdateById(rec.Id, rec.Data);
                ReleaseYearTextBox.BackColor = Color.White;
            }
            catch
            {
                // Подсвечиваем поле красным при ошибке ввода
                ReleaseYearTextBox.BackColor = Color.Red;
            }
            finally
            {
                _isUpdatingView = false;
            }
        }

        /// <summary>
        /// Обработчик изменения текста в поле названия
        /// </summary>
        private void TitleTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_isUpdatingView || BooksList.SelectedItem == null) return;

            try
            {
                _isUpdatingView = true;
                var rec = (Record<Book>)BooksList.SelectedItem;
                rec.Data.Title = TitleTextBox.Text;
                _bookRepository.UpdateById(rec.Id, rec.Data);
                TitleTextBox.BackColor = Color.White;
            }
            catch
            {
                TitleTextBox.BackColor = Color.Red;
            }
            finally
            {
                _isUpdatingView = false;
            }
        }

        /// <summary>
        /// Обработчик изменения текста в поле автора
        /// </summary>
        private void AuthorTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_isUpdatingView || BooksList.SelectedItem == null) return;
            try
            {
                _isUpdatingView = true;
                Record<Book> rec = (Record<Book>)BooksList.SelectedItem;
                rec.Data.Author = AuthorTextBox.Text;
                _bookRepository.UpdateById(rec.Id, rec.Data);
                AuthorTextBox.BackColor = Color.White;
            }
            catch
            {
                AuthorTextBox.BackColor = Color.Red;
            }
            finally
            {
                _isUpdatingView = false;
            }
        }

        /// <summary>
        /// Обработчик изменения текста в поле количества страниц
        /// </summary>
        private void PagesCountTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_isUpdatingView || BooksList.SelectedItem == null) return;
            try
            {
                Record<Book> rec = (Record<Book>)BooksList.SelectedItem;
                rec.Data.Pages = int.Parse(PagesCountTextBox.Text);
                _bookRepository.UpdateById(rec.Id, rec.Data);
                PagesCountTextBox.BackColor = Color.White;
            }
            catch
            {
                PagesCountTextBox.BackColor = Color.Red;
            }
            finally
            {
                _isUpdatingView = false;
            }
        }

        /// <summary>
        /// Обработчик изменения выбранного жанра
        /// </summary>
        private void GenreComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (_isUpdatingView || BooksList.SelectedItem == null) return;

            try
            {
                _isUpdatingView = true;
                var rec = (Record<Book>)BooksList.SelectedItem;
                rec.Data.Genre = (Genre)GenreComboBox.SelectedValue;
                _bookRepository.UpdateById(rec.Id, rec.Data);
                GenreComboBox.BackColor = Color.White;
            }
            catch
            {
                GenreComboBox.BackColor = Color.Red;
            }
            finally
            {
                _isUpdatingView = false;
            }
        }
    }
}
using Lab8.Models;

namespace Lab8
{
    /// <summary>
    /// ������� ����� ���������� ��� ���������� �������� � ������
    /// </summary>
    public partial class MainForm : Form
    {
        // ���� ��� �������������� ����������� ���������� ��� ��������� ��������� ����������
        private bool _isUpdatingView = false;

        // ����������� ��� ������ � �������� � ������
        private RecordsRepository<Book> _bookRepository;

        /// <summary>
        /// �������������� ������� �����
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ���������� ������� �������� ����� ��� ���������� ������
        /// </summary>
        private void MainForm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            _bookRepository.SaveToFile();
        }

        /// <summary>
        /// ���������� ������� �������� ����� ��� ������������� ������ � ����������
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            // ������������� ����������� ������ ������ ���������� �� ������������
            GenreComboBox.DataSource = Enum.GetValues(typeof(Genre));

            // ��������� ���� ��� ���������� ������ � ������
            string saveFileName = "BooksDB.json";
            string saveDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string savePath = Path.Combine(saveDir, saveFileName);

            // ������������� �����������
            _bookRepository = new RecordsRepository<Book>(savePath);

            // �������� � ����������� ����, ��������������� �� ��������
            _bookRepository.GetRecords()
                .OrderBy((x) => x.Data.Title)
                .Each((book, i) =>
                {
                    BooksList.Items.Add(book);
                });

            UpdateBooksList();
        }

        /// <summary>
        /// ��������� ����������� ������ ����
        /// </summary>
        private void UpdateBooksList()
        {
            // ���������� ������� ���������, ����� ������������ ����� ����������
            var currentSelection = BooksList.SelectedItem;

            // �������� ���������� ������ (��������� �����������)
            BooksList.BeginUpdate();
            try
            {
                BooksList.DataSource = null;
                // ������������� ����� �������� ������ (��������������� ������ ����)
                BooksList.DataSource = _bookRepository.GetRecords()
                    .OrderBy(x => x.Data.Title)
                    .ToList();
                BooksList.DisplayMember = "Data.Title";

                // ��������������� ���������� �������, ���� �� ���
                if (currentSelection != null)
                    BooksList.SelectedItem = currentSelection;
            }
            finally
            {
                // ��������� ���������� ������ (��������� �����������)
                BooksList.EndUpdate();
            }

            // ����������/������������ �������� ���������� � ����������� �� ������� ���������
            SetControlsEnable(BooksList.SelectedItem != null);
        }

        /// <summary>
        /// ������������� ������� ���������� ����� �� ID
        /// </summary>
        /// <param name="id">ID ����� ��� ���������</param>
        private void SetCurrentBookSelectedById(int id)
        {
            // ����� ����� � ��������� ID � ������
            foreach (Record<Book> rec in BooksList.Items)
            {
                if (rec.Id == id)
                {
                    BooksList.SelectedItem = rec;
                    break;
                }
            }

            // ��������� ����������� ��������� �����
            UpdateView((Record<Book>)BooksList.SelectedItem);
        }

        /// <summary>
        /// ������������� ������� ����� �� �������
        /// </summary>
        /// <param name="i">������ ����� � ������</param>
        private void SetCurrentBookIndex(int i)
        {
            // �������� �� ����� �� ������� ������
            if (i < 0 || i >= BooksList.Items.Count) return;

            BooksList.SelectedIndex = i;
            UpdateView((Record<Book>)BooksList.SelectedItem);
        }

        /// <summary>
        /// ��������� ����������� ���������� � ��������� �����
        /// </summary>
        /// <param name="bookRecord">������ � ����� ��� �����������</param>
        private void UpdateView(Record<Book> bookRecord)
        {
            // ���� ����� �� ������� - ������������ �������� ����������
            if (bookRecord == null)
            {
                SetControlsEnable(false);
                return;
            }

            var currentBook = bookRecord.Data;

            // ��������� �������� ����������, �� ������� �� ������� ���������
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
        /// ������������� ����������� ��������� ����������
        /// </summary>
        /// <param name="enabled">���� �����������</param>
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
        /// ���������� ������� ������ ���������� ����� �����
        /// </summary>
        private void AddButton_Click(object sender, EventArgs e)
        {
            // ��������� ����� ����� � ���������� ����������
            int recId = _bookRepository.Add(new Book(
                title: $"����������� ����� ({_bookRepository.GetIdCounter()})",
                genre: Genre.Horror,
                author: "����������� �����",
                releaseYear: 2000,
                pages: 1
            ));

            // ��������� ������ � �������� ����� �����
            UpdateBooksList();
            SetCurrentBookSelectedById(recId);
        }

        /// <summary>
        /// ���������� ��������� ���������� �������� � ������ ����
        /// </summary>
        private void BooksList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ���������� �������, ���� ���� ���������� ������������� ��� ��� ���������
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
        /// ���������� ������� ������ �������� �����
        /// </summary>
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            // ������� ����� �� ID � ��������� ������
            _bookRepository.RemoveById(((Record<Book>)BooksList.SelectedItem).Id);
            UpdateBooksList();
        }

        /// <summary>
        /// ���������� ��������� ������ � ���� ���� �������
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
                // ������������ ���� ������� ��� ������ �����
                ReleaseYearTextBox.BackColor = Color.Red;
            }
            finally
            {
                _isUpdatingView = false;
            }
        }

        /// <summary>
        /// ���������� ��������� ������ � ���� ��������
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
        /// ���������� ��������� ������ � ���� ������
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
        /// ���������� ��������� ������ � ���� ���������� �������
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
        /// ���������� ��������� ���������� �����
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
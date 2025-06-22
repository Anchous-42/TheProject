using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TheProject.Model;
using TheProject.Model.Geometry;

namespace TheProject.View.Panels
{
    // Контрол для работы с прямоугольниками и их пересечениями
    public partial class RectanglesCollisionControl : UserControl
    {
        private List<Model.Geometry.Rectangle> _rectangles; // Список всех прямоугольников
        private Model.Geometry.Rectangle _currentRectangle; // Текущий выбранный прямоугольник

        public RectanglesCollisionControl()
        {
            InitializeComponent();
            _rectangles = new List<Model.Geometry.Rectangle>();

            // Настройка контрола
            FillListBoxRectangles();
            listBoxRectanglesPage.SelectedIndexChanged += listBoxRectanglesPage_SelectedIndexChanged;
            panelCanvas.Paint += panelCanvas_Paint;

            // Подписка на события изменения параметров
            textBoxRectX.TextChanged += textBoxRectX_TextChanged;
            textBoxRectY.TextChanged += textBoxRectY_TextChanged;
            textBoxRectWidth.TextChanged += textBoxRectWidth_TextChanged;
            textBoxRectHeight.TextChanged += textBoxRectHeight_TextChanged;
        }

        // Парсит число из текстового поля с валидацией
        private double ParseDouble(string text, TextBox textBox)
        {
            try
            {
                double value = double.Parse(text);
                if (value < 0)
                {
                    textBox.BackColor = AppColors.ValidationErrorColor;
                    throw new ArgumentException("Значение должно быть ≥ 0");
                }

                textBox.BackColor = AppColors.ValidInputColor;
                return value;
            }
            catch (FormatException)
            {
                textBox.BackColor = AppColors.ValidationErrorColor;
                throw new FormatException("Некорректное число");
            }
            catch (ArgumentException ex)
            {
                textBox.BackColor = AppColors.ValidationErrorColor;
                throw ex;
            }
        }

        // Обновляет список прямоугольников в ListBox
        private void FillListBoxRectangles()
        {
            listBoxRectanglesPage.Items.Clear();

            foreach (var rect in _rectangles)
            {
                listBoxRectanglesPage.Items.Add(
                    $"Id: {rect.Id}, X: {rect.Center.X}, Y: {rect.Center.Y}, " +
                    $"Width: {rect.Width}, Height: {rect.Length}");
            }
        }

        // Отображает данные прямоугольника в полях ввода
        private void UpdateRectangleInfo(Model.Geometry.Rectangle rectangle)
        {
            if (rectangle != null)
            {
                textBoxRectID.Text = rectangle.Id.ToString();
                textBoxRectX.Text = rectangle.Center.X.ToString();
                textBoxRectY.Text = rectangle.Center.Y.ToString();
                textBoxRectWidth.Text = rectangle.Width.ToString();
                textBoxRectHeight.Text = rectangle.Length.ToString();
            }
            else
            {
                ClearRectangleInfo();
            }
        }

        // Очищает поля ввода
        private void ClearRectangleInfo()
        {
            textBoxRectID.Text = "";
            textBoxRectX.Text = "";
            textBoxRectY.Text = "";
            textBoxRectWidth.Text = "";
            textBoxRectHeight.Text = "";
        }

        // Обработчики изменения параметров прямоугольника
        private void textBoxRectX_TextChanged(object sender, EventArgs e)
        {
            UpdateRectangleParameter(
                textBoxRectX,
                value => _currentRectangle.Center.X = value,
                () => _currentRectangle.Center.X);
        }

        private void textBoxRectY_TextChanged(object sender, EventArgs e)
        {
            UpdateRectangleParameter(
                textBoxRectY,
                value => _currentRectangle.Center.Y = value,
                () => _currentRectangle.Center.Y);
        }

        private void textBoxRectWidth_TextChanged(object sender, EventArgs e)
        {
            UpdateRectangleParameter(
                textBoxRectWidth,
                value => _currentRectangle.Width = value,
                () => _currentRectangle.Width);
        }

        private void textBoxRectHeight_TextChanged(object sender, EventArgs e)
        {
            UpdateRectangleParameter(
                textBoxRectHeight,
                value => _currentRectangle.Length = value,
                () => _currentRectangle.Length);
        }

        // Общий метод для обновления параметров прямоугольника
        private void UpdateRectangleParameter(TextBox textBox, Action<double> setValue, Func<double> getOriginalValue)
        {
            if (_currentRectangle == null || !textBox.Focused)
                return;

            try
            {
                setValue(ParseDouble(textBox.Text, textBox));
                FillListBoxRectangles();
                panelCanvas.Invalidate();
            }
            catch (Exception ex) when (ex is ArgumentException || ex is FormatException)
            {
                MessageBox.Show(ex.Message, "Ошибка ввода");
                textBox.Text = getOriginalValue().ToString();
            }
        }

        // Добавляет случайный прямоугольник
        private void buttonAddRect_Click(object sender, EventArgs e)
        {
            var newRect = RectangleFactory.Randomize(panelCanvas.Width, panelCanvas.Height);
            _rectangles.Add(newRect);

            FillListBoxRectangles();
            listBoxRectanglesPage.SelectedIndex = _rectangles.Count - 1;
            panelCanvas.Invalidate();
        }

        // Удаляет выбранный прямоугольник
        private void buttonDeleteRect_Click(object sender, EventArgs e)
        {
            if (listBoxRectanglesPage.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите прямоугольник для удаления");
                return;
            }

            int selectedIndex = listBoxRectanglesPage.SelectedIndex;
            _rectangles.RemoveAt(selectedIndex);

            FillListBoxRectangles();

            if (_rectangles.Count > 0)
            {
                listBoxRectanglesPage.SelectedIndex = Math.Min(selectedIndex, _rectangles.Count - 1);
            }
            else
            {
                ClearRectangleInfo();
                _currentRectangle = null;
            }

            panelCanvas.Invalidate();
        }

        // Обрабатывает выбор прямоугольника в списке
        private void listBoxRectanglesPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxRectanglesPage.SelectedIndex >= 0 &&
                listBoxRectanglesPage.SelectedIndex < _rectangles.Count)
            {
                _currentRectangle = _rectangles[listBoxRectanglesPage.SelectedIndex];
                UpdateRectangleInfo(_currentRectangle);
            }
            else
            {
                _currentRectangle = null;
                ClearRectangleInfo();
            }
        }

        // Отрисовывает прямоугольники на панели
        private void panelCanvas_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(AppColors.DefaultBorderColor, 2))
            {
                if (_rectangles == null || _rectangles.Count == 0)
                    return;

                for (int i = 0; i < _rectangles.Count; i++)
                {
                    var currentRect = _rectangles[i];
                    bool isIntersecting = CheckCollisions(currentRect, i);

                    using (var fillBrush = new SolidBrush(
                        isIntersecting ? AppColors.CollisionColor : AppColors.NoCollisionColor))
                    {
                        var drawRect = new System.Drawing.Rectangle(
                            (int)(currentRect.Center.X - currentRect.Width / 2),
                            (int)(currentRect.Center.Y - currentRect.Length / 2),
                            (int)currentRect.Width,
                            (int)currentRect.Length);

                        e.Graphics.FillRectangle(fillBrush, drawRect);
                    }
                }
            }
        }

        // Проверяет коллизии для прямоугольника
        private bool CheckCollisions(Model.Geometry.Rectangle rect, int excludeIndex)
        {
            for (int j = 0; j < _rectangles.Count; j++)
            {
                if (j == excludeIndex) continue;

                if (CollisionManager.IsCollision(rect, _rectangles[j]))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
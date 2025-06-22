using System.Drawing;
using System.Windows.Forms;

namespace TheProject.View.Panels
{
    /// <summary>
    /// Существует для показания цвета выбранного месяца в разделе Enums Mainform.
    /// </summary>
    public partial class ColorDisplayForm : Form
    {
        /// <summary>
        /// Отображает заданный цвет в зависимости от выбранного месяца в разделе Enmus Mainform.
        /// </summary>
        /// <param name="backgroundColor">Передаваемый цвет, зависящий от выбранного месяца в Enums.</param>
        public ColorDisplayForm(Color backgroundColor)
        {
            InitializeComponent();
            this.BackColor = backgroundColor; // Устанавливаем фоновый цвет формы
            this.Text = "Выбранный сезон"; // Устанавливаем заголовок окна

            // Добавляем кнопку ОК
            Button okButton = new Button();
            okButton.Text = "ОК";
            okButton.DialogResult = DialogResult.OK; // Устанавливаем DialogResult для автоматического закрытия
            okButton.Location = new Point((this.ClientSize.Width - okButton.Width) / 2, this.ClientSize.Height - okButton.Height - 10);
            okButton.Anchor = AnchorStyles.Bottom; // Привязка к низу формы
            this.Controls.Add(okButton);
        }
    }
}
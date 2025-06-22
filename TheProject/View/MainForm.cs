using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using TheProject.Model;
using TheProject.Model.Geometry;
using System.Collections.Generic;
using System.Drawing;

namespace TheProject
{
    /// <summary>
    /// Основное окно приложения.
    /// Служит главным интерфейсом пользователя после запуска программы.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Создает экземпляр главной формы приложения.
        /// </summary>
        public MainForm()
        {
            InitializeComponent(); // Автоматически инициализирует компоненты интерфейса,
                                   // созданные в конструкторе Windows Forms
        }
    }
}
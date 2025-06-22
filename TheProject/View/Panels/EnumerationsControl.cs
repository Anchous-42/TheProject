using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheProject.Model;

namespace TheProject.View.Panels
{
    // Пользовательский контрол для работы с перечислениями
    public partial class EnumerationsControl : UserControl
    {
        // Хранит тип текущего выбранного перечисления
        private Type selectedEnumType;

        // Инициализация контрола
        public EnumerationsControl()
        {
            InitializeComponent();
            LoadClasses(); // Загружаем классы с перечислениями
            // Заполняем комбобокс значениями перечисления Seasons.Season
            comboBoxSeason.DataSource = Enum.GetValues(typeof(Seasons.Season));
            // Подписываемся на события выбора элементов
            listEnumChoice.SelectedIndexChanged += listEnumChoice_SelectedIndexChanged;
            listValueChoice.SelectedIndexChanged += listValueChoice_SelectedIndexChanged;
        }

        // Загрузка классов из пространства имен Model
        private void LoadClasses()
        {
            if (listEnumChoice == null)
            {
                MessageBox.Show("Ошибка: listEnumChoice не инициализирован!", "Ошибка");
                return;
            }

            listEnumChoice.Items.Clear(); // Очищаем список перед заполнением

            // Получаем все классы из сборки в пространстве имен Model
            var assembly = Assembly.GetExecutingAssembly();
            var classTypes = assembly.GetTypes()
                .Where(t => t.IsClass && t.Namespace == "TheProject.Model")
                .ToList();

            if (classTypes.Count == 0)
            {
                MessageBox.Show("Не найдено классов в TheProject.Model!", "Ошибка");
                return;
            }

            // Добавляем имена классов в список
            foreach (var type in classTypes)
            {
                listEnumChoice.Items.Add(type.Name);
            }

            if (listEnumChoice.Items.Count > 0)
                listEnumChoice.SelectedIndex = 0; // Выбираем первый элемент
        }

        // Обработчик выбора класса
        private void listEnumChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listEnumChoice.SelectedItem != null)
            {
                listValueChoice.Items.Clear(); // Очищаем список значений

                string className = listEnumChoice.SelectedItem.ToString();
                Assembly assembly = typeof(Program).Assembly;
                Type classType = assembly.GetType($"TheProject.Model.{className}");

                if (classType != null)
                {
                    // Получаем все вложенные перечисления
                    var enumTypes = classType.GetNestedTypes(BindingFlags.Public | BindingFlags.NonPublic)
                        .Where(t => t.IsEnum)
                        .ToList();

                    if (enumTypes.Count == 0)
                    {
                        Console.WriteLine($"В классе {className} нет перечислений");
                        return;
                    }

                    // Добавляем значения всех перечислений
                    foreach (var enumType in enumTypes)
                    {
                        foreach (var value in Enum.GetValues(enumType))
                        {
                            listValueChoice.Items.Add(value.ToString());
                            Console.WriteLine($"Добавлено значение: {value}");
                        }
                    }

                    if (listValueChoice.Items.Count > 0)
                    {
                        listValueChoice.SelectedIndex = 0; // Выбираем первое значение
                    }
                }
                else
                {
                    MessageBox.Show($"Класс {className} не найден", "Ошибка");
                    Console.WriteLine($"Класс {className} не найден");
                }
            }
        }

        // Обработчик выбора значения перечисления
        private void listValueChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listValueChoice.SelectedItem != null)
            {
                string className = listEnumChoice.SelectedItem.ToString();
                Assembly assembly = typeof(Program).Assembly;
                Type classType = assembly.GetType($"TheProject.Model.{className}");

                if (classType != null)
                {
                    // Ищем выбранное значение среди всех перечислений класса
                    foreach (var enumType in classType.GetNestedTypes(BindingFlags.Public | BindingFlags.NonPublic))
                    {
                        if (!enumType.IsEnum) continue;

                        foreach (var value in Enum.GetValues(enumType))
                        {
                            if (value.ToString() == listValueChoice.SelectedItem.ToString())
                            {
                                selectedEnumType = enumType;
                                Enum enumValue = (Enum)Enum.Parse(enumType, listValueChoice.SelectedItem.ToString());
                                // Выводим числовое значение (+1 для 1-based индексации)
                                textBoxIntChoice.Text = ((int)Convert.ChangeType(enumValue, TypeCode.Int32) + 1).ToString();
                                return;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show($"Класс {className} не найден", "Ошибка");
                    Console.WriteLine($"Класс {className} не найден");
                }
            }
        }

        // Обработчик кнопки Parse - преобразует текст в значение перечисления
        private void buttonParse_Click(object sender, EventArgs e)
        {
            string input = textBoxParse.Text;
            if (Enum.TryParse(input, true, out Weekday.WeekDay day))
            {
                labelParseResult.Text = $"Это день недели ({day} = {(int)day + 1})";
            }
            else
            {
                labelParseResult.Text = "Нет такого дня недели";
            }
        }

        // Обработчик выбора времени года
        private void buttonSeason_Click(object sender, EventArgs e)
        {
            Seasons.Season season = (Seasons.Season)comboBoxSeason.SelectedItem;

            switch (season)
            {
                case Seasons.Season.Summer:
                    MessageBox.Show("Yay! Sun!");
                    break;
                case Seasons.Season.Fall:
                    ShowColorForm(AppColors.FallBackground);
                    break;
                case Seasons.Season.Winter:
                    MessageBox.Show("Brrr! So cold!");
                    break;
                case Seasons.Season.Spring:
                    ShowColorForm(AppColors.SpringBackground);
                    break;
            }
        }

        // Вспомогательный метод для показа формы с цветом
        private void ShowColorForm(Color color)
        {
            using (var form = new ColorDisplayForm(color))
            {
                form.ShowDialog();
            }
        }
    }
}
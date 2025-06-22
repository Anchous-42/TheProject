using System;
using System.Drawing;

namespace TheProject.Model
{
    /// <summary>
    /// Стандартная цветовая палитра приложения для единообразия визуального стиля.
    /// </summary>
    internal class AppColors
    {
        /// <summary>
        /// Цвет подсветки невалидных полей ввода
        /// </summary>
        public static readonly Color ValidationErrorColor = Color.LightPink;

        /// <summary>
        /// Стандартный цвет фона валидных полей ввода
        /// </summary>
        public static readonly Color ValidInputColor = SystemColors.Window;

        /// <summary>
        /// Цвет для объектов в состоянии коллизии
        /// </summary>
        public static readonly Color CollisionColor = Color.Red;

        /// <summary>
        /// Цвет для объектов без коллизий
        /// </summary>
        public static readonly Color NoCollisionColor = Color.Green;

        /// <summary>
        /// Сезонный цвет фона (осенняя тема)
        /// </summary>
        public static readonly Color FallBackground = Color.Orange;

        /// <summary>
        /// Сезонный цвет фона (весенняя тема)
        /// </summary>
        public static readonly Color SpringBackground = Color.LightGreen;

        /// <summary>
        /// Базовый цвет границ элементов
        /// </summary>
        public static readonly Color DefaultBorderColor = Color.Black;
    }
}
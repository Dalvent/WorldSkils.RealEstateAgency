using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RealEstateAgency
{
    /// <summary>
    /// Оболочка над основным кадром в интерфейсе программы.
    /// </summary>
    public static class FrameManager
    {
        public static Frame _frame;

        /// <summary>
        /// Инициализирует класс, должен быть вызван перед остальными методами.
        /// </summary>
        /// <param name="frame">Кадр, которым будет управлять класс</param>
        public static void Init(Frame frame)
        {
            _frame = frame;
        }

        /// <summary>
        /// Переход на выбранную страницу.
        /// </summary>
        /// <param name="page"></param>
        public static void Navigate(Page page)
        {
            _frame.Navigate(page);
        }
        /// <summary>
        /// Возращает на предыдущую страницу.
        /// </summary>
        public static void GoBack()
        {
            _frame.GoBack();
        }

    }
}

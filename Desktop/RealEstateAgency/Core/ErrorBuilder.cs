using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency
{
    class ErrorBuilder
    {
        StringBuilder errors = new StringBuilder();

        /// <summary>
        /// Добавляет сообщение об ошибке в случае если проверка не пройдена.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="message"></param>
        public void AssertError(bool condition, string message)
        {
            if (condition)
            {
                errors.AppendLine(message);
            }
        }

        public bool IsAnyError()
        {
            return errors.Length > 0;
        }

        /// <summary>
        /// Возращает итоговое сообщение
        /// </summary>
        /// <returns></returns>
        public string GetMessage()
        {
            return errors.ToString();
        }

        public override string ToString()
        {
            return GetMessage();
        }

        public void Clear()
        {
            errors.Clear();
        }
    }
}

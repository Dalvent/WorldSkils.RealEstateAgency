using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency
{ 
    /// <summary>
    /// Хранит сообщение ошибки и функциию для проверки возникла ли ошибка.
    /// </summary>
    struct UserErrorCheack
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message">сообщение ошибки.</param>
        /// <param name="checkFunc">функция для проверки на наличие ошибки.</param>
        public UserErrorCheack(string message, Func<bool> checkFunc)
        {
            Message = message;
            СheckFunc = checkFunc;
        }

        public string Message { get; private set; }
        /// <summary>
        /// Если проверка не успеша, возращает false.
        /// </summary>
        public Func<bool> СheckFunc { get; private set; }
    }
}

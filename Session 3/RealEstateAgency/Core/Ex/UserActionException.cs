using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RealEstateAgency
{
    /// <summary>
    /// Ошибка пользоватя.
    /// </summary>
    [Serializable]
    public class UserActionException : System.Exception
    {
        public UserActionException() { }
        public UserActionException(string message) : base(message) { }
        public UserActionException(string message, System.Exception inner) : base(message, inner) { }
        protected UserActionException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
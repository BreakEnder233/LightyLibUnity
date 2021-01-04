using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightyLibUnity.Exceptions
{
    class SingletonAlreadyExistsException : Exception
    {
        private SingletonAlreadyExistsException(string message, Exception innerException = null) : base(message, innerException)
        {

        }
        public static SingletonAlreadyExistsException CreateException(Type type, Exception innerException = null)
        {
            var message = $"Singleton of type {type.FullName} already exists.";
            return new SingletonAlreadyExistsException(message, innerException);
        }
    }
}

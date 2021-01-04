using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightyLibUnity.Exceptions
{
    class SingletonNotExistsException : Exception
    {
        private SingletonNotExistsException(string message, Exception innerException = null) : base(message, innerException)
        {

        }
        public static SingletonNotExistsException CreateException(Type type, Exception innerException = null)
        {
            var message = $"Singleton of type {type.FullName} not exists.";
            return new SingletonNotExistsException(message, innerException);
        }
    }
}

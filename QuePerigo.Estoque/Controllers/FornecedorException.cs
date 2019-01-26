using System;
using System.Runtime.Serialization;

namespace QuePerigo.Estoque.Controllers
{
    [Serializable]
    public class FornecedorException : Exception
    {
        public FornecedorException()
        {
        }

        public FornecedorException(string message) : base(message)
        {
        }

        public FornecedorException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FornecedorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
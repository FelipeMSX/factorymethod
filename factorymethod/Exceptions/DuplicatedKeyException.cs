using System.Runtime.Serialization;

namespace OmegaCore.Exceptions
{
    public class DuplicatedKeyException : Exception, ISerializable
    {
        public new const string Message = "A key is already registred with this type!";

        public DuplicatedKeyException() : base(Message){}

        public DuplicatedKeyException(string message) : base(message ?? Message){}

        public DuplicatedKeyException(string message, Exception innerException) : base(message ?? Message, innerException){}
    }
}
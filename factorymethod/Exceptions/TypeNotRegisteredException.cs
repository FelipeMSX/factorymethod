using System.Runtime.Serialization;

namespace OmegaCore.Exceptions
{
    public class TypeNotRegisteredException : Exception, ISerializable
    {
        public new const string Message = "Attribute was not found to the respective type!";

        public TypeNotRegisteredException() : base(Message){}

        public TypeNotRegisteredException(string message) : base(message ?? Message){}

        public TypeNotRegisteredException(string message, Exception innerException) : base(message ?? Message, innerException){}
    }
}
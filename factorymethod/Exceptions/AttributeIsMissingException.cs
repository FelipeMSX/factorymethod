using System.Runtime.Serialization;

namespace OmegaCore.Exceptions
{
    public class AttributeIsMissingException : Exception, ISerializable
    {
        public new const string Message = "The attribute was not found to the respective type!";

        public AttributeIsMissingException() : base(Message){}

        public AttributeIsMissingException(string message) : base(message ?? Message){}

        public AttributeIsMissingException(string message, Exception innerException) : base(message ?? Message, innerException){}
    }
}
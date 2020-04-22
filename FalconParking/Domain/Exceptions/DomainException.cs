using System;

namespace FalconParking.Domain.Exceptions
{
    [Serializable]
    public class DomainException : Exception
    {
        public string UserMessage { get; } = "Ha ocurrido un error. Por favor contacte a un administrador";

        public DomainException(
            string messsage
            ,string userMessage = null) : base(messsage)
        {
            this.UserMessage = userMessage;
        }
    }
}

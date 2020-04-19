using System;

namespace Domain.Exceptions
{
    /// <summary>
    /// Base exception type for domain validation of user input
    /// </summary>
    public class DomainValidationException : Exception
    {
        public DomainValidationException(string message) : base(message)
        {
        }

        public DomainValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
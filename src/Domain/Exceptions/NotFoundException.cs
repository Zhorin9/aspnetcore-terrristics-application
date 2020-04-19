using System;

namespace Domain.Exceptions
{
    public sealed class NotFoundException : DomainValidationException
    {
        public NotFoundException(string propertyName, object id) : this(propertyName, id, null)
        {
        }

        private NotFoundException(string propertyName, object id, Exception innerException) : base(CreateMessage(propertyName, id), innerException)
        {
        }

        private static string CreateMessage(string propertyName, object value)
        {
            return $"Resource with property name{propertyName} has not been found for indentifier {value}.";
        }
    }
}
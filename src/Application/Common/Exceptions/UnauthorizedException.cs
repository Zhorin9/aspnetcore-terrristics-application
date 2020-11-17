using System;

namespace Application.Common.Exceptions
{
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException(string name, object key)
            : base($"Unauthorized: {name}")
        {
        }
    }
}
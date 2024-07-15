﻿namespace Core.Exceptions
{
    public class AppException : Exception
    {
        public AppException() { }

        public AppException(string message) : base(message) { }

        public AppException(string message, Exception ex) : base(message, ex) { }
    }
}

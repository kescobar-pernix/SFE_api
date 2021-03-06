﻿using System;
using System.Runtime.Serialization;

namespace sfe.bll.Exceptions
{
    [Serializable]
    internal class UpdateUserException : Exception
    {
        public UpdateUserException()
        {
        }

        public UpdateUserException(string message) : base(message)
        {
        }

        public UpdateUserException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UpdateUserException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

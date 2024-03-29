﻿using System.Collections;
using System.Runtime.Serialization;

namespace BookManagementSystem.Exceptions
{
    public class ItemAlreadyExistException : Exception
    {
        public ItemAlreadyExistException(string? message) : base(message)
        {
        }

        public override IDictionary Data => base.Data;

        public override string? HelpLink { get => base.HelpLink; set => base.HelpLink = value; }

        public override string Message => base.Message;

        public override string? Source { get => base.Source; set => base.Source = value; }

        public override string? StackTrace => base.StackTrace;

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override Exception GetBaseException()
        {
            return base.GetBaseException();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}

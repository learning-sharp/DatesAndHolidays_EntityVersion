using System;
using System.Runtime.Serialization;


namespace DatesAndHolidays_EntityVersion.Exceptions
{
    public class DateOutOfRangeException : ApplicationException
    {
        public DateOutOfRangeException() { }

        public DateOutOfRangeException(string message) : base(message) { }

        public DateOutOfRangeException(string message, Exception inner) : base(message, inner) { }

        protected DateOutOfRangeException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}

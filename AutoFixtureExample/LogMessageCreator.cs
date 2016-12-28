using System;

namespace AutoFixtureExample
{
    public static class LogMessageCreator
    {
        public static LogMessage Create(string message, DateTime when)
        {
            return new LogMessage()
            {
                Year = when.Year,
                Message = message
            };
        }
    }
}
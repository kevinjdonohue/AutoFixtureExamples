using System;
using System.Collections.Generic;

namespace AutoFixtureExample
{
    public class DebugMessageBuffer
    {
        public List<string> Messages { get; set; }

        public DebugMessageBuffer()
        {
            Messages = new List<string>();
        }

        public void WriteMessages()
        {
            foreach (string message in Messages)
            {
                Console.WriteLine(message);
            }
        }
    }
}
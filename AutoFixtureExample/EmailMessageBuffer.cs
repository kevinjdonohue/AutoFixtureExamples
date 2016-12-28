using System;
using System.Collections.Generic;

namespace AutoFixtureExample
{
    public class EmailMessageBuffer
    {
        public List<EmailMessage> Emails { get; set; }

        public EmailMessageBuffer()
        {
            Emails = new List<EmailMessage>();
        }

        public void SendAll()
        {
            foreach (EmailMessage email in Emails)
            {
                Console.WriteLine(email);
            }
        }

        public void Add(EmailMessage email)
        {
            Emails.Add(email);
        }
    }
}
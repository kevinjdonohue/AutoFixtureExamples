using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoFixtureExample
{
    public class EmailMessageBuffer
    {
        private readonly IEmailGateway _emailGateway;
        private List<EmailMessage> _emails;

        public List<EmailMessage> Emails
        {
            get { return _emails; }
            set { _emails = value; }
        }

        public int UnsentMessagesCount => _emails.Count;

        public IEmailGateway EmailGateway => _emailGateway;

        public EmailMessageBuffer(IEmailGateway emailGateway)
        {
            _emailGateway = emailGateway;
            _emails = new List<EmailMessage>();
        }

        public void Add(EmailMessage email)
        {
            _emails.Add(email);
        }

        public void SendAll()
        {
            List<EmailMessage> allEmails = _emails.ToList();

            SendEmails(allEmails);
        }

        public void SendLimited(int maximumMessagesToSend)
        {
            List<EmailMessage> limitedBatchOfEmails = _emails.Take(maximumMessagesToSend).ToList();

            SendEmails(limitedBatchOfEmails);
        }

        private void SendEmails(List<EmailMessage> emailMessages)
        {
            foreach (EmailMessage email in emailMessages)
            {
                SendEmail(email);
            }
        }

        private void SendEmail(EmailMessage email)
        {
            Console.WriteLine($"Sending email to {email.ToAddress}");
            _emailGateway.Send(email);
            _emails.Remove(email);
        }

        public string SendOne(EmailMessage emailMessage)
        {
            SendEmail(emailMessage);

            return "The call was successful.";
        }
    }
}
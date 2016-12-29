namespace AutoFixtureExample
{
    public class EmailMessage
    {
        public string ToAddress { get; set; }
        public string MessageBody { get; set; }
        public string Subject { get; set; }
        public bool IsImportant { get; set; }

        public EmailMessage(string toAddress, string messageBody, bool isImportant, string subject)
        {
            ToAddress = toAddress;
            MessageBody = messageBody;
            IsImportant = isImportant;
            Subject = subject;
        }
    }
}
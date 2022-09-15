namespace SupportBank
{
    class Transaction
    {
        public DateTime TimeStamp {get;}
        public string Sender {get;}

        public string Recipient {get;}

        public decimal Amount { get; }

        public string Description {get;}

        public Transaction(DateTime timeStamp, string sender, string recipient, string description, decimal amount){
            this.TimeStamp = timeStamp;
            this.Sender = sender;
            this.Recipient = recipient;
            this.Description = description;
            this.Amount = amount;
            
        }
    }
}
namespace SupportBank
{
    class Transaction
    {
        public DateTime TimeStamp {get;}
        public Account Sender {get;}

        public Account Recipient {get;}

        public decimal Amount { get; }

        public string Description {get;}

        public Transaction(DateTime timeStamp, Account sender, Account recipient, string description, decimal amount){
            this.TimeStamp = timeStamp;
            this.Sender = sender;
            this.Recipient = recipient;
            this.Description = description;
            this.Amount = amount;
            
        }
    }
}
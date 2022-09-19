namespace SupportBank
{
    class Account
    {
        public string accountHolderName { get; set;}
        public decimal amount { get; set;}

        public List<Transaction> transactions {get; set;}

        public Account(string accountHolderName, decimal amount)
        {
            this.accountHolderName = accountHolderName;
            this.amount = amount;
            this.transactions = new List<Transaction>();
        }

        public void subtract(decimal n)
        {
            amount -= n;
        }

        public void add(decimal n)
        {
            amount += n;
        }

        public void addTransaction(Transaction transaction)
        {
            transactions.Add(transaction);
        }

    }
}
namespace SupportBank
{
    class Account
    {
        public string accountHolderName { get; set;}
        public decimal balance { get; set;}

        public List<Transaction> transactions {get; set;}

        public Account(string accountHolderName, decimal balance)
        {
            this.accountHolderName = accountHolderName;
            this.balance = balance;
            this.transactions = new List<Transaction>();
        }

        public void UpdateBalance(decimal n)
        {
            balance -= n;
        }

        public void addTransaction(Transaction transaction)
        {
            transactions.Add(transaction);
        }

        public void PrintTransactions()
        {
            foreach (Transaction transaction in transactions){
            Console.WriteLine($"-----");
            Console.WriteLine($"Date : {transaction.TimeStamp}");
            Console.WriteLine($"Amount: {transaction.Amount}");
            Console.WriteLine($"To: {transaction.Recipient.accountHolderName}");
            Console.WriteLine($"Description: {transaction.Description}");
            }
        }

    }
}
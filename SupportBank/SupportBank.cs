using SupportBank.Parsers;
namespace SupportBank
{
    class SupportBankClass
    {

        public List<Transaction> transactionList { get; set; }
        public List<Account> accountList {get; set;}
        
        public SupportBankClass()
        {
        this.accountList = AccountParser.runAccountParser().Item1;
        this.transactionList = AccountParser.runAccountParser().Item2;
        }

        public List<Transaction> transactionListGetter()
        {
            return this.transactionList;
        }

        public List<Account> accountListGetter()
        {
            return this.accountList;
        }

        public void Clearinghouse(List<Transaction> transactionList)
        {
            foreach(Transaction transaction in transactionList)
            {
                accountList.Where(account => account.accountHolderName == transaction.Sender.accountHolderName).FirstOrDefault().subtract(transaction.Amount);
                accountList.Where(account => account.accountHolderName == transaction.Recipient.accountHolderName).FirstOrDefault().add(transaction.Amount);
            }
        }

        public void ListBalance(List<Account> accountList)
        {         
        Console.WriteLine("How much is owed by each member of the supportbank");   
        foreach(Account account in accountList)
            {
                Console.WriteLine(account.accountHolderName);
                Console.WriteLine(account.amount);
            }
        }

        public void AddTransactions()
        {
            foreach(Transaction transaction in transactionList)
            {
                accountList.Where(account => account.accountHolderName ==  transaction.Sender.accountHolderName).FirstOrDefault().addTransaction(transaction);
            }
        }

        public void ListTransactionsForAccount(Account account1)
        {
            Account relevantAccount = accountList.First(account => account == account1);
            Console.WriteLine($"Transactions completed by {relevantAccount.accountHolderName}");
            foreach (Transaction transaction in relevantAccount.transactions)
            {
                Console.WriteLine("-----");
                Console.WriteLine($"Date : {transaction.TimeStamp}");
                Console.WriteLine($"Amount: {transaction.Amount}");
                Console.WriteLine($"To: {transaction.Recipient.accountHolderName}");
                Console.WriteLine($"Description: {transaction.Description}");
            }
        }


    }
}
using SupportBank.Parsers;
namespace SupportBank
{
    class SupportBankClass
    {

        public List<Transaction> transactionList { get; set; }
        public List<Account> accountList {get; set;}
        
        public SupportBankClass()
        {
        this.transactionList =  TransactionParser.runTransactionParser(); 
        this.accountList = AccountParser.runAccountParser(this.transactionList);
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
                accountList.Where(account => account.accountHolderName == transaction.Sender).First().subtract(transaction.Amount);
                accountList.Where(account => account.accountHolderName == transaction.Recipient).First().add(transaction.Amount);
            }
        }

        public void ListAll(List<Account> accountList)
        {            
        foreach(Account account in accountList)
            {
                Console.WriteLine(account.accountHolderName);
                Console.WriteLine(account.amount);
            }
        }


    }
}
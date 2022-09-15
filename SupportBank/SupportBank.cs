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
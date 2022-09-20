using SupportBank.Parsers;
using NLog;
using NLog.Config;
using NLog.Targets;
namespace SupportBank
{
    class SupportBankClass
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
        public List<Transaction> TransactionList { get; set; }
        public List<Account> AccountList {get; set;}

        public SupportBankClass()
        {
            TransactionList = new List<Transaction>();
            AccountList = new List<Account>() ;
        }
        
        public void AddDataToBank(string source)
        {
            AccountList = AccountParser.runAccountParser(source, AccountList).Item1;
            TransactionList.AddRange(AccountParser.runAccountParser(source, AccountList).Item2);
        }

        public void ExecuteTransactionsAndAddToAccount()
        {
            foreach(Transaction transaction in TransactionList)
            {
                AccountList.First(account => account.accountHolderName == transaction.Sender.accountHolderName).UpdateBalance(transaction.Amount);

                AccountList.First(account => account.accountHolderName == transaction.Recipient.accountHolderName).UpdateBalance(-transaction.Amount);

                AccountList.Where(account => account.accountHolderName ==  transaction.Sender.accountHolderName).FirstOrDefault().addTransaction(transaction);
            }
        }

        public void Overview()
        {         
        Console.WriteLine("How much is owed by each member of the supportbank");   
        foreach(Account account in AccountList)
            {
                Console.WriteLine(account.accountHolderName);
                Console.WriteLine(account.balance);
            }
        }

    }
}
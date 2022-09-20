namespace SupportBank.Parsers
{
    class AccountParser
    {
        public static List<Account> LocalAccountList;

        public static Account assignAccount(string accountHolderName)
        {
            Account account;

            var Accountexists = LocalAccountList.Where(p => p.accountHolderName == accountHolderName);
            if (!Accountexists.Any())
                        { 
                            account = new Account(accountHolderName, 0);
                            LocalAccountList.Add(account);
                        }
                        else
                        { 
                            account = LocalAccountList.Where(instance => instance.accountHolderName == accountHolderName).FirstOrDefault();
                        }
            return account;
        }
         public static (List<Account>, List<Transaction>) runAccountParser(string source, List<Account> AccountList)
         {
            List<Transaction> TransactionList = new List<Transaction>();
            LocalAccountList = AccountList;

            using(var reader = new StreamReader(@"C:\Users\rvano\OneDrive\Desktop\SB\SupportBank\SupportBank\" + source + ".csv"))
            {
                var headerLine = reader.ReadLine();
                bool isFirst = true;
                while (reader.Peek() != -1)
                {
                    if(isFirst)
                        {
                            isFirst=false;
                            continue;
                        }
                    
                    var line = reader.ReadLine();
                    if (line is not null)
                    {
                        var values = line.Split(',');

                        // add unique accounts
                        
                        string accountHolderNameSender = values[1];
                        Account accountSender = assignAccount(accountHolderNameSender);

                        string accountHolderNameRecipient = values[2];
                        Account accountRecipient = assignAccount(accountHolderNameRecipient);

                        Transaction transaction = new Transaction(
                            DateTime.Parse(values[0]), 
                            accountSender,
                            accountRecipient,
                            values[3], 
                            Decimal.Parse(values[4])
                        );
                        TransactionList.Add(transaction);
                        
                        AccountList = LocalAccountList;
                    }
                }        
            }
         
            return (AccountList, TransactionList);

         }
    }
}
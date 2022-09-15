namespace SupportBank.Parsers
{
    class AccountParser
    {
         public static (List<Account>, List<Transaction>) runAccountParser()
         {
            List<Transaction> transactionList = new List<Transaction>();
            List<Account> accounts = new List<Account>();

            using(var reader = new StreamReader(@"C:\Users\rvano\OneDrive\Desktop\SB\SupportBank\SupportBank\Transactions.csv"))
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

                        var matches1 = accounts.Where(p => p.accountHolderName == values[1]);

                        Account account1;

                        if (matches1 is not null)
                        { 
                            account1 = new Account(values[1], 0);
                            accounts.Add(account1);
                        }
                        else
                        { 
                            account1 = accounts.Where(instance => instance.accountHolderName == values[1]).FirstOrDefault();
                        }

                        Account account2;
                        var matches2 = accounts.Where(p => p.accountHolderName == values[2]);

                        if (matches2 is not null)
                        { 
                            account2 = new Account(values[2], 0);
                            accounts.Add(account2);
                        }
                        else
                        { 
                            account2 = accounts.Where(instance => instance.accountHolderName == values[2]).FirstOrDefault();
                        }
                        

                        Transaction transaction = new Transaction(
                            DateTime.Parse(values[0]), 
                            account1,
                            account2,
                            values[3], 
                            Decimal.Parse(values[4])
                        );

                        transactionList.Add(transaction);

                    }
                }
               
            }

            // List<String> senders = transactionList.Select(x => x.Sender).Distinct().ToList();
            // List<String> recipients = transactionList.Select(x => x.Recipient).Distinct().ToList();
            // List<String> accountholders = senders.Union(recipients).ToList();
           
            return (accounts, transactionList);

         }
    }
}
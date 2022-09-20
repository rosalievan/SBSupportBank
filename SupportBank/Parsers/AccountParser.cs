using Newtonsoft.Json;
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

            if( source.Split('.')[1] == "csv")
            {
                using(var reader = new StreamReader(@"C:\Users\rvano\OneDrive\Desktop\SB\SupportBank\SupportBank\" + source))
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

                            try{
                            Transaction transaction = new Transaction(
                                DateTime.Parse(values[0]), 
                                accountSender,
                                accountRecipient,
                                values[3], 
                                Decimal.Parse(values[4])
                            );
                            TransactionList.Add(transaction);
                            }
                            catch(System.FormatException)
                            {
                                Console.WriteLine("You have entered data in the wrong format, the following transaction will not be added to the database");
                                Console.WriteLine("--------");
                                Console.WriteLine("date: " + values[0]);
                                Console.WriteLine("from: " + values[1]);
                                Console.WriteLine("to: " + values[2]);
                                Console.WriteLine("description: " + values[3]);
                                Console.WriteLine("amount: "+ values[4]);
                                Console.WriteLine("");
                            }

                            AccountList = LocalAccountList;
                        }
                    }        
                }
            }

    //         else if( source.Split('.')[1] == "json")

    //         {
    //             using (StreamReader file = File.OpenText(@$"C:\Users\rvano\OneDrive\Desktop\SB\SupportBank\SupportBank\{source}"))
    //    {         List<Transaction> transactions = JsonConvert.DeserializeObject<List<Transaction>>(file);

    //             foreach (Transaction transaction in transactions)
    //             {
    //                 Console.WriteLine(transaction.TimeStamp);
    //             }}
    //         }
         
            return (AccountList, TransactionList);

         }
    }
}
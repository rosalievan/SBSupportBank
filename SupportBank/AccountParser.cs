namespace SupportBank
{
    class AccountParser
    {
         public static List<Account> runAccountParser(List<Transaction> transactionList)
         {
            List<String> senders = transactionList.Select(x => x.Sender).Distinct().ToList();
            List<String> recipients = transactionList.Select(x => x.Recipient).Distinct().ToList();
            List<String> accountholders = senders.Union(recipients).ToList();

            List<Account> accounts = new List<Account>();

            foreach (String accountholder in accountholders)
            {
                Account account = new Account(
                    accountholder, 
                    0
                    );
                accounts.Add(account);
            }
            ;

            return accounts;

         }
    }
}
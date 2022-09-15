// See https://aka.ms/new-console-template for more information
using System.IO;
namespace SupportBank
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Transaction> transactionList = Parser.runParser();

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

            foreach(Account account in accounts)
            {
                Console.WriteLine(account.accountHolderName);
                Console.WriteLine(account.amount);
            }

            // foreach (Transaction transaction1 in transactionList){
            //     this.Items.Where(item => item.item.ItemName == itemToRemove.ItemName).First().RemoveItemFromStock(n);
            // }

        }
    }
}

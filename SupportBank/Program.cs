// See https://aka.ms/new-console-template for more information
using System.IO;
namespace SupportBank
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Transaction> transactionList = TransactionParser.runTransactionParser();

            List<Account> accountList = AccountParser.runAccountParser(transactionList);

            foreach(Account account in accountList)
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

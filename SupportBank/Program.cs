// See https://aka.ms/new-console-template for more information
using System.IO;
namespace SupportBank
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Transaction> listA = Parser.runParser();

            foreach (Transaction transaction1 in listA){
                Console.WriteLine(transaction1.Amount);
            }

        }
    }
}

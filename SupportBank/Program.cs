﻿// See https://aka.ms/new-console-template for more information
using System.IO;
using SupportBank.Parsers;
namespace SupportBank
{
    class Program
    {
        static void Main(string[] args)
        {
            SupportBankClass supportBank1 = new SupportBankClass();
            Console.WriteLine(supportBank1.accountList);

            supportBank1.Clearinghouse(supportBank1.transactionListGetter());
            supportBank1.ListAll(supportBank1.accountListGetter());

            Console.WriteLine("Hallo Eline!");

        }
    }
}

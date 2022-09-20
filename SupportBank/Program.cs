// See https://aka.ms/new-console-template for more information
using System.IO;
using SupportBank.Parsers;
using NLog;
using NLog.Config;
using NLog.Targets;
namespace SupportBank
{
    class Program
    {
        
        static void Main(string[] args)
        {
            // var config = new LoggingConfiguration();
            // var target = new FileTarget { FileName = @"C:\Work\Logs\SupportBank.log", Layout = @"${longdate} ${level} - ${logger}: ${message}" };
            // config.AddTarget("File Logger", target);
            // config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, target));
            // LogManager.Configuration = config;

            SupportBankClass supportBank1 = new SupportBankClass();

            supportBank1.AddDataToBank("Transactions");
            // supportBank1.AddDataToBank("Transactions2015");

            supportBank1.ExecuteTransactionsAndAddToAccount();

            supportBank1.Overview();

            supportBank1.AccountList.First(account => account.accountHolderName == "Dan W").PrintTransactions();
        }
    }
}

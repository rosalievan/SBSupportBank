namespace SupportBank.Parsers
{
    class TransactionParser
    {
        // public static List<Transaction> runTransactionParser()
        // {
        //     bool isFirst=true;
        //     List<Transaction> transactionList = new List<Transaction>();
        //     using(var reader = new StreamReader(@"C:\Users\rvano\OneDrive\Desktop\SB\SupportBank\SupportBank\Transactions.csv"))
        //     {
        //         var headerLine = reader.ReadLine();
                
        //         while (reader.Peek() != -1)
        //         {
        //             if(isFirst)
        //                 {
        //                     isFirst=false;
        //                     continue;
        //                 }
                    
        //             var line = reader.ReadLine();
        //             if (line is not null)
        //             {
        //                 var values = line.Split(',');

        //                 Transaction transaction = new Transaction(
                        
        //                 DateTime.Parse(values[0]), 
        //                 Account(values[1]),
        //                 Account(values[2]), 
        //                 values[3], 
        //                 Decimal.Parse(values[4])
        //             );
        //             transactionList.Add(transaction);

        //             }
        //         }
               
        //     }

        // return transactionList;
        // }
    }
}
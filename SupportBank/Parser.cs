namespace SupportBank
{
    class Parser
    {
        public static List<Transaction> runParser()
        {
            bool isFirst=true;
            List<Transaction> listA = new List<Transaction>();
            using(var reader = new StreamReader(@"C:\Users\rvano\OneDrive\Desktop\SB\SupportBank\SupportBank\Transactions.csv"))
            {
                var headerLine = reader.ReadLine();
                
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

                        Transaction transaction = new Transaction(
                        
                        DateTime.Parse(values[0]), 
                        values[1],
                        values[2], 
                        values[3], 
                        Decimal.Parse(values[4])
                    );
                    listA.Add(transaction);

                    }
                }
               
            }

        return listA;
        }
    }
}
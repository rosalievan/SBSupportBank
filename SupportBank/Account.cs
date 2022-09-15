namespace SupportBank
{
    class Account
    {
        public string accountHolderName { get; set;}
        public decimal amount { get; set;}

        public Account(string accountHolderName, decimal amount)
        {
            this.accountHolderName = accountHolderName;
            this.amount = amount;
        }

        public void subtract(decimal n)
        {
            amount -= n;
        }

        public void add(decimal n)
        {
            amount += n;
        }

    }
}
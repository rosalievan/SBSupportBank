namespace SupportBank
{
    class Account
    {
        // public string accountHolderName { get; set;}
        public decimal amount { get; set;}

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
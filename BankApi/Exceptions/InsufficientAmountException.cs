namespace BankApi.Exceptions
{
    public class InsufficientAmountException : Exception
    {
        public InsufficientAmountException(string message) : base(message)
        {

        }
    }
}

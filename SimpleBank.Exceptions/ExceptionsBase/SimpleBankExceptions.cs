namespace SimpleBank.Exceptions.ExceptionsBase
{
    public class SimpleBankExceptions : Exception
    {
        public SimpleBankExceptions(string message) : base(message)
        {
        }
        public SimpleBankExceptions(string message, Exception innerException) : base(message, innerException)
        {
        }

    }
}

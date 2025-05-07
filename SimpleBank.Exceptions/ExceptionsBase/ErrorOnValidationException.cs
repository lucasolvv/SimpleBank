namespace SimpleBank.Exceptions.ExceptionsBase
{
    public class ErrorOnValidationException : SimpleBankExceptions
    {
        public List<Exception> error { get; set; } = new List<Exception>();

        public ErrorOnValidationException(string message) : base(message)
        {
            error.Add(new Exception(message));
        }
    }
}

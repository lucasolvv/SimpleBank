namespace SimpleBank.Exceptions.ExceptionsBase
{
    public class ErrorOnValidationException : SimpleBankExceptions
    {
        public List<string> ErrorMessages;

        public ErrorOnValidationException(List<string> errors)
        {
            ErrorMessages = errors;
        }
    }
}

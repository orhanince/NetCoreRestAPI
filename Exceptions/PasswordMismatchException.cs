namespace NetCoreRestAPI.Exceptions
{
    public class PasswordMismatchException : Exception
    {
        public PasswordMismatchException() : base("The passwords do not match.")
        {
        }
    }
}
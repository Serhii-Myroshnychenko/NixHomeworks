namespace Module4Homework1.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(string message)
        : base(message)
        {
        }

        public BusinessException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
        public BusinessException(string message, string errorCode)
            : base(message)
        {
            ErrorCode = errorCode;
        }

        public string? ErrorCode { get; }
    }
}

namespace SocialNetwork.BusinessLogic.DTOs.Results
{
    public class OperationResult
    {
        public bool Successfully { get; protected set; }
        public ErrorInfo? ErrorInfo { get; protected set; }

        public static OperationResult Success()
        {
            return new OperationResult
            {
                Successfully = true
            };
        }

        public static OperationResult Error(ErrorInfo errorInfo)
        {
            return new OperationResult
            {
                Successfully = false,
                ErrorInfo = errorInfo
            };
        }

        public bool IsException()
        {
            return Error != null;
        }
    }

    public class OperationResult<TResult> : OperationResult
    {
        public TResult? Result { get; set; }

        public static OperationResult<TResult> Success(TResult result)
        {
            return new OperationResult<TResult>
            {
                Successfully = true,
                Result = result
            };
        }

        public static new OperationResult<TResult> Error(ErrorInfo errorInfo)
        {
            return new OperationResult<TResult>
            {
                Successfully = false,
                ErrorInfo = errorInfo
            };
        }
    }
}

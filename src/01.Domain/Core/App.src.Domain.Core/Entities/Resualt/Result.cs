namespace App.src.Domain.Core.Entities.Resualt
{
    public class Result
    {
        public bool IsSuccess { get; }
        public string? ErrorMessage { get; }
        public Exception? Exception { get; }

        protected Result(bool isSuccess, string? errorMessage = null, Exception? exception = null)
        {
            IsSuccess = isSuccess;
            ErrorMessage = errorMessage;
            Exception = exception;
        }

        public static Result Success() => new Result(true);
        public static Result Failure(string errorMessage, Exception? exception = null) => new Result(false, errorMessage, exception);
    }

}


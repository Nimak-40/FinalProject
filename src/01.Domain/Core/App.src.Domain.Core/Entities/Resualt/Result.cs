namespace App.src.Domain.Core.Entities.Resualt
{
    public class Result
    {
        public bool IsSuccess { get; }
        public string? ErrorMessage { get; }
        public Exception? Exception { get; }

        protected Result(bool isSuccess, string? errorMessage = null)
        {
            IsSuccess = isSuccess;
            ErrorMessage = errorMessage;
           
        }

        public static Result Success(string? message = null) => new(true, message);
        public static Result Failure(string message) => new(false, message);
    }
    public class Result<T>
    {
        public bool IsSuccess { get; }
        public string? ErrorMessage { get; }
        public Exception? Exception { get; }
        public T? Value { get; }

        protected Result(bool isSuccess, T? value = default, string? errorMessage = null, Exception? exception = null)
        {
            IsSuccess = isSuccess;
            Value = value;
            ErrorMessage = errorMessage;
            Exception = exception;
        }

        public static Result<T> Success(T value) => new Result<T>(true, value);
        public static Result<T> Failure(string errorMessage, Exception? exception = null) => new Result<T>(false, default, errorMessage, exception);
    }

}


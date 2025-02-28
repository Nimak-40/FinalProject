namespace App.src.Domain.Core.Entities.Resualt
{
    public class Result<T> : Result
    {
        public T? Data { get; }

        private Result(T data, bool isSuccess, string? errorMessage = null, Exception? exception = null)
            : base(isSuccess, errorMessage, exception)
        {
            Data = data;
        }

        public static Result<T> Success(T data) => new Result<T>(data, true);
        public static Result<T> Failure(string errorMessage, Exception? exception = null) => new Result<T>(default, false, errorMessage, exception);
    }

}


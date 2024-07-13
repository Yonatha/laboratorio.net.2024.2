namespace LaboratorioDev.Shared
{
    public class Result<T>
    {
        public bool IsSuccess { get; }
        public T Content { get; }
        public string Error { get; }

        private Result(bool isSuccess, T content, string error)
        {
            IsSuccess = isSuccess;
            Content = content;
            Error = error;
        }

        public static Result<T> Success(T value) => new Result<T>(true, value, null);
        public static Result<T> Failure(string error) => new Result<T>(false, default, error);
    }
}

namespace API.Utilities
{
    public class OperationResult<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string ErrorMessage { get; set; }
        public int statusCode { get; set; }

        public static OperationResult<T> SuccessResult(T data,int statusCode)
        {
            return new OperationResult<T> { Success = true, statusCode = statusCode };
        }
        public static OperationResult<T> ErrorResult(string errorMessage, int statusCode)
        {
            return new OperationResult<T> { Success = false, ErrorMessage = errorMessage, statusCode = statusCode };
        }
    }
}

namespace BackendExam.Application.Shared
{
    public class Response<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string ErrorMessage { get; set; }

        public Response(bool success, T data, string errorMessage = null)
        {
            Success = success;
            Data = data;
            ErrorMessage = errorMessage;
        }

        public Response(T data, string errorMessage = null)
        {
            Data = data;
            ErrorMessage = errorMessage;
        }

        public Response(bool success, string errorMessage = null)
        {
            Success = success;
            ErrorMessage = errorMessage;
        }
    }
}

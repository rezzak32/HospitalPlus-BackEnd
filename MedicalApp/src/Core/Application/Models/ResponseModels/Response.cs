

namespace Application.Models.ResponseModels
{
    public class Response
    {
        public bool Success { get; set; } = false;
        public string? Message { get; set; }
    }

    public class GetManyResponse<T> : Response where T : class
    {
        public IEnumerable<T>? Result { get; set; }

        public GetManyResponse(IEnumerable<T>? result)
        {
            Result = result;
        }

        public GetManyResponse()
        {

        }
    }
    public class GetOneResponse<T> : Response where T : class
    {
        public T? Result { get; set; }

        public GetOneResponse(T? result)
        {
            Result = result;
        }

        public GetOneResponse()
        {

        }
    }
}

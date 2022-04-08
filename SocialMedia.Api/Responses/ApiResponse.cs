using SocialMedia.Core.CustomEntitis;

namespace SocialMedia.Api.Responses
{
    public class ApiResponse<T>
    {
        public ApiResponse(T data)
        {
            Data = data;
        }
        public T Data { get; set; }

        public metadata meta { get; set; }
    }
}

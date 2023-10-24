using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Responses
{
    public class Response
    {
        public readonly int StatusCode;
        public readonly string Message;

        public Response(int statusCode,string message)
        {
            StatusCode = statusCode;
            Message = message;
        }

    }
}

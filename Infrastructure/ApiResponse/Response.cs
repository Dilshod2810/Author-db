﻿using System.Net;

namespace Infrastructure.ApiResponse;

public class Response<T>
{
    public int StatusCode { get; set; }
    public T? Data { get; set; }
    public string Message { get; set; }

    public Response(HttpStatusCode statusCode, string message)
    {
        StatusCode = (int)statusCode;
        Message = message;
        Data=default;
    }

    public Response(T data)
    {
        StatusCode = 200;
        Message = "Success";
        Data = data;
    }
}
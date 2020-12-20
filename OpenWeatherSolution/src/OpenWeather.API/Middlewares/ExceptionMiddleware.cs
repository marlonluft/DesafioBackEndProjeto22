using Microsoft.AspNetCore.Http;
using OpenWeather.Library.Exceptions;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace OpenWeather.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            string erro = null;

            if (exception is OpenWeatherException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                erro = exception.Message;
            }
            else if (exception is Exception)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                erro = "Ocorreu uma falha interna, favor tentar novamente mais tarde";
            }

            var result = JsonSerializer.Serialize(erro);
            context.Response.ContentType = "application/json";

            return context.Response.WriteAsync(result);
        }
    }
}

using System.Net;
using System.Text.Json;
using Tickets_API.Application.Exceptions;

namespace Tickets_API.Middleware
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
                await _next(context); // continua o pipeline
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode status;
            string message;

            switch (exception)
            {
                case NotFoundException notFoundEx:
                    status = HttpStatusCode.NotFound;
                    message = notFoundEx.Message;
                    break;

                // Pode adicionar mais cases para tratar outras exceções customizadas, ex:
                // case ValidationException validationEx:
                //     status = HttpStatusCode.BadRequest;
                //     message = validationEx.Message;
                //     break;

                default:
                    status = HttpStatusCode.InternalServerError;
                    message = "Ocorreu um erro inesperado.";
                    break;
            }

            var response = new { error = message };
            var payload = JsonSerializer.Serialize(response);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;

            // Aqui você pode adicionar logging do erro, ex:
            // _logger.LogError(exception, exception.Message);

            return context.Response.WriteAsync(payload);
        }
    }
}

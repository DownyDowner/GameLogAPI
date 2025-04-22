using GameLogAPI.src.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace GameLogAPI.Middlewares {
    public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken) {
            logger.LogError(exception, "Exception occurred: {Message}", exception.Message);

            ProblemDetails problemDetails;

            if (exception is ServiceException serviceException) {
                problemDetails = new ProblemDetails {
                    Status = serviceException.StatusCode,
                    Title = "Service Error",
                    Detail = serviceException.Message
                };
                httpContext.Response.StatusCode = serviceException.StatusCode;
            } else {
                problemDetails = new ProblemDetails {
                    Status = StatusCodes.Status500InternalServerError,
                    Title = "Internal Server Error",
                    Detail = "An unexpected error occurred."
                };
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            }

            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }
    }
}

using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RestEase;

namespace Account.Ledger.Api.Middlewares
{
    internal sealed class ApiExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is not ApiException apiException) return false;

            var problemDetails = new ProblemDetails()
            {
                Status = (int)apiException.StatusCode,
                Title = "some serious server problem on external side...",
                Detail = apiException.Message
            };

            httpContext.Response.StatusCode = StatusCodes.Status502BadGateway;

            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }
    }
}

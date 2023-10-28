using CleanArchitecture.API.Errors;
using CleanArchitecture.Application.Exceptions;
using Newtonsoft.Json;
using System.Text.Json;

namespace CleanArchitecture.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _environment;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment environment)
        {
            _next = next;
            _logger = logger;
            _environment = environment;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (NotFoundException ex)
            {
                await ManageException(context, ex, StatusCodes.Status404NotFound);
            }
            catch (ValidationException ex)
            {
                var validationJson = JsonConvert.SerializeObject(ex.Errors);

                await ManageException(context, ex, StatusCodes.Status400BadRequest, validationJson);
            }
            catch (BadRequestException ex)
            {
                await ManageException(context, ex, StatusCodes.Status400BadRequest);
            }
            catch (Exception ex)
            {
                if (_environment.IsDevelopment())
                {
                    await ManageException(context, ex, StatusCodes.Status500InternalServerError, ex.StackTrace);
                    return;
                }

                await ManageException(context, ex, StatusCodes.Status500InternalServerError);
            }
        }

        private async Task ManageException(HttpContext context, Exception ex, int statusCode, string? details = null)
        {
            _logger.LogError(ex, ex.Message);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            JsonSerializerOptions options = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

            var response = JsonConvert.SerializeObject(new CodeErrorException(statusCode, ex.Message, details));

            await context.Response.WriteAsync(response);
        }
    }
}

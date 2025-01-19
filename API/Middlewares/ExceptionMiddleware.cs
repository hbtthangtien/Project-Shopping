using Domain.DTOs.Response;
using Domain.Exceptions;

namespace API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync (HttpContext context)
        {
            try
            {
                await _next(context);
            }catch (IdentityException ex)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                List<string> errors = ex.Message.Split (';').ToList();
                await context.Response.WriteAsJsonAsync(new ApiResponeDTO
                {
                    Message = errors,
                    Status = StatusCodes.Status400BadRequest,
                });
            }
            catch (AuthenticationException ex)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsJsonAsync(new ApiResponeDTO
                {
                    Message = ex.Message,
                    Status = StatusCodes.Status401Unauthorized,
                });
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsJsonAsync(new ApiResponeDTO
                {
                    Message = ex.Message,
                    Status = StatusCodes.Status400BadRequest,
                });
            }
        }
    }
}

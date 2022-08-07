using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using QuarterApp.Service.CustomExpections;

namespace QuarterApp.Api.Extentions.ServiceExtentions
{
    public static class ExceptionHandlerExtention 
    {

        public static void AddExceptionService(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(error =>
            {
                error.Run(async (context) =>
                {
                    var contextFeatures = context.Features.Get<IExceptionHandlerFeature>();
                    var code = 500;
                    var message = "Internal Server Error. Please try again later";

                    if (contextFeatures != null)
                    {
                        message = contextFeatures.Error.Message;
                        if (contextFeatures.Error is AlreadyExistException)
                            code = 409;
                        else if (contextFeatures.Error is NotFoundException)
                            code = 404;
                        else if (contextFeatures.Error is FileFormatException)
                            code = 400;
                    }

                    context.Response.StatusCode = code;
                    await context.Response.WriteAsync(new
                    {
                        code = code,
                        message = message
                    }.ToString());

                });
            });
        }

    }
}

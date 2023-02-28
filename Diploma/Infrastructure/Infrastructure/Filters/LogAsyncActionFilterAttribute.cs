using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Filters;

public class LogAsyncActionFilterAttribute : ActionFilterAttribute, IAsyncActionFilter
{
    private readonly string _actionName;
    public LogAsyncActionFilterAttribute(
        string actionName)
    {
        _actionName = actionName;
    }

    public async override Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var loggerFactory = context.HttpContext.RequestServices.GetRequiredService<ILoggerFactory>();

        var loggerService = loggerFactory.CreateLogger(context.Controller.GetType());

        loggerService.LogInformation(
            $"{context.Controller.GetType()} : {_actionName} visited at {DateTime.Now} by User with Id = " +
            $"{context.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value}");
        await next();
    }
}

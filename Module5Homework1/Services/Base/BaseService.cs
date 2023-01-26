using Module5Homework1.Exceptions;
using Module5Homework1.Models;

namespace Module5Homework1.Services.Base
{
    public abstract class BaseService
    {
        protected async Task<TResult> ExecuteSafeAsync<TResult>(Func<Task<TResult>> action)
            where TResult : Validation, new()
        {
            try
            {
                return await action();
            }
            catch (BusinessException e)
            {
                return new TResult
                {
                    Error = e.Message,
                    ErrorCode = e.ErrorCode
                };
            }
        }
    }
}

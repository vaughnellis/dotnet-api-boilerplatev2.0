using DotnetApiBoilerplatev2._0.Models;

namespace DotnetApiBoilerplatev2._0.ExceptionHandlers
{
    public interface IExceptionHandler
    {
        void HandleException(Exception e, ILogger logger);
        Error GetError(Exception e);
    }
}

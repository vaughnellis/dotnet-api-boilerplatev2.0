using DotnetApiBoilerplatev2._0.ExceptionHandlers.CustomExceptions;
using DotnetApiBoilerplatev2._0.Models;
using System.Text;

namespace DotnetApiBoilerplatev2._0.ExceptionHandlers
{
    public class ExceptionHandler : IExceptionHandler
    {
        public Error GetError(Exception e)
        {
            BaseException be = wrapException(e);
            return new Error(be.ErrorCode, be.Message);
        }
        public void HandleException(Exception e, ILogger logger)
        {

            var baseException = wrapException(e);
            if (!string.IsNullOrEmpty(baseException.ErrorCode) && baseException.ErrorCode != "GENERAL")
            {
                logger?.LogError($"{baseException.ErrorCode}: {baseException.Message}");
            }
            else
            {
                logger?.LogError("{@Exception}", baseException);
            }
        }
        private BaseException wrapException(Exception e)
        {
            if (e is BaseException be)
            {
                return be;
            }
            if (e is AggregateException ae)
            {
                StringBuilder errorMessage = new StringBuilder();
                errorMessage.AppendLine(e.Message);
                foreach (Exception innerException in ae.Flatten().InnerExceptions)
                {

                    errorMessage.AppendLine(innerException.StackTrace);
                }

                return new BaseException(errorMessage.ToString(), e);
            }
            else
            {
                return new BaseException(e.Message, e);
            }
        }
    }
}

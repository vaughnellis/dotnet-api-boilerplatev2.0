using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text;

namespace DotnetApiBoilerplatev2._0.Common
{
    public static class Utility
    {
        public static string GetRequestModelErrors(this ModelStateDictionary modelState)
        {
            var errorStringBuilder = new StringBuilder();
            var errorList = modelState.Where(m => m.Value.Errors?.Any(e => !string.IsNullOrEmpty(e.ErrorMessage)) == true);

            if (!errorList.Any())
                return "Invalid Request.";

            foreach (var modelStateEntry in errorList)
            {
                foreach (var error in modelStateEntry.Value.Errors)
                {
                    errorStringBuilder.Append($"{modelStateEntry.Key} : {error.ErrorMessage} ");
                }
            }

            return errorStringBuilder.ToString().Trim();
        }
    }
}

using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace OneInc.Encoder.API.Helpers
{
    public static class ErrorHelper
    {
        public static string ErrorsToString(ModelStateDictionary modelStateDictionary)
        {
            return string.Join(string.Empty, modelStateDictionary.Values.SelectMany(x => x.Errors).Select(y => y.ErrorMessage).ToList());
        }
    }
}

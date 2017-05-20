using System.Web.Mvc;

namespace Achiever.Web.Helpers
{
    public static class Extensions
    {
        public static JsonResult LargeJsonResult(this Controller controller, object data, JsonRequestBehavior behavior)
        {
            return new JsonResult()
            {
                Data = data,
                JsonRequestBehavior = behavior,
                MaxJsonLength = int.MaxValue
            };
        }
    }
}
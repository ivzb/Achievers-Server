using System;
using System.Web.Mvc;
using System.Web.WebPages;

namespace Achiever.Web.Helpers
{
    public static class HtmlExtensions
    {
        public static HtmlHelper GetPageHelper(this System.Web.WebPages.Html.HtmlHelper html)
        {
            return ((System.Web.Mvc.WebViewPage)WebPageContext.Current.Page).Html;
        }
    }
}
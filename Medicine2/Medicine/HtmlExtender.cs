using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Medicine
{
   
        public static class HtmlExtender
        {
            public static IHtmlString DisplayImage(this HtmlHelper helper, string ImageUrl, int Size)
            {
                TagBuilder tb = new TagBuilder("img");
                tb.Attributes.Add("src", ImageUrl);
                tb.Attributes.Add("style", $"width:{Size}px");
                return new MvcHtmlString(tb.ToString());
            }
        }
   
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MoviesListApp.TagHelpers
{
    [HtmlTargetElement("last-action-message")]
    public class LastActionMessageTagHelper : TagHelper
    {
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewCtx { get; set; }

        /*      
        @if (TempData.Keys.Contains("LastActionMessage"))
        {
            <div class="alert alert-success alert-dismissible">
                <button class="close" data-dismiss="alert">&times;</button>
                @TempData["LastActionMessage"]
            </div>
        }
         */
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (ViewCtx.TempData.Keys.Contains("LastActionMessage"))
            {
                // first build a child button:
                var childBtn = new TagBuilder("button");
                childBtn.Attributes.Add("class", "close");
                childBtn.Attributes.Add("data-dismiss", "alert");
                childBtn.InnerHtml.AppendHtml("&times;");

                // create the div:
                output.TagName = "div";
                output.TagMode = TagMode.StartTagAndEndTag;
                output.Attributes.Add("class", "alert alert-success alert-dismissible");

                // append both the child btn and the the message content to this div:
                output.Content.AppendHtml(childBtn);
                output.Content.Append(ViewCtx.TempData["LastActionMessage"].ToString());
            }
            else
            {
                output.SuppressOutput();
            }
        }
    }
}

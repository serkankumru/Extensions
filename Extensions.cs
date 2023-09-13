using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using News.Models;

namespace News.Extensions
{
    public static class Extensions
    {
        public static string ControlledSub(this string value, int lenght, string deVal)
        {
            if (string.IsNullOrWhiteSpace(value))
                return deVal;
            string resuld = value;
            if (lenght <= value.Length)
            {
                resuld = resuld.Substring(0, lenght);
            }
            return resuld;
        }

        public static MvcHtmlString DropboxNewsStatus(this HtmlHelper htmlHelper, string name,bool select)
        {
            string s = "";

            List<SelectListItem> Status = new List<SelectListItem>();
            Status.Add(new SelectListItem() { Text = "Yayında", Value = "true" });
            Status.Add(new SelectListItem() { Text = "Yayında değil", Value = "false" });


            foreach (var item in Status)
            {
                if (Convert.ToBoolean(item.Value) == select)
                    s += "<option  selected='selected' value ='" + item.Value + "'>" + item.Text + "</option>";
                else
                    s += "<option value ='" + item.Value + "'>" + item.Text + "</option>";
            }
            //"JobState(" + item.Id.ToString() + ",'" + item.Status + "')"
            string result = @"<select onchange="+ "NewsState(" + name + ",'" + select + "')" + @" class='form-control' style='height:31px;' data-val='true' id='NewsId" + name + @"' name='NewsId" + name + @"'>" + s + 
             @"</select>";
            return MvcHtmlString.Create(result);
        }
    }
}
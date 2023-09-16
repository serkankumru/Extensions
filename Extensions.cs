using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Haberler.Extensions
{
    public static class Extensions
    {
        public static int GetNewsTitleId(string res)
        {
            if (res==null)
            {
                return 0;
            }
            string result = "";
            for (int i = res.Length-1; i >0 ; i--)
            {
                if (res[i] >= 48 && res[i] <= 57)
                {
                    result += res[i];
                }
                if (res[i] == '-')
                {
                    string reverse = "";
                    for (int j = result.Length-1; j >= 0; j--)
                    {
                        reverse +=result[j];
                    }
                    return Convert.ToInt32(reverse);
                }
            }
            return 0;
        }

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
            string result = @"<select onchange="+ "NewsState(" + name + ")" + @" class='form-control' style='height:31px;' data-val='true' id='NewsId" + name + @"' name='NewsId" + name + @"'>" + s + 
             @"</select>";
            return MvcHtmlString.Create(result);
        }
    }
}
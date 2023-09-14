using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirstMVC.Models;

namespace FirstMVC.Extensions
{
    public static class MyExtensions
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

        public static MvcHtmlString MyActionLink(this HtmlHelper htmlHelper,string cName,string aName,string text)
        {
            string result = string.Format("<a href='/{0}/{1}'>{2}</a>",cName,aName,text);
            return MvcHtmlString.Create(result);
        }

        public static MvcHtmlString MyTextbox(this HtmlHelper htmlHelper, string name, string class1, string class2)
        {
            string result = string.Format(@"<div class='form-group'>
            <label class ='"+ class1+"' for='"+name+"'>"+name+@"</label>
            <div class='"+class2+ @"'>
            <input class='form-control text-box single-line' id='"+ name+@"' name='" + name + @"' type='text' value='' />
            <span class='field-validation-valid text-danger' data-valmsg-for='" + name + @"' data-valmsg-replace='true'></span>
                </div> 
            </div>");

            return MvcHtmlString.Create(result);
        }

        public static MvcHtmlString MyDropbox(this HtmlHelper htmlHelper, string name, List<SelectListItem> listItems, string class1, string class2)
        {
            string s = "";

            foreach (var item in listItems)
            {
                s += "<option value ='" + item.Value + "'>" + item.Text + "</option>";
            }

            string result = string.Format(@"<div class='form-group'>
            <label class ='" + class1 + "' for='" + name + "'>" + name + @"</label>
            <div class='" + class2 + @"'>
            <select class='form-control' data-val='true' data-val-number='The field CandaidateId must be a number.' id='" + name + @"' name='"+ name + @"'>"+s +@"</select><span class='field-validation-valid text-danger' data-valmsg-for='" + name + @"' data-valmsg-replace='true'></span>
                </div>
            </div>");
            return MvcHtmlString.Create(result);
        }

        public static MvcHtmlString MyDropboxOnchange(this HtmlHelper htmlHelper, string name, List<SelectListItem> listItems, string class1, string class2,string script)
        {
            string s = "";

            foreach (var item in listItems)
            {
                s += "<option value ='" + item.Value + "'>" + item.Text + "</option>";
            }

            string result = string.Format(@"<div class='form-group'>
            <label class ='" + class1 + "' for='" + name + "'>" + name + @"</label>
            <div class='" + class2 + @"'><select class='form-control' data-val='true' data-val-number='The field CandaidateId must be a number.' id='drp" + name + @"' name='" + name + @"' onchange='"+ script + "'>" + s + @"</select>
            <span class='field-validation-valid text-danger' data-valmsg-for='" + name + @"' data-valmsg-replace='true'></span>
                </div>
            </div>");

            return MvcHtmlString.Create(result);
        }

        public static MvcHtmlString MySimpleDropdown(this HtmlHelper htmlHelper,List<FundSegmen> fundSegmen)
        {
            //string result = string.Format("<select>" + s + @"</select>");
            string result = "<select class='form-control' id='segment' name='segment'>";
            result += "<option value='0'>Seçiniz.</option>";

            foreach (var item in fundSegmen)
            {
                result += "<option value='"+item.Id+"'>"+item.Display+"</option>";
            }
            

            result += "</select>";

            return MvcHtmlString.Create(result);
        }


        public static MvcHtmlString MyDropboxJobStatus(this HtmlHelper htmlHelper, string name,bool select)
        {
            string s = "";

            List<SelectListItem> Status = new List<SelectListItem>();
            Status.Add(new SelectListItem() { Text = "Geçersiz", Value = "false" });
            Status.Add(new SelectListItem() { Text = "Geçerli", Value = "true" });


            foreach (var item in Status)
            {
                if (Convert.ToBoolean(item.Value) == select)
                    s += "<option  selected='selected' value ='" + item.Value + "'>" + item.Text + "</option>";
                else
                    s += "<option value ='" + item.Value + "'>" + item.Text + "</option>";
            }
            //"JobState(" + item.Id.ToString() + ",'" + item.Status + "')"
            string result = @"<select onchange="+ "JobState(" + name + ",'" + select + "')" + @" class='form-control' style='height:31px;' data-val='true' id='JobId" + name + @"' name='JobId" + name + @"'>" + s + 
             @"</select>";
            return MvcHtmlString.Create(result);
        }
    }
}
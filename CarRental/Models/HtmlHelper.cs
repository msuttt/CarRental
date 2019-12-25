using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace CarRental.Models
{
    public static class HtmlHelper
    {
        public static string MyTextBox<TModel, Tvalue>(this HtmlHelper<TModel> htmlhelper, Expression<Func<TModel, Tvalue>> expression)
        {
            var div = new TagBuilder("div");
            var lbl = htmlhelper.LabelFor(expression);
            var txt = htmlhelper.TextBoxFor(expression);
            div.InnerHtml += lbl;
            div.InnerHtml += txt;

            return div.ToString();

        }

        public static string MyDropDown<TModel, Tvalue>(this HtmlHelper<TModel> htmlhelper, Expression<Func<TModel, Tvalue>> expression, SelectList list)
        {
            var div = new TagBuilder("div");
            var lbl = htmlhelper.LabelFor(expression);
            var txt = htmlhelper.DropDownListFor(expression, list);
            div.InnerHtml += lbl;
            div.InnerHtml += txt;

            return div.ToString();

        }
        //public static string MyCheckBox<TModel, Tvalue>(this HtmlHelper<TModel> htmlhelper ,Expression<Func<TModel,Tvalue>> expression)
        //{
        //    var div = new TagBuilder("div");
        //    var lbl = htmlhelper.LabelFor(expression);
        //    var txt = htmlhelper.CheckBox(expression);
        //    div.InnerHtml += lbl;
        //    div.InnerHtml += txt;

        //    return div.ToString();

        //}

    }
}
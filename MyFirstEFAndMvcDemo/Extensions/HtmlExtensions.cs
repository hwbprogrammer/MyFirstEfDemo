using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MyFirstEFAndMvcDemo.Extensions
{
    public static class HtmlExtensions
    {
        /// <summary>
        /// 表格模型
        /// </summary>
        /// <param name="html"></param>
        /// <param name="tableName">tableId</param>
        /// <returns>Table字符串</returns>
        public static MvcHtmlString TableFor(this HtmlHelper html,string tableName)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" <table id='"+tableName+"'></table>");
            return MvcHtmlString.Create(sb.ToString());
        }
    }
}
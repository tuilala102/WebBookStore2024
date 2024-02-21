using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBookStore.Areas.Admin.Models.SearchOrder
{
     public class SearchOrder
     {
          public string Text { set; get; }
          public string DateStart { set; get; }
          public string DateEnd { set; get; }
          public int Status { set; get; }
     }
}
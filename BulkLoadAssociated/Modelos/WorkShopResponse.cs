using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicesTaronApi.API.Models
{
    public class Data
    {
        public int status { get; set; }
        public string message { get; set; }
    }

    public class WorkShopResponse
    {
        public Data data { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicesTaronApi.API.Models
{
    public class Operatoruuid
    {
        public string uuid { get; set; }
        public int status { get; set; }
        public string name { get; set; }
    }

    public class OperatorToModify
    {
        public string uuid { get; set; }
        public List<Operatoruuid> operatoruuid { get; set; }
        public string updatedate { get; set; }
    }
}
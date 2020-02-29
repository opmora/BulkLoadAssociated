using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulkLoadAssociated.Modelos
{
    public class AssociatedModel
    {
        public string _id { set; get; }        
        public string uuid { set; get; }
        public string user { set; get; }
        public string password { set; get; }
        public DateTime creationdate { set; get; }
        public int status { set; get; }
        public DateTime registrationdate { set; get; }
        public WorkshopModel workshopmodel { set; get; }
        public string tokentemp { set; get; }
    }
}
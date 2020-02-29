using BulkLoadAssociated.Bean;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulkLoadAssociated.Modelos
{
    public class WorkshopModel
    {
        public string uuid { set; get; }
        public string workshopname { set; get; }
        public string managername { set; get; }
        public string phone1 { set; get; }
        public string phone2 { set; get; }
        public string address { set; get; }
        public string postalcode { set; get; }
        public string city { set; get; }
        public string betweenstreets { set; get; }
        public string latitud { set; get; }
        public string longitude { set; get; }
        public string scanner { set; get; }
        public List<CatalogCommon> rails { set; get; }
        public List<CatalogCommon> tools { set; get; }
        public List<CatalogCommon> specialty { set; get; }
        public DateTime registrationdate { set; get; }
        public DateTime updatedate { set; get; }
        public DateTime closeoffice { set; get; }
        public DateTime openoffice { set; get; }
        public int days { set; get; }
        public int status { set; get; }
        public int available { set; get; }
        public string registrationdatemilis { set; get; }
        public string updatedatemilis { set; get; }
        public string closeofficemilis { set; get; }
        public string openofficemilis { set; get; }
        public string expirationdatemilis { set; get; }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulkLoadAssociated.Modelos;
using BulkLoadAssociated.Bean;
using System.Globalization;

namespace BulkLoadAssociated
{
    public static class CSV
    {

        public static List<string[]> ReaCSV(string path)
        {
            List<string[]> parsedData = new List<string[]>();

            using (StreamReader readFile = new StreamReader(path))
            {
                string line;
                string[] row;
                while ((line = readFile.ReadLine()) != null)
                {
                    row = line.Split(',');
                    parsedData.Add(row);
                }
            }
            return parsedData;
        }

        public static List<AssociatedModel> ConverToAssociated (List<string[]> CSVItemsList)
        {
            List<AssociatedModel> associateds = new List<AssociatedModel>();
            AssociatedModel associated;
            WorkshopModel workshop = new WorkshopModel();

            CatalogCommon rail;
            CatalogCommon tool;
            CatalogCommon specialty;

            string[] rowRail;
            string[] rowTool;
            string[] rowSpecialty;

            foreach (var row in CSVItemsList)
            {
                associated = new AssociatedModel();
                associated._id = row[0];
                associated.uuid = row[1];
                associated.user = row[2];
                associated.password = row[3];
                associated.creationdate = parseToData(row[4]);
                associated.status = Convert.ToInt32(row[5]);
                associated.registrationdate = parseToData(row[6]);

                workshop.uuid = row[7];
                workshop.workshopname = row[8];
                workshop.managername = row[9];
                workshop.phone1 = row[10];
                workshop.phone2 = row[11];
                workshop.address = row[12];
                workshop.postalcode = row[13];
                workshop.city = row[14];
                workshop.betweenstreets = row[15];
                workshop.latitud = row[16];
                workshop.longitude = row[17];
                workshop.scanner = row[18];
                //lita de rails
                workshop.rails = parseCommon(row[19]);
                //Lista de tools
                workshop.tools = parseCommon(row[20]);
                //Specialty list
                workshop.specialty = parseCommon(row[21]);

                workshop.registrationdate = parseToData(row[22]);
                workshop.updatedate = parseToData(row[23]);
                workshop.closeoffice = parseToData(row[24]);
                workshop.openoffice = parseToData(row[25]);
                workshop.days = Convert.ToInt32(row[26]);
                workshop.status = Convert.ToInt32(row[27]);
                workshop.available = Convert.ToInt32(row[28]);
                workshop.registrationdatemilis = row[29];
                workshop.updatedatemilis = row[30];
                workshop.closeofficemilis = row[31];
                workshop.openofficemilis = row[32];
                workshop.expirationdatemilis = row[33];

                associated.workshopmodel = workshop;
                associated.tokentemp = row[34];

                associateds.Add(associated);
            }

            return associateds;
        }

        public static DateTime parseToData(string date)
        {
            return DateTime.ParseExact(date, "yyyy-MM-ddThh:mm:ss.fffZ", CultureInfo.InvariantCulture);
        }

        public static List<CatalogCommon> parseCommon(string data)
        {
            string[] row;
            CatalogCommon catalogCommon;
            List<CatalogCommon> commons = new List<CatalogCommon>();

            foreach (var items in data.Split(';'))
            {
                catalogCommon = new CatalogCommon();
                row = data.Split('|');
                catalogCommon.id = row[0];
                catalogCommon.name = row[1];
                catalogCommon.description = row[2];
                commons.Add(catalogCommon);
            }   

            return commons;
        }

    }
}

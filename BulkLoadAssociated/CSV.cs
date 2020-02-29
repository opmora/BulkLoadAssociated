using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulkLoadAssociated.Modelos;
using BulkLoadAssociated.Bean;

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

        public static AssociatedModel ConverToAssociated (List<string[]> CSVItemsList)
        {
            AssociatedModel associated = new AssociatedModel();
            WorkshopModel workshop = new WorkshopModel();

            CatalogCommon rail;
            CatalogCommon tool;
            CatalogCommon specialty;

            string[] rowRail;
            string[] rowTool;
            string[] rowSpecialty;

            foreach (var row in CSVItemsList)
            {
                associated._id = row[0];
                associated.uuid = row[1];
                associated.user = row[2];
                associated.password = row[3];
                associated.creationdate = Convert.ToDateTime(row[4], 'yyyy-mm-dd hh:mm:ss');
                associated.status = Convert.ToInt32(row[5]);
                associated.registrationdate = Convert.ToDateTime(row[6]);

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
                rowRail = row[18].Split('|');
                rail = new CatalogCommon();
                rail.id = rowRail[0];
                rail.name = rowRail[2];
                rail.description = rowRail[3];
                workshop.rails.Add(rail);
                //Lista de tools
                rowTool = row[18].Split('|');
                tool = new CatalogCommon();
                tool.id = rowTool[0];
                tool.name = rowTool[2];
                tool.description = rowTool[3];
                workshop.rails.Add(rail);
                //Specialty list
                rowSpecialty = row[18].Split('|');
                specialty = new CatalogCommon();
                specialty.id = rowSpecialty[0];
                specialty.name = rowSpecialty[2];
                specialty.description = rowSpecialty[3];
                workshop.rails.Add(rail);

                workshop.registrationdate = Convert.ToDateTime(row[22]);
                workshop.updatedate = Convert.ToDateTime(row[23]);
                workshop.closeoffice = Convert.ToDateTime(row[24]);
                workshop.openoffice = Convert.ToDateTime(row[25]);
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
            }

            return associated;
        }

    }
}
